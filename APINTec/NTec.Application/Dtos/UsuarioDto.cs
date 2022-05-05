using System;
using System.Collections.Generic;
using System.Text;

namespace NTec.Application.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LoginUser { get; set; }
        public string Senha { get; set; }
        //public byte[] HashPwd { get; set; }
        public bool Ativo { get; set; }
    }
}
