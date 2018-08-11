using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class ProgramaService
    {

        private ProgramaBL programaBL;

        public ProgramaService()
        {
            programaBL = new ProgramaBL();
 
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return programaBL.Login(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Programa_Response> BuscarProgramas(Programa_Request obj)
        {
            try
            {
                return programaBL.BuscarProgramas(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

         public PopUp_Programa_Response DatosPopUp(Programa_Request obj)
        {
            try
            {
                return programaBL.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Proyecto_Response> obtenerProyectosDisponibles(Proyecto_Request obj)
        {
            try
            {
                return programaBL.obtenerProyectosDisponibles(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Programa_Proyectos> AsociarProyecto(AsociarProyecto_Request obj)
        {
            try
            {
                return programaBL.AsociarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Programa_Proyectos> DesasociarProyecto(DesAsociarProyecto_Request obj)
        {
            try
            {
                return programaBL.DesasociarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public EliminarPrograma_Response EliminarPrograma(EliminarPrograma_Request obj)
        {
            try
            {
                return programaBL.EliminarPrograma(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActualizarPrograma_Response ActualizarPrograma(ActualizarPrograma_Request obj)
        {
            try
            {
                return programaBL.ActualizarPrograma(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
