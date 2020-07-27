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
    public class CtrNivel_TipoNivel
    {
        DaoNivel_TipoNivel objDaoNivelTN;
        public CtrNivel_TipoNivel()
        {
            objDaoNivelTN = new DaoNivel_TipoNivel();
        }

        public DataSet desplegableClase()
        {
            return objDaoNivelTN.desplegarNivel_TipoNivel();
        }
    }
}
