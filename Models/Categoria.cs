namespace GestaoFinanceiraAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Ex: "Alimenta��o", "Sa�de", "Lazer"
        public string Tipo { get; set; } // Ex: "Essencial", "N�o Essencial"
    }
}