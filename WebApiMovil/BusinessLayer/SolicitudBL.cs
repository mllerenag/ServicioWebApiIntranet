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

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return solicitudDA.Login(obj);
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
                if (obj.codigo == null) obj.codigo = "";
                if (obj.recurso == null) obj.recurso = "";
                if (obj.portafolio == null) obj.portafolio = "";
                if (obj.componente == null) obj.componente = "";
                return solicitudDA.BuscarSolicitudes(obj);
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
                return solicitudDA.BuscarRecursos();
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
                return solicitudDA.EliminarSolicitud(obj);
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
                PortafolioDA portafolioDA = new PortafolioDA();
                PopUp_Solicitud_Response response = new PopUp_Solicitud_Response();
                response.cbo_prioridad = portafolioDA.BuscarPrioridades();
                //response.objeto = SolicitudDA.ObtenerPrograma(obj);
                //response.proyectos = SolicitudDA.ObtenerProyectos(obj);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenerarSolicitud_Response GenerarSolicitud(GenerarSolicitud_Request entidad)
        {
            try
            {
                GenerarSolicitud_Response response = new GenerarSolicitud_Response();
                string texto = "";
                List<GenerarSolicitud_Req> lista = entidad.lista;
                foreach (GenerarSolicitud_Req tmp in lista)
                {
                    if (tmp.show)
                    {
                        response = solicitudDA.GenerarSolicitud(tmp);
                        if (response.respuesta == 0)
                            return response;
                        else
                            texto = response.str_mensaje + "<br>" + texto;
                    }
                }
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}