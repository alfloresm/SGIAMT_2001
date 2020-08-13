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
        public void obtenerTandaP(DtoTanda objtanda)
        {
            objDaoTanda.ObtenerTandaP(objtanda);
        }
        public DataTable listar_calificados_S(DtoTanda objtanda)
        {
            return objDaoTanda.listar_calificados_S(objtanda);
        }
        public void actualizarEstadoT(DtoTanda objtanda)
        {
            objDaoTanda.actualizar_estadoT(objtanda);
        }
        public void actualizarganadorT(DtoTanda objtanda)
        {
            objDaoTanda.actualizar_ganadorT(objtanda);
        }
        public DataTable listar_Tanda_NC()
        {
            return objDaoTanda.listar_Tanda_NC();
        }
        public void regTanda(DtoTanda objtanda)
        {
            objDaoTanda.registrarTanda(objtanda);
        }
        //pasar a ctr_usuarioModalidadTanda
        public void registrarUMT(DtoUsuarioModalidadTanda objUMT)
        {
            objDaoTanda.registrarUMT(objUMT);
        }
        public DataTable obtenerParticipantesxTanda(DtoUsuarioModalidadTanda objUMT)
        {
            return objDaoTanda.ListarParticipantesXtanda(objUMT);
        }
        public void actualizarEstadoUMT(DtoUsuarioModalidadTanda objUMT)
        {
            objDaoTanda.actualizar_estado_umt(objUMT);
        }
        public int sumaPuntajes(DtoUsuarioModalidadTanda objUMT)
        {
           return objDaoTanda.sumaPuntaje(objUMT);
        }
        public void actualizarPuntajeT(DtoUsuarioModalidadTanda objUMT)
        {
            objDaoTanda.actualizar_PuntajeT_umt(objUMT);
        }
    }
}
