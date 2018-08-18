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
    public class ProgramaController : System.Web.Http.ApiController
    {
        ProgramaService programaService;
        public ProgramaController()
        {
            programaService = new ProgramaService();
        }

        [HttpPost]
        [ActionName("Login")]
        public ResultadoLogin login(ResultadoLogin obj)
        {
            try
            {
                return programaService.Login(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarProgramas")]
        public List<Programa_Response> BuscarProgramas(Programa_Request obj)
        {
            try
            {
                return programaService.BuscarProgramas(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [ActionName("PopUpPrograma")]
        public PopUp_Programa_Response PopUpPrograma(Programa_Request obj)
        {
            try
            {
                return programaService.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [ActionName("obtenerProyectosDisponibles")]
        public List<Proyecto_Response> obtenerProyectosDisponibles(Proyecto_Request obj)
        {
            try
            {
                return programaService.obtenerProyectosDisponibles(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        [HttpPost]
        [ActionName("AsociarProyecto")]
        public List<Programa_Proyectos> AsociarProyecto(AsociarProyecto_Request obj)
        {
            try
            {
                return programaService.AsociarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        [HttpPost]
        [ActionName("DesasociarProyecto")]
        public List<Programa_Proyectos> DesasociarProyecto(DesAsociarProyecto_Request obj)
        {
            try
            {
                return programaService.DesasociarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        [HttpPost]
        [ActionName("EliminarPrograma")]
        public EliminarPrograma_Response EliminarPrograma(EliminarPrograma_Request obj)
        {
            try
            {
                return programaService.EliminarPrograma(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ActionName("ActualizarPrograma")]
        public ActualizarPrograma_Response ActualizarPrograma(ActualizarPrograma_Request obj)
        {
            try
            {
                return programaService.ActualizarPrograma(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }


       


    }
}
