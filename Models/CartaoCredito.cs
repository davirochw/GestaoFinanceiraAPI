namespace GestaoFinanceiraAPI.Models
{
    public class CartaoCredito
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Ex: "Nubank", "Ita�"
        public decimal Limite { get; set; }
        public decimal SaldoUtilizado { get; set; }
        public int UsuarioId { get; set; } // Chave estrangeira para o usu�rio
        public Usuario Usuario { get; set; } // Propriedade de navega��o
    }
}