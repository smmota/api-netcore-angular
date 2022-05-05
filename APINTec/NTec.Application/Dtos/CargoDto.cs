using System;

namespace NTec.Application.Dtos
{
    public class CargoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Atividade { get; set; }
        public bool Ativo { get; set; }
    }
}
