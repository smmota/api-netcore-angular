using System;
using System.Collections.Generic;

namespace NTec.Domain.Entities
{
    public class Colaborador : Base
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public int IdSetor { get; set; }
        public Setor Setor { get; set; }
        public int IdCargo { get; set; }
        public Cargo Cargo { get; set; }
        public bool Ativo { get; set; }
        public int? IdSuperiorImediato { get; set; }
        public ICollection<Colaborador> Subordinados { get; set; }
    }
}
