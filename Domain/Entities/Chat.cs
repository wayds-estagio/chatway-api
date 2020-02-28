using System;

namespace Domain.Entities {

    public class Chat : BaseEntity {
        public string Atendente { get; set; }
        public string Motorista { get; set; }
        public string Unidade { get; set; }

        public bool Concluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Mensagem> Mensagens { get; set; }
    }
}