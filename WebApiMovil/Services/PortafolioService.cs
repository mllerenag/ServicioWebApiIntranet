using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class PortafolioService
    {
        private AsignarBL asignarBL;
        private PortafolioBL portafolioBL;

        public PortafolioService()
        {
            portafolioBL = new PortafolioBL();
            asignarBL = new AsignarBL();
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return portafolioBL.Login(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                return portafolioBL.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Portafolio_Componentes> ObtenerComponentes(Portafolio_Request obj)
        {
            try
            {
                return portafolioBL.ObtenerComponentes(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Prt_Balanceo obtenerDatos(Portafolio_Request obj)
        {
            try
            {
                return portafolioBL.obtenerDatos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PopUp_Portafolio_Response DatosPopUp(Portafolio_Request obj)
        {
            try
            {
                return portafolioBL.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Responsable_Response> obtenerResponsables(Responsable_Request obj)
        {
            try
            {
                return portafolioBL.obtenerResponsables(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Iniciativa_Response> obtenerIniciativasDisponibles(Iniciativa_Request obj)
        {
            try
            {
                return portafolioBL.obtenerIniciativasDisponibles(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Portafolio_Iniciativas> AsociarIniciativa(AsociarIniciativa_Request obj)
        {
            try
            {
                return portafolioBL.AsociarIniciativa(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Portafolio_Iniciativas> DesasociarIniciativa(DesAsociarIniciativa_Request obj)
        {
            try
            {
                return portafolioBL.DesasociarIniciativa(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public List<Componente_Response> obtenerComponentesDisponibles(Componente_Request obj)
        {
            try
            {
                return portafolioBL.obtenerComponentesDisponibles(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Portafolio_Componentes> AsociarComponente(AsociarComponente_Request obj)
        {
            try
            {
                return portafolioBL.AsociarComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Portafolio_Componentes> DesasociarComponente(DesAsociarComponente_Request obj)
        {
            try
            {
                return portafolioBL.DesasociarComponente(obj);
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
                return portafolioBL.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EliminarPortafolio_Response EliminarPortafolio(EliminarPortafolio_Request obj)
        {
            try
            {
                return portafolioBL.EliminarPortafolio(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActualizarPortafolio_Response ActualizarPortafolio(ActualizarPortafolio_Request obj)
        {
            try
            {
                return portafolioBL.ActualizarPortafolio(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Prt_Response realizarBalanceo(Prt_Request obj)
        {
            try
            {
                return portafolioBL.realizarBalanceo(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Asignacion> ListadoEquiposAsignados(Asignacion entidad)
        {
            try
            {
                return asignarBL.ListadoEquiposAsignados(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ubigeo> ListarDepartamento()
        {
            try
            {
                return asignarBL.ListarDepartamento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ubigeo> ListarProvincia(Ubigeo entidad)
        {
            try
            {
                return asignarBL.ListarProvincia(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ubigeo> ListarDistrito(Ubigeo entidad)
        {
            try
            {
                return asignarBL.ListarDistrito(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Responsable BuscarResponsablePorDni(Responsable entidad)
        {
            try
            {
                return asignarBL.BuscarResponsablePorDni(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Plan> ListarPlanes()
        {
            try
            {
                return asignarBL.ListarPlanes();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Equipo ObtenerEquipoPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarBL.ObtenerEquipoPorIMEI(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            try
            {
                return asignarBL.BuscarTrabajador(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Accesorio> ObtenerAccesorioPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarBL.ObtenerAccesorioPorIMEI(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Plan ObtenerPlanPorNroCelular(Plan entidad)
        {
            try
            {
                return asignarBL.ObtenerPlanPorNroCelular(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                return asignarBL.AccesorioCRUD(entidad);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Asignacion AsignacionCRUD(Asignacion entidad)
        {
            try
            {
                return asignarBL.AsignacionCRUD(entidad);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Asignacion ObtenerAsignacionPorId(Asignacion entidad)
        {
            try
            {
                return asignarBL.ObtenerAsignacionPorId(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad)
        {
            try
            {
                return asignarBL.ObtenerImgPorAccesorio(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Equipo> ObtenerEquiposDisponiblePorIMEI(Equipo entidad)
        {
            try
            {
                return asignarBL.ObtenerEquiposDisponiblePorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Plan> ObtenerCelulareDisponiblePorNroCelular(Plan entidad)
        {
            try
            {
                return asignarBL.ObtenerCelulareDisponiblePorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}