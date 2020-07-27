using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoAsistencia
    {
        public int PK_IA_CodsAs { get; set; }
        public string VA_Semana { get; set; }
        public string VA_Hora { get; set; }
        public string VA_EstadoAsistencia { get; set; }
        public string FK_VU_Dni { get; set; }
        public int FK_ISD_CodSemanaDia { get; set; }
    }
}
