using GestaoFinanceiraAPI.Models;

public interface ICartaoCreditoService
{
    Task<List<CartaoCredito>> ObterTodosCartoesAsync(int usuarioId);
    Task<CartaoCredito> ObterCartaoPorIdAsync(int id, int usuarioId);
    Task<CartaoCredito> AdicionarCartaoAsync(CartaoCredito cartao);
    Task<CartaoCredito> AtualizarCartaoAsync(CartaoCredito cartao, int usuarioId);
    Task<bool> ExcluirCartaoAsync(int id, int usuarioId);
}