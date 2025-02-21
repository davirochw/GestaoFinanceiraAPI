using GestaoFinanceiraAPI.Models;

public class Despesa
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
}