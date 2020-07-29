using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUsuarioModalidadTanda
    {
        public string PK_IUMT_CodUsuModTan { get; set; }
        public int IUMT_PuntajeTotal { get; set; }
        public int IUMT_Pista { get; set; }
        public int IUMT_Estado { get; set; }
        public int FK_IUM_CodUM { get; set; }
        public int FK_IT_CodTan { get; set; }
    }
}
