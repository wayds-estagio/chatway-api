using System.Collections.Generic;

namespace Domain.Entities {

    public class Unidade : BaseEntity {
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public List<string> MensagemPadrao { get; set; }
    }
}