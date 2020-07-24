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
    public class CtrAlumno
    {
        DaoAlumno objDaoAlumno;
        public CtrAlumno()
        {
            objDaoAlumno = new DaoAlumno();
        }
        public void RegistrarAlumno(DtoUsuario objA)
        {
            objDaoAlumno.RegistrarAlumno(objA);
        }

        public DataTable ListarAlumnos()
        {
            return objDaoAlumno.ListarAlumnos();
        }
        public DataTable ListaAlumnos_()
        {
            return objDaoAlumno.ListarAlumnosA();
        }
        public int devolverCategoria(int anio)
        {
            return objDaoAlumno.ObtenerCategoria(anio);
        }
        public DataSet desplegableNivel()
        {
            return objDaoAlumno.desplegarNivel();
        }

    }
}
