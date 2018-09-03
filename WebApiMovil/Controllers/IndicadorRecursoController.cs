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
    public class IndicadorRecursoController : System.Web.Http.ApiController
    {
        IndicadorRecursoService indicador_recursoService;
        public IndicadorRecursoController()
        {
            indicador_recursoService = new IndicadorRecursoService();
        }

        [HttpPost]
        [ActionName("CargarFiltroGestion")]
        public Filtros_Indicador_Recurso_Response CargarFiltroGestion()
        {
            try
            {
                return indicador_recursoService.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerComponentesPorPortafolio")]
        public List<Combo> ObtenerComponentesPorPortafolio(Portafolio_Request entidad)
        {
            try
            {
                return indicador_recursoService.ObtenerComponentesPorPortafolio(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerDataGrafico")]
        public Data_Indicador_Recurso_Response ObtenerDataGrafico(Data_Indicador_Recurso_Request entidad)
        {
            try
            {
                return indicador_recursoService.ObtenerDataGrafico(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("ObtenerDataGrafico_Componente")]
        public Data_Indicador_Recurso_Componente_Response ObtenerDataGrafico_Componente(Data_Indicador_Recurso_Request entidad)
        {
            try
            {
                return indicador_recursoService.ObtenerDataGrafico_Componente(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
