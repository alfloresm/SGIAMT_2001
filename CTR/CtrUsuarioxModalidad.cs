using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace CTR
{
    public class CtrUsuarioxModalidad
    {
        DaoUsuarioxModalidad objdaouxm;
        public CtrUsuarioxModalidad()
        {
            objdaouxm = new DaoUsuarioxModalidad();
        }
        public void registrarUXM_S(DtoUsuarioxModalidad objdtouxm)
        {
            objdaouxm.RegistrarUXM_S(objdtouxm);
        }
        public void registrarUXM_N(DtoUsuarioxModalidad objdtouxm)
        {
            objdaouxm.RegistrarUXM_N(objdtouxm);
        }
        public bool existeUXM_S(DtoUsuarioxModalidad objdtouxm)
        {
            return objdaouxm.existeUXM_S(objdtouxm);
        }
        public bool existeUXM_N(DtoUsuarioxModalidad objdtouxm)
        {
            return objdaouxm.existeUXM_N(objdtouxm);
        }
    }
}
