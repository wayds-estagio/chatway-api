using System;
using System.Collections.Generic;

namespace Domain.Entities {

    public class Chat : BaseEntity {
        public string Atendente { get; set; }
        public string AtendenteId { get; set; }
        public string Motorista { get; set; }
        public string MotoristaId { get; set; }
        public string Unidade { get; set; }
        public string CaminhoImage { get; set; }
        public bool Concluido { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<Mensagem> Mensagens { get; set; }
    }
}
