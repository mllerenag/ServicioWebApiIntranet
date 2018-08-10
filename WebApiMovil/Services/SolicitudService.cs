using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class SolicitudService
    {
        private SolicitudBL solicitudBL;

        public SolicitudService()
        {
            solicitudBL = new SolicitudBL();
        }

    }
}