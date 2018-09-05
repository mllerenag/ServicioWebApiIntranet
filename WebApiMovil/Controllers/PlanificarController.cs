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
    public class PlanificarController : System.Web.Http.ApiController
    {
        PlanificarService planificarService;
        public PlanificarController()
        {
            planificarService = new PlanificarService();
        }

        [HttpPost]
        [ActionName("Login")]
        public ResultadoLogin login(ResultadoLogin obj)
        {
            try
            {
                return planificarService.Login(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("GenerarTarea")]
        public GenerarTarea_Response GenerarTarea(GenerarTarea_Req obj)
        {
            try
            {
                return planificarService.GenerarTarea(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
         
        [HttpPost]
        [ActionName("BuscarMonitoreos")]
        public List<Monitoreo_Response> BuscarMonitoreos(Monitoreo_Request obj)
        {
            try
            {
                return planificarService.BuscarMonitoreos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarProyectosPortafolio")]
        public List<ProyectosPortafolio_Response> BuscarProyectosPortafolio(ProyectosPortafolio_Request obj)
        {
            try
            {
                return planificarService.BuscarProyectosPortafolio(obj);
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
                return planificarService.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ActionName("PopUpPlanificar")]
        public PopUp_Tarea_Response PopUpPlanificar(Tarea_Request obj)
        {
            try
            {
                return planificarService.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EliminarTarea")]
        public EliminarTarea_Response EliminarTarea(EliminarTarea_Request obj)
        {
            try
            {
                return planificarService.EliminarTarea(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
