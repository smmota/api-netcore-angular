using System;

namespace NTec.Domain.Entities
{
    public class Colaborador : Base
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public int IdSetor { get; set; }
        public int IdCargo { get; set; }
        public bool Ativo { get; set; }
        public int? IdSuperiorImediato { get; set; }
    }
}
