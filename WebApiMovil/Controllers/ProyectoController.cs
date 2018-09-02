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
    public class ProyectoController : System.Web.Http.ApiController
    {
        ProyectoService proyectoService;
        public ProyectoController()
        {
            proyectoService = new ProyectoService();
        }

        [HttpPost]
        [ActionName("Login")]
        public ResultadoLogin login(ResultadoLogin obj)
        {
            try
            {
                return proyectoService.Login(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarProyectos")]
        public List<ProyectoI_Response> BuscarProyectos(ProyectoI_Request obj)
        {
            try
            {
                return proyectoService.BuscarProyectos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }


           [HttpPost]
        [ActionName("EliminarProyecto")]
        public EliminarProyecto_Response EliminarProyecto(EliminarProyecto_Request obj)
        {
            try
            {
                return proyectoService.EliminarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ActionName("ActualizarProyecto")]
        public ActualizarProyecto_Response ActualizarProyecto(ActualizarProyecto_Request obj)
        {
            try
            {
                return proyectoService.ActualizarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        [ActionName("PopUpProyecto")]
        public PopUp_Proyecto_Response PopUpProyecto(ProyectoI_Request obj)
        {
            try
            {
                return proyectoService.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
