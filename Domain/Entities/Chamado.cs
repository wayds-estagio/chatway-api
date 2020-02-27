using System;

namespace Domain.Entities {

    public class Chamado : BaseEntity {
        public string Resumo { get; set; }
        public string Midia { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}