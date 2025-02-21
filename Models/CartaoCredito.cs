namespace GestaoFinanceiraAPI.Models
{
    public class CartaoCredito
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Ex: "Nubank", "Itaú"
        public decimal Limite { get; set; }
        public decimal SaldoUtilizado { get; set; }
        public int UsuarioId { get; set; } // Chave estrangeira para o usuário
        public Usuario Usuario { get; set; } // Propriedade de navegação
    }
}