using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class IndicadorRecursoBL
    {
        private PortafolioBL portafolioBL;
        private SolicitudBL solicitudBL;
        private SolicitudDA solicitudDA;
        private IndicadorRecursoDA indicador_recursoDA;
        public IndicadorRecursoBL()
        {
            portafolioBL = new PortafolioBL();
            solicitudBL = new SolicitudBL();
            solicitudDA = new SolicitudDA();
            indicador_recursoDA = new IndicadorRecursoDA();
        }

        public Filtros_Indicador_Recurso_Response CargarFiltroGestion()
        {
            try
            {
                Filtros_Indicador_Recurso_Response resp = new Filtros_Indicador_Recurso_Response();
                Portafolio_Request req_portafolios = new Portafolio_Request();
                List<Portafolio_Response> portafolios = portafolioBL.BuscarPortafolios(req_portafolios);
                resp.recursos = solicitudDA.BuscarRecursos();
                resp.portafolios = new List<Combo>();
                Combo cbotmp = new Combo();
                foreach (Portafolio_Response obj in portafolios)
                {
                    cbotmp = new Combo();
                    cbotmp.codigo = obj.codigo_portafolio;
                    cbotmp.nombre = obj.nombre;
                    resp.portafolios.Add(cbotmp);
                }

                return resp;
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
                List<Portafolio_Componentes> componentes = portafolioBL.ObtenerComponentes(entidad);
                List<Combo> retorno = new List<Combo>();
                Combo cbotmp = new Combo();
                foreach (Portafolio_Componentes obj in componentes)
                {
                    cbotmp = new Combo();
                    cbotmp.codigo = obj.nid_componente;
                    cbotmp.nombre = obj.no_componente;
                    retorno.Add(cbotmp);
                }
                return retorno;
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
                Data_Indicador_Recurso_Response obj = new Data_Indicador_Recurso_Response();
                if (entidad.portafolios == null) entidad.portafolios = "";
                if (entidad.recursos == null) entidad.recursos = "";
                obj.lista = indicador_recursoDA.ObtenerDataGrafico(entidad);
                return obj;
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
                Data_Indicador_Recurso_Componente_Response obj = new Data_Indicador_Recurso_Componente_Response();
                if (entidad.portafolios == null) entidad.portafolios = "";
                if (entidad.recursos == null) entidad.recursos = "";
                obj.lista = indicador_recursoDA.ObtenerDataGrafico_Componente(entidad);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}