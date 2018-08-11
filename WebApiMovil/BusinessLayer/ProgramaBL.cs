using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class ProgramaBL
    {
        private ProgramaDA programaDA;
        private AsignarDA asignarDA;

        public ProgramaBL()
        {
            asignarDA = new AsignarDA();
            programaDA = new ProgramaDA();
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return programaDA.Login(obj);
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
                if (obj.codigo == null) obj.codigo = "";
                if (obj.nombre == null) obj.nombre = "";
                if (obj.fecha_creacion_ini == null) obj.fecha_creacion_ini = "";
                if (obj.fecha_creacion_fin == null) obj.fecha_creacion_fin = "";
                return programaDA.BuscarProgramas(obj);
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
                return programaDA.EliminarPrograma(obj);
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
                if (obj.tx_descripcion == null) obj.tx_descripcion = "";
                return programaDA.ActualizarPrograma(obj);
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
                if (obj.no_nombre == null) obj.no_nombre = "";
                return programaDA.obtenerProyectosDisponibles(obj);
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
                Programa_Request req = new Programa_Request();
                req.codigo_programa = obj.nid_programa;
                programaDA.AsociarProyecto(obj);
                return programaDA.ObtenerProyectos(req);
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
                Programa_Request req = new Programa_Request();
                req.codigo_programa = obj.nid_programa;
                programaDA.DesasociarProyecto(obj);
                return programaDA.ObtenerProyectos(req);
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
                PortafolioDA portafolioDA = new PortafolioDA();
                PopUp_Programa_Response response = new PopUp_Programa_Response();
                response.cbo_prioridad = portafolioDA.BuscarPrioridades();
                response.objeto = programaDA.ObtenerPrograma(obj);
                response.proyectos = programaDA.ObtenerProyectos(obj);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
