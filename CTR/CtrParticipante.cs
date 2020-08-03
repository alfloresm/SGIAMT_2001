using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrParticipante
    {
        DaoParticipante objdaoParticipante;
        public CtrParticipante()
        {
            objdaoParticipante = new DaoParticipante();
        }
        public bool existeUsuario(DtoUsuario dtoUsuario)
        {
            return objdaoParticipante.SelectUsuario(dtoUsuario);
        }
        public bool existeUsuarioAca(DtoUsuario dtoUsuario)
        {
            return objdaoParticipante.SelectUsuario_Aca(dtoUsuario);
        }
        public bool existeUsuarioGen(DtoUsuario dtoUsuario,string gen)
        {
            return objdaoParticipante.SelectUsuario_Gen(dtoUsuario,gen);
        }
        public void obtenerParticipante(DtoUsuario dtoUsuario,DtoCategoria objcat)
        {
            objdaoParticipante.ObtenerParticipante(dtoUsuario, objcat);
        }
        public void registrarParticipante(DtoUsuario obju)
        {
            objdaoParticipante.RegistrarParticipante(obju);
        }
        public void registrarImgP(byte[] bytes, string id)
        {
            objdaoParticipante.RegistrarImgUsuario(bytes, id);
        }
    }
}
