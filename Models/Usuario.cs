using GestaoFinanceiraAPI.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Senha { get; set; }

    public List<CartaoCredito> CartoesCredito { get; set; } = new List<CartaoCredito>();
    public List<PlanoFuturo> PlanosFuturos { get; set; } = new List<PlanoFuturo>();
    public List<Despesa> Despesas { get; set; } = new List<Despesa>();
}