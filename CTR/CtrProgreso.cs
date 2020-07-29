using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace CTR
{
    public class CtrProgreso
    {
        DaoProgreso objDaoProgreso;
        public CtrProgreso()
        {
            objDaoProgreso = new DaoProgreso();
        }

        public void RegistrarProgresoAlumno(DtoProgreso objPro)
        {
            objDaoProgreso.RegistrarProgreso(objPro);
        }
    }
}
