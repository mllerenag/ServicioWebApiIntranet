using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class ProyectoBL
    {
        private ProyectoDA proyectoDA;

        public ProyectoBL()
        {
            proyectoDA = new ProyectoDA();
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return proyectoDA.Login(obj);
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
                if (obj.codigo == null) obj.codigo = "";
                if (obj.nombre == null) obj.nombre = "";
                if (obj.fecha_creacion_ini == null) obj.fecha_creacion_ini = "";
                if (obj.fecha_creacion_fin == null) obj.fecha_creacion_fin = "";
                return proyectoDA.BuscarProyectos(obj);
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
                return proyectoDA.EliminarProyecto(obj);
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
                if (obj.tx_descripcion == null) obj.tx_descripcion = "";
                return proyectoDA.ActualizarProyecto(obj);
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
                PortafolioDA portafolioDA = new PortafolioDA();
                PopUp_Proyecto_Response response = new PopUp_Proyecto_Response();
                response.cbo_prioridad = portafolioDA.BuscarPrioridades();
                response.objeto = proyectoDA.ObtenerProyecto(obj);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }


  

    }
}
