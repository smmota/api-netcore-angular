using System;
using System.Collections.Generic;
using System.Text;

namespace NTec.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LoginUser { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
