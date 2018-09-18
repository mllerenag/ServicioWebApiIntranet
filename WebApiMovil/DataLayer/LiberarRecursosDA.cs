using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiMovil.Models;

namespace WebApiMovil.DataLayer
{
    public class LiberarRecursosDA
    {
        public List<PortafolioLiberar_Response> BuscarPortafolios(PortafolioLiberar_Request entidad)
        {
            List<PortafolioLiberar_Response> retorno = null;
            PortafolioLiberar_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolio_liberar]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_codigo", entidad.codigo);
                        command.Parameters.AddWithValue("@vi_nombre", entidad.nombre);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<PortafolioLiberar_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new PortafolioLiberar_Response();
                                    tmp.codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.descripcion = dr.GetString(dr.GetOrdinal("tx_descripcion"));

                                    tmp.fecha_creacion = dr.GetString(dr.GetOrdinal("fecha_creacion"));

                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("prioridad"));
                                    tmp.categoria = dr.GetString(dr.GetOrdinal("categoria"));
                                    tmp.responsable = dr.GetString(dr.GetOrdinal("responsable"));
                                    tmp.codigo_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<PortafolioLiberar_Response>();
                            }
                        }

                    }
                    conection.Close();
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<RecursolioLiberar_Response> BuscarRecursos(PortafolioLiberar_Request entidad)
        {
            List<RecursolioLiberar_Response> retorno = null;
            RecursolioLiberar_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolio_recursos_a_liberar]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nid_portafolio", entidad.codigo_portafolio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<RecursolioLiberar_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new RecursolioLiberar_Response();

                                    tmp.codigo_recurso = dr.GetInt32(dr.GetOrdinal("nid_recurso"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.total = dr.GetInt32(dr.GetOrdinal("nu_recursototal"));
                                    tmp.adicional = dr.GetInt32(dr.GetOrdinal("nu_recursoadicional"));
                                    
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<RecursolioLiberar_Response>();
                            }
                        }

                    }
                    conection.Close();
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<ComponenteCerrado_Response> BuscarComponentesCerrados(PortafolioLiberar_Request entidad)
        {
            List<ComponenteCerrado_Response> retorno = null;
            ComponenteCerrado_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolio_componentes_cerrados]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nid_portafolio", entidad.codigo_portafolio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<ComponenteCerrado_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new ComponenteCerrado_Response();

                                    tmp.codigo_componente = dr.GetInt32(dr.GetOrdinal("nid_componente"));

                                    tmp.codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("componente"));
                                    tmp.tipo_componente = dr.GetInt32(dr.GetOrdinal("tipo_componente"));
                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("prioridad"));

                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<ComponenteCerrado_Response>();
                            }
                        }

                    }
                    conection.Close();
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<RecursosComponente_Response> BuscarRecursosComponente(PortafolioLiberar_Request entidad)
        {
            List<RecursosComponente_Response> retorno = null;
            RecursosComponente_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolio_componente_recurso_disponible]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nid_portafolio", entidad.codigo_portafolio);
                        command.Parameters.AddWithValue("@filtro", entidad.tipo_filtro);
                        command.Parameters.AddWithValue("@nid_filtro", entidad.codigo_filtro);
                        
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<RecursosComponente_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new RecursosComponente_Response();

                                    tmp.codigo_componente = dr.GetInt32(dr.GetOrdinal("nid_componente"));
                                    tmp.componente = dr.GetString(dr.GetOrdinal("componente"));
                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("prioridad"));
                                    tmp.codigo_recurso = dr.GetInt32(dr.GetOrdinal("nid_recurso"));
                                    tmp.recurso = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.total_recurso = dr.GetInt32(dr.GetOrdinal("nu_recursototal"));
                                    
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<RecursosComponente_Response>();
                            }
                        }

                    }
                    conection.Close();
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public LiberarRecursoComponente_Response LiberarRecursoComponente(LiberarRecursoComponente_Request entidad)
        {
            LiberarRecursoComponente_Response retorno = new LiberarRecursoComponente_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spt_portafolio_liberar_recurso]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nid_portafolio", entidad.nid_portafolio);
                        command.Parameters.AddWithValue("@nid_componente", entidad.nid_componente);
                        command.Parameters.AddWithValue("@nid_recurso", entidad.nid_recurso);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if ((dr.GetInt32(dr.GetOrdinal("nid_retorno")) > 0))
                                    {
                                        retorno.respuesta = 1;
                                        retorno.str_mensaje = "";
                                    }
                                    else
                                    {
                                        retorno.respuesta = 0;
                                        retorno.str_mensaje = "No se pudo liberar el componente, debido a que el componentes esta en ejecución";
                                    }
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}