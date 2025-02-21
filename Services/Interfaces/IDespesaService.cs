public interface IDespesaService
{
    Task<List<Despesa>> ObterTodasDespesasAsync(int usuarioId);
    Task<Despesa> ObterDespesaPorIdAsync(int id, int usuarioId);
    Task<Despesa> AdicionarDespesaAsync(Despesa despesa);
    Task<Despesa> AtualizarDespesaAsync(Despesa despesa, int usuarioId);
    Task<bool> ExcluirDespesaAsync(int id, int usuarioId);
    Task<decimal> CalcularTotalDespesasPorPeriodoAsync(int usuarioId, DateTime inicio, DateTime fim);
    Task<List<Despesa>> ObterDespesasPorCategoriaAsync(int usuarioId, int categoriaId);
}