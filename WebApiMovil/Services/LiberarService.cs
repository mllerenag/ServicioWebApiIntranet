using System;
using System.Collections.Generic;
using System.Linq;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class LiberarService
    {
        private LiberarBL liberarBL;

        public LiberarService() {
            liberarBL = new LiberarBL();
        }

        public List<PortafolioLiberar_Response> BuscarPortafolios(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarBL.BuscarPortafolios(obj);
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
                return liberarBL.BuscarRecursos(obj);
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
                return liberarBL.BuscarComponentesCerrados(obj);
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
                return liberarBL.BuscarRecursosComponente(obj);
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
                return liberarBL.LiberarRecursoComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}