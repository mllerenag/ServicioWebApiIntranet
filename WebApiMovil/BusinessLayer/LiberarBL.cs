using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class LiberarBL
    {
        private LiberarRecursosDA liberarRecursosDA;

        public LiberarBL()
        {
            liberarRecursosDA = new LiberarRecursosDA();
        }


        public List<PortafolioResponse> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                if (obj.codigo == null) obj.codigo = "";
                if (obj.nombre == null) obj.nombre = "";
                if (obj.categoria == null) obj.categoria = "";
                if (obj.fecha_creacion_ini == null) obj.fecha_creacion_ini = "";
                if (obj.fecha_creacion_fin == null) obj.fecha_creacion_fin = "";
                return liberarRecursosDA.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}