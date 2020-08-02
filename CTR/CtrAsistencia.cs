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
    public class CtrAsistencia
    {
        DaoAsistencia objDaoAsistencia;
        public CtrAsistencia()
        {
            objDaoAsistencia = new DaoAsistencia();
        }

        public void ObtenerDatosAlumno(DtoUsuario objUsu)
        {
            objDaoAsistencia.ObtenerAlumnoAsis(objUsu);
        }

        public void RegistrarAsistencia(DtoAsistencia objAsis)
        {
            objDaoAsistencia.RegistrarAsistencia(objAsis);
        }
        public DataSet desplegableTipoNivel()
        {
            return objDaoAsistencia.desplegarTipoNivel();
        }
        public DataSet desplegableNivel()
        {
            return objDaoAsistencia.desplegarNivel();
        }
    }
}
