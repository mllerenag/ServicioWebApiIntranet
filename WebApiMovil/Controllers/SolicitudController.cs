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

        [HttpPost]
        [ActionName("Login")]
        public ResultadoLogin login(ResultadoLogin obj)
        {
            try
            {
                return solicitudService.Login(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("GenerarSolicitud")]
        public GenerarSolicitud_Response GenerarSolicitud(GenerarSolicitud_Request obj)
        {
            try
            {
                return solicitudService.GenerarSolicitud(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
         

        [HttpPost]
        [ActionName("BuscarSolicitudes")]
        public List<Solicitud_Response> BuscarSolicitudes(Solicitud_Request obj)
        {
            try
            {
                return solicitudService.BuscarSolicitudes(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("CargarFiltroGestion")]
        public List<Combo> CargarFiltroGestion()
        {
            try
            {
                return solicitudService.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        [ActionName("PopUpPrograma")]
        public PopUp_Solicitud_Response PopUpSolicitud(Solicitud_Request obj)
        {
            try
            {
                return solicitudService.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarSolicitud")]
        public EliminarSolicitud_Response EliminarSolicitud(EliminarSolicitud_Request obj)
        {
            try
            {
                return solicitudService.EliminarSolicitud(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}