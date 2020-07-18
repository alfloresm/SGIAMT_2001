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
    public class CtrPago
    {
        DaoPago objDaoPago;
        public CtrPago()
        {
            objDaoPago = new DaoPago();
        }
        public void RegistrarPago(DtoPago objP)
        {
            objDaoPago.RegistrarPago(objP);
        }
        public void devolverDniAlumnos()
        {
            objDaoPago.ObtenerDNI();
        }
    }
}
