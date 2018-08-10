using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class SolicitudBL
    {
        private SolicitudDA solicitudDA;

        public SolicitudBL()
        {
            solicitudDA = new SolicitudDA();
        }

    }
}