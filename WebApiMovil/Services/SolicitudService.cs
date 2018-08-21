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

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return solicitudBL.Login(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Solicitud_Response> BuscarSolicitudes(Solicitud_Request obj)
        {
            try
            {
                return solicitudBL.BuscarSolicitudes(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenerarSolicitud_Response GenerarSolicitud(GenerarSolicitud_Request obj)
        {
            try
            {
                return solicitudBL.GenerarSolicitud(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PopUp_Solicitud_Response DatosPopUp(Solicitud_Request obj)
        {
            try
            {
                return solicitudBL.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Combo> CargarFiltroGestion()
        {
            try
            {
                return solicitudBL.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EliminarSolicitud_Response EliminarSolicitud(EliminarSolicitud_Request obj)
        {
            try
            {
                return solicitudBL.EliminarSolicitud(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}