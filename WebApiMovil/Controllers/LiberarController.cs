using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApiMovil.Controllers
{
    public class LiberarController : System.Web.Http.ApiController
    {
        LiberarService liberarservice;
        public LiberarController()
        {
            //asignarService = new AsignarService();
            liberarservice = new LiberarService();
        }

        [HttpPost]
        [ActionName("BuscarPortafolios")]
        public List<PortafolioLiberar_Response> BuscarPortafolios(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarservice.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarRecursos")]
        public List<RecursolioLiberar_Response> BuscarRecursos(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarservice.BuscarRecursos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarComponentesCerrados")]
        public List<ComponenteCerrado_Response> BuscarComponentesCerrados(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarservice.BuscarComponentesCerrados(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarRecursosComponente")]
        public List<RecursosComponente_Response> BuscarRecursosComponente(PortafolioLiberar_Request obj)
        {
            try
            {
                return liberarservice.BuscarRecursosComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("LiberarRecursoComponente")]
        public LiberarRecursoComponente_Response LiberarRecursoComponente(LiberarRecursoComponente_Request obj)
        {
            try
            {
                return liberarservice.LiberarRecursoComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}