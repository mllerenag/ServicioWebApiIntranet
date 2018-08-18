using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class PortafolioBL
    {
        private PortafolioDA portafolioDA;
        private AsignarDA asignarDA;

        public PortafolioBL()
        {
            asignarDA = new AsignarDA();
            portafolioDA = new PortafolioDA();
        }

        public ResultadoLogin Login(ResultadoLogin obj)
        {
            try
            {
                return portafolioDA.Login(obj);
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
                if (obj.codigo == null) obj.codigo = "";
                if (obj.nombre == null) obj.nombre = "";
                if (obj.categoria == null) obj.categoria = "";
                if (obj.fecha_creacion_ini == null) obj.fecha_creacion_ini = "";
                if (obj.fecha_creacion_fin == null) obj.fecha_creacion_fin = "";
                return portafolioDA.BuscarPortafolios(obj);
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
                Prt_Balanceo retorno = new Prt_Balanceo();
                retorno.recursos = portafolioDA.BuscarRecursos(obj);
                retorno.solicitudes = portafolioDA.BuscarSolicitudes(obj);
                retorno.datos = portafolioDA.ObtenerPortafolio(obj);

                return retorno;
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
                if (obj.no_nombre == null) obj.no_nombre = ""; 
                return portafolioDA.obtenerResponsables(obj);
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
                return portafolioDA.BuscarCategorias();
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
                return portafolioDA.EliminarPortafolio(obj);
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
                if (obj.tx_descripcion == null) obj.tx_descripcion = "";
                return portafolioDA.ActualizarPortafolio(obj);
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
                if (obj.no_nombre == null) obj.no_nombre = ""; 
                return portafolioDA.obtenerIniciativasDisponibles(obj);
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
                if (obj.no_nombre == null) obj.no_nombre = "";
                return portafolioDA.obtenerComponentesDisponibles(obj);
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
                Portafolio_Request req = new Portafolio_Request();
                req.codigo_portafolio = obj.nid_portafolio;
                portafolioDA.AsociarComponente(obj);
                return portafolioDA.ObtenerComponentes(req);
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
                Portafolio_Request req = new Portafolio_Request();
                req.codigo_portafolio = obj.nid_portafolio;
                portafolioDA.DesasociarComponente(obj);
                return portafolioDA.ObtenerComponentes(req);
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
                Portafolio_Request req = new Portafolio_Request();
                req.codigo_portafolio = obj.nid_portafolio;
                portafolioDA.AsociarIniciativa(obj);
                return portafolioDA.ObtenerIniciativas(req);
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
                Portafolio_Request req = new Portafolio_Request();
                req.codigo_portafolio = obj.nid_portafolio;
                portafolioDA.DesasociarIniciativa(obj);
                return portafolioDA.ObtenerIniciativas(req);
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
                Prt_Response retorno = new Prt_Response();
                Portafolio_Request param = new Portafolio_Request();
                param.codigo_portafolio = int.Parse(obj.portafolio);
                List<Prt_Solicitud> solicitudes = portafolioDA.BuscarSolicitudes(param);
                List<Prt_Recurso> recursos = portafolioDA.BuscarRecursos(param);
                List<Prt_BalanceoTmp> balanceotmp = new List<Prt_BalanceoTmp>();
                List<Prt_Solicitud> solicitudes_tmp = new List<Prt_Solicitud>();
                Prt_BalanceoTmp objtemp = new Prt_BalanceoTmp();
                string msj = "";
                int x = 0;
                while (x < obj.lista_parametros.Count)
                {
                    objtemp = new Prt_BalanceoTmp();
                    objtemp.solicitud = int.Parse(obj.lista_parametros[x]);
                    x++;
                    objtemp.configurado = int.Parse(obj.lista_parametros[x]);
                    x++;
                    balanceotmp.Add(objtemp);
                    
                }
                int numero = 0;
                foreach (Prt_Recurso rec in recursos)
                {
                    solicitudes_tmp = solicitudes.Where(y => y.nid_recurso.Equals(rec.nid_recurso)).ToList<Prt_Solicitud>();
                    numero = 0;
                    foreach (Prt_Solicitud sol in solicitudes_tmp)
                    {
                        foreach (Prt_BalanceoTmp tmp in balanceotmp)
                        {
                            if(tmp.solicitud.Equals(sol.nid_solicitud))
                            {
                                if (tmp.configurado > sol.nu_solicitado)
                                {
                                    msj = "Se esta asignando, mas de lo solicitado para: " + sol.co_solicitud;
                                    break;
                                }
                                if (sol.nid_solicitud.Equals(tmp.solicitud))
                                {
                                    numero += tmp.configurado;
                                }
                            }
                        }
                    }

                    if (solicitudes_tmp.Count > 0)
                    {
                        if (rec.nu_recursodisponible < numero)
                        {
                            msj = "No existen Recursos Disponibles para recurso: " + rec.no_nombre;
                            break;
                        }
                    }
                }

                if (msj.Equals(""))
                {
                    int pk = portafolioDA.RegistrarBalanceo(int.Parse(obj.id_user));
                    foreach (Prt_BalanceoTmp tmp in balanceotmp)
                    {
                        portafolioDA.RegistrarBalanceoDetalle(tmp,pk,int.Parse(obj.id_user));
                    }

                    retorno.resultado = 1;
                    retorno.mensaje = "La Propuesta de Balanceo se realizó correctamente";
                }
                else
                {
                    retorno.resultado = 0;
                    retorno.mensaje = msj;
                }

                return retorno;
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
                PopUp_Portafolio_Response response = new PopUp_Portafolio_Response();
                response.cbo_categoria = portafolioDA.BuscarCategorias();
                response.cbo_prioridad = portafolioDA.BuscarPrioridades();
                response.objeto =  portafolioDA.ObtenerPortafolio(obj);
                response.iniciativas = portafolioDA.ObtenerIniciativas(obj);
                response.componentes = portafolioDA.ObtenerComponentes(obj);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}