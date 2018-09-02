using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class PlanificarBL
    {
        private PlanificarDA planificarDA;

        public PlanificarBL()
        {
            planificarDA = new PlanificarDA();
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return planificarDA.Login(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Monitoreo_Response> BuscarMonitoreos(Monitoreo_Request obj)
        {
            try
            {
                if (obj.co_proyecto == null) obj.co_proyecto = "";
                if (obj.co_portafolio == null) obj.co_portafolio = "";
                if (obj.categoria == null) obj.categoria = "";
                return planificarDA.BuscarMonitoreos(obj);
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
                return planificarDA.BuscarNivel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EditarTarea_Response EditarTarea(EditarTarea_Req obj)
        {
            try
            {
                return planificarDA.EditarTarea(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public EliminarTarea_Response EliminarTarea(EliminarTarea_Request obj)
        {
            try
            {
                return planificarDA.EliminarTarea(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public PopUp_Tarea_Response DatosPopUp(Tarea_Request obj)
        {
            try
            {
                //PortafolioDA portafolioDA = new PortafolioDA();
                PopUp_Tarea_Response response = new PopUp_Tarea_Response();
                response.cbo_nivel = planificarDA.BuscarNivel();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenerarTarea_Response GenerarTarea(GenerarTarea_Req entidad)
        {
            try
            {
                GenerarTarea_Response response = new GenerarTarea_Response();
                string texto = "";

                response = planificarDA.GenerarTarea(entidad);
                if (response.respuesta == 0)
                    return response;
                else
                    texto = response.str_mensaje + "<br>" + texto;

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenerarMonitoreo_Response GenerarMonitoreo(GenerarMonitoreo_Request entidad)
        {
            try
            {
                GenerarMonitoreo_Response response = new GenerarMonitoreo_Response();
                string texto = "";
                response = planificarDA.GenerarMonitoreo(entidad);
                if (response.respuesta == 0)
                    return response;
                else
                    texto = response.str_mensaje + "<br>" + texto;

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}