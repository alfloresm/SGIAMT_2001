using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoInscripcion
    {
        public int PK_II_Cod { get; set; }
        public double DI_Monto { get; set; }
        public DateTime DTI_Fecha { get; set; }
        public byte[] VBI_archivoPago { get; set; }
        public int FK_IUM_CodUm { get; set; }
    }
}
