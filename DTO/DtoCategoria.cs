using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoCategoria
    {
        public int PK_ICA_CodCat { get; set; }
        public string VCA_NomCategoria { get; set; }
        public int ICA_AnioInicio { get; set; }
        public int ICA_AnioFin { get; set; }
    }
}
