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

        public List<PortafolioLiberar_Response> BuscarPortafolios(PortafolioLiberar_Request obj)
        {
            try
            {
                if (obj.codigo == null) obj.codigo = "";
                if (obj.nombre == null) obj.nombre = "";
                return liberarRecursosDA.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RecursolioLiberar_Response> BuscarRecursos(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarRecursosDA.BuscarRecursos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComponenteCerrado_Response> BuscarComponentesCerrados(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarRecursosDA.BuscarComponentesCerrados(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RecursosComponente_Response> BuscarRecursosComponente(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarRecursosDA.BuscarRecursosComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LiberarRecursoComponente_Response LiberarRecursoComponente(LiberarRecursoComponente_Request obj)
        {
            try
            {
                return liberarRecursosDA.LiberarRecursoComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}