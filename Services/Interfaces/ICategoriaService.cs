using GestaoFinanceiraAPI.Models;

public interface ICategoriaService
{
    Task<List<Categoria>> ObterTodasCategoriasAsync();
    Task<Categoria> ObterCategoriaPorIdAsync(int id);
    Task<Categoria> AdicionarCategoriaAsync(Categoria categoria);
    Task<Categoria> AtualizarCategoriaAsync(Categoria categoria);
    Task<bool> ExcluirCategoriaAsync(int id);
}