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
    public class PortafolioController : System.Web.Http.ApiController
    {
        AsignarService asignarService;
        PortafolioService portafolioService;
        public PortafolioController()
        {
            asignarService = new AsignarService();
            portafolioService = new PortafolioService();
        }

        [HttpPost]
        [ActionName("Login")]
        public ResultadoLogin login(ResultadoLogin obj)
        {
            try
            {
                return portafolioService.Login(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarPortafolios")]
        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                return portafolioService.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("obtenerDatos")]
        public Prt_Balanceo obtenerDatos(Portafolio_Request obj)
        {
            try
            {
                return portafolioService.obtenerDatos(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("PopUpPortafolio")]
        public PopUp_Portafolio_Response PopUpPortafolio(Portafolio_Request obj)
        {
            try
            {
                return portafolioService.DatosPopUp(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("obtenerResponsables")]
        public List<Responsable_Response> obtenerResponsables(Responsable_Request obj)
        {
            try
            {
                return portafolioService.obtenerResponsables(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("obtenerIniciativasDisponibles")]
        public List<Iniciativa_Response> obtenerIniciativasDisponibles(Iniciativa_Request obj)
        {
            try
            {
                return portafolioService.obtenerIniciativasDisponibles(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        [HttpPost]
        [ActionName("AsociarIniciativa")]
        public List<Portafolio_Iniciativas> AsociarIniciativa(AsociarIniciativa_Request obj)
        {
            try
            {
                return portafolioService.AsociarIniciativa(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        [HttpPost]
        [ActionName("DesasociarIniciativa")]
        public List<Portafolio_Iniciativas> DesasociarIniciativa(DesAsociarIniciativa_Request obj)
        {
            try
            {
                return portafolioService.DesasociarIniciativa(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        [HttpPost]
        [ActionName("obtenerComponentesDisponibles")]
        public List<Componente_Response> obtenerComponentesDisponibles(Componente_Request obj)
        {
            try
            {
                return portafolioService.obtenerComponentesDisponibles(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        

        [HttpPost]
        [ActionName("AsociarIniciativa")]
        public List<Portafolio_Componentes> AsociarComponente(AsociarComponente_Request obj)
        {
            try
            {
                return portafolioService.AsociarComponente(obj);
            }
            catch (Exception)
            {
                throw;
            }
        
        }
        
        
        

        
        
        
        [HttpPost]
        [ActionName("realizarBalanceo")]
        public Prt_Response realizarBalanceo(Prt_Request obj)
        {
            try
            {
                return portafolioService.realizarBalanceo(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("DesasociarComponente")]
        public List<Portafolio_Componentes> DesasociarComponente(DesAsociarComponente_Request obj)
        {
            try
            {
                return portafolioService.DesasociarComponente(obj);
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
                return portafolioService.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ActionName("EliminarPortafolio")]
        public EliminarPortafolio_Response EliminarPortafolio(EliminarPortafolio_Request obj)
        {
            try
            {
                return portafolioService.EliminarPortafolio(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [ActionName("ActualizarPortafolio")]
        public ActualizarPortafolio_Response ActualizarPortafolio(ActualizarPortafolio_Request obj)
        {
            try
            {
                return portafolioService.ActualizarPortafolio(obj);
            }
            catch (Exception)
            {
                throw;
            }

        }

        //[Authorize]
        [HttpPost]
        [ActionName("ListadoEquiposAsignados")]
        public List<Asignacion> ListadoEquiposAsignados(Asignacion entidad)
        {
            try
            {
                return asignarService.ListadoEquiposAsignados(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarDepartamento")]
        public List<Ubigeo> ListarDepartamento()
        {
            try
            {
                return asignarService.ListarDepartamento();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarProvincia")]
        public List<Ubigeo> ListarProvincia(Ubigeo entidad)
        {
            try
            {
                return asignarService.ListarProvincia(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarDistrito")]
        public List<Ubigeo> ListarDistrito(Ubigeo entidad)
        {
            try
            {
                return asignarService.ListarDistrito(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarResponsablePorDni")]
        public Responsable BuscarResponsablePorDni(Responsable entidad)
        {
            try
            {
                return asignarService.BuscarResponsablePorDni(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ListarPlanes")]
        public List<Plan> ListarPlanes()
        {
            try
            {
                return asignarService.ListarPlanes();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerEquipoPorIMEI")]
        public Equipo ObtenerEquipoPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarService.ObtenerEquipoPorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarTrabajador")]
        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            try
            {
                return asignarService.BuscarTrabajador(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerAccesorioPorIMEI")]
        public List<Accesorio> ObtenerAccesorioPorIMEI(Equipo entidad)
        {
            try
            {
                return asignarService.ObtenerAccesorioPorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerPlanPorNroCelular")]
        public Plan ObtenerPlanPorNroCelular(Plan entidad)
        {
            try
            {
                return asignarService.ObtenerPlanPorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("AccesorioCRUD")]
        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                return asignarService.AccesorioCRUD(entidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("AsignacionCRUD")]
        public Asignacion AsignacionCRUD(Asignacion entidad)
        {
            try
            {
                return asignarService.AsignacionCRUD(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerAsignacionPorId")]
        public Asignacion ObtenerAsignacionPorId(Asignacion entidad)
        {
            try
            {
                return asignarService.ObtenerAsignacionPorId(entidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerImgPorAccesorio")]
        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad)
        {
            try
            {
                return asignarService.ObtenerImgPorAccesorio(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerEquipoDisponiblePorIMEI")]
        public List<Equipo> ObtenerEquiposDisponiblePorIMEI(Equipo entidad)
        {
            try
            {
                return asignarService.ObtenerEquiposDisponiblePorIMEI(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerCelulareDisponiblePorNroCelular")]
        public List<Plan> ObtenerCelulareDisponiblePorNroCelular(Plan entidad)
        {
            try
            {
                return asignarService.ObtenerCelulareDisponiblePorNroCelular(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}