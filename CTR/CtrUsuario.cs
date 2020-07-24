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
                throw new Exception("Usuario y/o contrase&ntilde;a incorrecta(s)");
            }
            else
            {
                return objDaoUsuario.datosUsuario(dtoUsuario.PK_IU_DNI);
            }
        }
    }
}
