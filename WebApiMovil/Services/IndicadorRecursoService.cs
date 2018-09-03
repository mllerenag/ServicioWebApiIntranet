using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class IndicadorRecursoService
    {
        private IndicadorRecursoBL indicador_recursoBL;

        public IndicadorRecursoService()
        {
            indicador_recursoBL = new IndicadorRecursoBL();
        }

        public Filtros_Indicador_Recurso_Response CargarFiltroGestion()
        {
            try
            {
                return indicador_recursoBL.CargarFiltroGestion();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Combo> ObtenerComponentesPorPortafolio(Portafolio_Request entidad)
        {
            try
            {
                return indicador_recursoBL.ObtenerComponentesPorPortafolio(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Data_Indicador_Recurso_Response ObtenerDataGrafico(Data_Indicador_Recurso_Request entidad)
        {
            try
            {
                return indicador_recursoBL.ObtenerDataGrafico(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Data_Indicador_Recurso_Componente_Response ObtenerDataGrafico_Componente(Data_Indicador_Recurso_Request entidad)
        {
            try
            {
                return indicador_recursoBL.ObtenerDataGrafico_Componente(entidad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}