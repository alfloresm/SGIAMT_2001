using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class CtrTanda
    {
        DaoTanda objDaoTanda;
        public CtrTanda()
        {
            objDaoTanda = new DaoTanda();
        }
        public bool selectTanda(DtoTanda objtanda)
        {
            return objDaoTanda.SelectTanda(objtanda);
        }
        public void obtenerTanda(DtoTanda objtanda)
        {
            objDaoTanda.ObtenerTanda(objtanda);
        }
        public DataTable obtenerParticipantesxTanda(DtoUsuarioModalidadTanda objUMT)
        {
            return objDaoTanda.ListarParticipantesXtanda(objUMT);
        }
    }
}
