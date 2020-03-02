namespace Domain.Entities {

    public class Mensagem : BaseEntity {
        public string Type { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Time { get; set; }
        public bool IsRead { get; set; }
        public bool IsSent { get; set; }
    }
}