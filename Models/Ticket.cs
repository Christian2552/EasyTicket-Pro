namespace EasyTicket_Pro.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        // Vryzka s potrebitelya
        public int UserId { get; set; }
        public User? User { get; set; }

        // Vryzka sys sybitieto
        public int EventId { get; set; }
        public Event? Event { get; set; }

        // Dopylnitelni danni za rezervaciqta
        public DateTime PurchasedAt { get; set; } = DateTime.Now;
        public int Quantity { get; set; } = 1;
        public decimal TotalPrice { get; set; }
    }
}