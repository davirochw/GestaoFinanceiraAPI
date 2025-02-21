using GestaoFinanceiraAPI.Models;
using Microsoft.EntityFrameworkCore;

public class CategoriaService : ICategoriaService
{
    private readonly ApplicationDbContext _context;

    public CategoriaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ObterTodasCategoriasAsync()
    {
        return await _context.Categorias.ToListAsync();
    }

    public async Task<Categoria> ObterCategoriaPorIdAsync(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<Categoria> AdicionarCategoriaAsync(Categoria categoria)
    {
        if (categoria == null)
            throw new ArgumentNullException(nameof(categoria));

        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();
        return categoria;
    }

    public async Task<Categoria> AtualizarCategoriaAsync(Categoria categoria)
    {
        var categoriaExistente = await _context.Categorias.FindAsync(categoria.Id);
        if (categoriaExistente == null)
            throw new InvalidOperationException("Categoria não encontrada.");

        categoriaExistente.Nome = categoria.Nome;
        categoriaExistente.Tipo = categoria.Tipo;

        _context.Categorias.Update(categoriaExistente);
        await _context.SaveChangesAsync();
        return categoriaExistente;
    }

    public async Task<bool> ExcluirCategoriaAsync(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
            return false;

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();
        return true;
    }
}