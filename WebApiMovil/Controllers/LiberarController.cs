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

        //AsignarService asignarService;
        PortafolioService portafolioService;
        public LiberarController()
        {
            //asignarService = new AsignarService();
            portafolioService = new PortafolioService();
        }

        [HttpPost]
        [ActionName("BuscarPortafolios")]
        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                return portafolioService.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}