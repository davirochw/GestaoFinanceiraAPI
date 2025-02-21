public class CartaoCreditoDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Limite { get; set; }
    public decimal SaldoUtilizado { get; set; }
    public int UsuarioId { get; set; }
}