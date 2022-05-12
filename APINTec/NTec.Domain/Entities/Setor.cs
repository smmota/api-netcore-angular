using System.Collections.Generic;
using System.Text;

namespace NTec.Domain.Entities
{
    public class Setor : Base
    {
        public string Descricao { get; set; }
        public string Atividade { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Colaborador> Colaboradores { get; set; }
    }
}
