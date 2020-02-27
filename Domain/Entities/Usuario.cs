using System;
using System.Text.Json.Serialization;

namespace Domain.Entities {

    public class Usuario : BaseEntity {
        public string Nome { get; set; }
        public string Login { get; set; }

        [JsonIgnore]
        public string Senha { get; set; }

        public string Unidade { get; set; }
        public string Empresa { get; set; }
        public string Tipo { get; set; }

        public string Dispositivo { get; set; }
        public DateTime DataCriacao { get; set; } = new DateTime();
    }
}