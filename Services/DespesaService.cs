using Microsoft.EntityFrameworkCore;

public class DespesaService : IDespesaService
{
    private readonly ApplicationDbContext _context;

    public DespesaService(ApplicationDbContext context)
    {
        _context = context;
    }

    // Obter todas as despesas de um usuário
    public async Task<List<Despesa>> ObterTodasDespesasAsync(int usuarioId)
    {
        return await _context.Despesas
            .Where(d => d.UsuarioId == usuarioId)
            .Include(d => d.Categoria)
            .ToListAsync();
    }

    // Obter uma despesa específica por ID e usuário
    public async Task<Despesa> ObterDespesaPorIdAsync(int id, int usuarioId)
    {
        return await _context.Despesas
            .Include(d => d.Categoria)
            .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == usuarioId);
    }

    // Adicionar uma nova despesa
    public async Task<Despesa> AdicionarDespesaAsync(Despesa despesa)
    {
        if (despesa == null)
            throw new ArgumentNullException(nameof(despesa));

        _context.Despesas.Add(despesa);
        await _context.SaveChangesAsync();
        return despesa;
    }

    // Atualizar uma despesa existente
    public async Task<Despesa> AtualizarDespesaAsync(Despesa despesa, int usuarioId)
    {
        var despesaExistente = await _context.Despesas
            .FirstOrDefaultAsync(d => d.Id == despesa.Id && d.UsuarioId == usuarioId);

        if (despesaExistente == null)
            throw new InvalidOperationException("Despesa não encontrada ou não pertence ao usuário.");

        despesaExistente.Descricao = despesa.Descricao;
        despesaExistente.Valor = despesa.Valor;
        despesaExistente.Data = despesa.Data;
        despesaExistente.CategoriaId = despesa.CategoriaId;

        _context.Despesas.Update(despesaExistente);
        await _context.SaveChangesAsync();
        return despesaExistente;
    }

    // Excluir uma despesa
    public async Task<bool> ExcluirDespesaAsync(int id, int usuarioId)
    {
        var despesa = await _context.Despesas
            .FirstOrDefaultAsync(d => d.Id == id && d.UsuarioId == usuarioId);

        if (despesa == null)
            return false;

        _context.Despesas.Remove(despesa);
        await _context.SaveChangesAsync();
        return true;
    }

    // Calcular o total de despesas em um período
    public async Task<decimal> CalcularTotalDespesasPorPeriodoAsync(int usuarioId, DateTime inicio, DateTime fim)
    {
        return await _context.Despesas
            .Where(d => d.UsuarioId == usuarioId && d.Data >= inicio && d.Data <= fim)
            .SumAsync(d => d.Valor);
    }

    // Obter despesas por categoria
    public async Task<List<Despesa>> ObterDespesasPorCategoriaAsync(int usuarioId, int categoriaId)
    {
        return await _context.Despesas
            .Where(d => d.UsuarioId == usuarioId && d.CategoriaId == categoriaId)
            .Include(d => d.Categoria)
            .ToListAsync();
    }
}