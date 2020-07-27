using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrUsuario
    {
        DaoUsuario objDaoUsuario;

        public CtrUsuario()
        {
            objDaoUsuario = new DaoUsuario();
        }
        public void EnviarCorreoInscripcion(DtoUsuarioxModalidad dtoUxm)
        {
            objDaoUsuario.EnviarCorreoInscripcion(dtoUxm);
        }
        public DtoUsuario Login(DtoUsuario dtoUsuario)
        {

            int persona_id = objDaoUsuario.validacionLogin(dtoUsuario.PK_IU_DNI, dtoUsuario.VU_Contrasenia);

            if (persona_id == 0)
            {
                dtoUsuario= null;
                return dtoUsuario;
            }
            else
            {
                return objDaoUsuario.datosUsuario(dtoUsuario.PK_IU_DNI);
            }
        }
    }
}
