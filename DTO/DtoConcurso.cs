using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoConcurso
    {
        public int PK_IC_IdConcurso { get; set; }
        public string VC_NombreCon { get; set; }
        public string VC_LugarCon { get; set; }
        public DateTime DTC_FechaConcurso { get; set; }
        public double DC_PrecioSeriado { get; set; }
        public double DC_PrecioNovel { get; set; }
        public int FK_IEC_IdEstado { get; set; }
    }
}
