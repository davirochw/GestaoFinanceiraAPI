using GestaoFinanceiraAPI.Models;
using Microsoft.EntityFrameworkCore;

public class CartaoCreditoService : ICartaoCreditoService
{
    private readonly ApplicationDbContext _context;

    public CartaoCreditoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CartaoCredito>> ObterTodosCartoesAsync(int usuarioId)
    {
        return await _context.CartoesCredito
            .Where(c => c.UsuarioId == usuarioId)
            .ToListAsync();
    }

    public async Task<CartaoCredito> ObterCartaoPorIdAsync(int id, int usuarioId)
    {
        return await _context.CartoesCredito
            .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == usuarioId);
    }

    public async Task<CartaoCredito> AdicionarCartaoAsync(CartaoCredito cartao)
    {
        if (cartao == null)
            throw new ArgumentNullException(nameof(cartao));

        _context.CartoesCredito.Add(cartao);
        await _context.SaveChangesAsync();
        return cartao;
    }

    public async Task<CartaoCredito> AtualizarCartaoAsync(CartaoCredito cartao, int usuarioId)
    {
        var cartaoExistente = await _context.CartoesCredito
            .FirstOrDefaultAsync(c => c.Id == cartao.Id && c.UsuarioId == usuarioId);

        if (cartaoExistente == null)
            throw new InvalidOperationException("Cartão de crédito não encontrado ou não pertence ao usuário.");

        cartaoExistente.Nome = cartao.Nome;
        cartaoExistente.Limite = cartao.Limite;
        cartaoExistente.SaldoUtilizado = cartao.SaldoUtilizado;

        _context.CartoesCredito.Update(cartaoExistente);
        await _context.SaveChangesAsync();
        return cartaoExistente;
    }

    public async Task<bool> ExcluirCartaoAsync(int id, int usuarioId)
    {
        var cartao = await _context.CartoesCredito
            .FirstOrDefaultAsync(c => c.Id == id && c.UsuarioId == usuarioId);

        if (cartao == null)
            return false;

        _context.CartoesCredito.Remove(cartao);
        await _context.SaveChangesAsync();
        return true;
    }
}