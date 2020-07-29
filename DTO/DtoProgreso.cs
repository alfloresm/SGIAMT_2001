using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoProgreso
    {
        public int PK_IA_CodAsi { get; set; }
        public int VP_NombreProgreso { get; set; }
        public double DP_NotaPasos { get; set; }
        public double DP_NotaTecnica { get; set; }
        public double DP_NotaInteres { get; set; }
        public double DP_NotaHabilidad { get; set; }
        public double DP_TotalNota { get; set; }
        public string VP_Observacion { get; set; }
        public int FK_IA_CodAsi { get; set; }
    }
}
