using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoNivel_TipoNivel
    {
        public int ITN_NumAlumno { get; set; }
        public int FK_ITN_CodTipoNivel { get; set; }
        public int FK_IN_CodNivel { get; set; }
    }
}
