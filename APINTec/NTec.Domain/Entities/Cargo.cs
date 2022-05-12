using System.Collections.Generic;

namespace NTec.Domain.Entities
{
    public class Cargo : Base
    {
        public string Descricao { get; set; }
        public string Atividade { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
