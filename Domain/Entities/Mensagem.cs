namespace Domain.Entities {

    public class Mensagem : BaseEntity {
        public string Conteudo { get; set; }
        public string Remetente { get; set; }
        public string Chat { get; set; }
    }
}