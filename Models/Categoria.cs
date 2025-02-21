namespace GestaoFinanceiraAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Ex: "Alimentação", "Saúde", "Lazer"
        public string Tipo { get; set; } // Ex: "Essencial", "Não Essencial"
    }
}