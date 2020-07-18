using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPago
    {
        public int PK_IP_CodPago { get; set; }
        public DateTime DTP_Fecha { get; set; }
        public decimal DP_Monto { get; set; }
        public string VP_Anio { get; set; }
        public string VP_Mes { get; set; }
        public string VP_Estado { get; set; }
        public string FK_IU_DNI { get; set; }
    }
}
