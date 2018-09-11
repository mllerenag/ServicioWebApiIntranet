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

        public List<PortafolioResponse> BuscarPortafolios(Portafolio_Request obj)
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
    }
}