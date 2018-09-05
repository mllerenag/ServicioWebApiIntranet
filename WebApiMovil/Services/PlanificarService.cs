using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class PlanificarService
    {
        private PlanificarBL PlanificarBL;

        public PlanificarService()
        {
            PlanificarBL = new PlanificarBL();
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return PlanificarBL.Login(obj);
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
                return PlanificarBL.BuscarMonitoreos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ProyectosPortafolio_Response> BuscarProyectosPortafolio(ProyectosPortafolio_Request obj)
        {
            try
            {
                return PlanificarBL.BuscarProyectosPortafolio(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenerarMonitoreo_Response GenerarMonitoreo(GenerarMonitoreo_Request obj)
        {
            try
            {
                return PlanificarBL.GenerarMonitoreo(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GenerarTarea_Response GenerarTarea(GenerarTarea_Req obj)
        {
            try
            {
                return PlanificarBL.GenerarTarea(obj);
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
                return PlanificarBL.DatosPopUp(obj);
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
                return PlanificarBL.CargarFiltroGestion();
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
                return PlanificarBL.EliminarTarea(obj);
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
                return PlanificarBL.EditarTarea(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
