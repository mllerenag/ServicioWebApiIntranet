using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class ProyectoService
    {

        private ProyectoBL proyectoBL;

        public ProyectoService()
        {
            proyectoBL = new ProyectoBL();
 
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return proyectoBL.Login(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ProyectoI_Response> BuscarProyectos(ProyectoI_Request obj)
        {
            try
            {
                return proyectoBL.BuscarProyectos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public EliminarProyecto_Response EliminarProyecto(EliminarProyecto_Request obj)
        {
            try
            {
                return proyectoBL.EliminarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActualizarProyecto_Response ActualizarProyecto(ActualizarProyecto_Request obj)
        {
            try
            {
                return proyectoBL.ActualizarProyecto(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public PopUp_Proyecto_Response DatosPopUp(ProyectoI_Request obj)
        {
            try
            {
                return proyectoBL.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
