using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApi.Controllers
{
    public class SolicitudController : System.Web.Http.ApiController
    {
        SolicitudService solicitudService;
        public SolicitudController()
        {
            solicitudService = new SolicitudService();
        }
    }
}