namespace GestaoFinanceiraAPI.Models
{
    public class PlanoFuturo
    {
        public int Id { get; set; }
        public string Descricao { get; set; } // Ex: "Comprar um carro"
        public decimal ValorNecessario { get; set; } // Valor total necessário
        public DateTime Prazo { get; set; } // Data limite para atingir a meta
        public int UsuarioId { get; set; } // Chave estrangeira para o usuário
        public Usuario Usuario { get; set; } // Propriedade de navegação
    }
}