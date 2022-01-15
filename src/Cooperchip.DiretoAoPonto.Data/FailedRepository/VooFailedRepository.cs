using Cooperchip.DiretoAoPonto.Data.FailedRepository;
using Cooperchip.DiretoAoPonto.Data.Orm;
using Cooperchip.DiretoAoPonto.Uow.Domain;

public class VooFailedRepository : IVooFailedRepository
{
    private readonly UoWDbContext _context;

    public VooFailedRepository(UoWDbContext context)
    {
        _context = context;
    }

    public async Task DecrementarVaga(Guid? vooId)
    {

        if (vooId == null)
            throw new Exception("Id do Voo não pode ser nulo.");

        var voo = await _context.Voo.FindAsync(vooId);

        if (voo == null)
            throw new Exception("Voo não encontrado.");

        if (!voo.TemDisponibilidade())
            throw new Exception("Não há mais vagas disponível para este voo!");

        voo.DecremenentaDisponibilidade();

        _context.Set<Voo>().Update(voo);
        await _context.SaveChangesAsync();

    }
}
