using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoSemana_Dia
    {
        public int FK_ID_CodDia { get; set; }
        public int FK_IS_CodSemana { get; set; }
        public string VSD_Anio { get; set; }
        public string VSD_Mes { get; set; }

    }
}
