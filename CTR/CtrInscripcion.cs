using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrInscripcion
    {
        DaoInscripcion objdaoinscripcion;
        public CtrInscripcion()
        {
            objdaoinscripcion = new DaoInscripcion();
        }
        public void RegistrarInscripcionP(DtoInscripcion objdtoinscripcion)
        {
            objdaoinscripcion.registrarInscripcionP(objdtoinscripcion);
        }
    }
}
