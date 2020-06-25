using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace CTR
{
    public class CtrConcurso
    {
        DaoConcurso objDaoConcurso;
        public CtrConcurso()
        {
            objDaoConcurso = new DaoConcurso();
        }
        public DataTable ListaConcursos_()
        {
            return objDaoConcurso.ListarConcursos();
        }

    }
}
