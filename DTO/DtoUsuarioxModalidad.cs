using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUsuarioxModalidad
    {
        public int PK_IUM_CodUM { get; set; }
        public string VUM_Fase { get; set; }
        public int FK_IM_IdModalidad { get; set; }
        public int FK_IC_IdConcurso { get; set; }
        public string FK_VU_Dni { get; set; }
        public DateTime DTUM_FechaIns { get; set; }
        public int IUM_Estado { get; set; }
        public string FK_DNI_Pareja { get; set; }
    }
}
