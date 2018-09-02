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
        PlanificarService PlanificarService;
        public PlanificarController()
        {
            PlanificarService = new PlanificarService();
        }

        [HttpPost]
        [ActionName("Login")]
        public ResultadoLogin login(ResultadoLogin obj)
        {
            try
            {
                return PlanificarService.Login(obj);
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
                return PlanificarService.GenerarTarea(obj);
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
                return PlanificarService.BuscarMonitoreos(obj);
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
                return PlanificarService.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }

        }
        [HttpPost]
        [ActionName("PopUpTarea")]
        public PopUp_Tarea_Response PopUpPlanificar(Tarea_Request obj)
        {
            try
            {
                return PlanificarService.DatosPopUp(obj);
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
                return PlanificarService.EliminarTarea(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}