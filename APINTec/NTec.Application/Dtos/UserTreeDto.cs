using System;
using System.Collections.Generic;
using System.Text;

namespace NTec.Application.Dtos
{
    public class UserTreeDto
    {
        public ColaboradorDto Father { get; set; }
        public IEnumerable<ColaboradorDto> Childrens { get; set; }
    }
}
