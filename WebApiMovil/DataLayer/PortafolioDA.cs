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
    public class PortafolioDA
    {
        public ResultadoLogin Login(ResultadoLogin entidad)
        {
            ResultadoLogin  retorno = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_loginusuario]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_usrlogin", entidad.user);
                        command.Parameters.AddWithValue("@vi_pwdlogin", entidad.pwd);
  
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                retorno = new ResultadoLogin();
                                while (dr.Read())
                                {
                                    if (dr.GetInt32(dr.GetOrdinal("resultado")) > 0)
                                    {
                                        retorno.user_code = dr.GetInt32(dr.GetOrdinal("resultado"));
                                        retorno.nid_perfil = dr.GetInt32(dr.GetOrdinal("dato"));
                                        retorno.nombreusuario = dr.GetString(dr.GetOrdinal("mensaje"));
                                    }
                                    else
                                    {
                                        retorno.user_code = 0;
                                        retorno.msj = dr.GetString(dr.GetOrdinal("mensaje"));
                                    }
                                }
                            }
                            else {
                                retorno.user_code = 0;
                                retorno.msj = "No se encontraron coincidencias";
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

        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request entidad)
        {
            List<Portafolio_Response> retorno = null;
            Portafolio_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolios]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_codigo", entidad.codigo);
                        command.Parameters.AddWithValue("@vi_nombre", entidad.nombre);
                        command.Parameters.AddWithValue("@vi_categoria", entidad.categoria);
                        command.Parameters.AddWithValue("@vi_fechaini", entidad.fecha_creacion_ini);
                        command.Parameters.AddWithValue("@vi_fechafin", entidad.fecha_creacion_fin);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Portafolio_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Portafolio_Response();
                                    tmp.codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.fecha_creacion = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.categoria = dr.GetString(dr.GetOrdinal("no_categoria"));
                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    tmp.codigo_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    tmp.co_estado = dr.GetString(dr.GetOrdinal("co_estado"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<Portafolio_Response>();
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


        public Prt_Datos ObtenerPortafolio(Portafolio_Request entidad)
        {
            Prt_Datos tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolioindividual]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.codigo_portafolio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Prt_Datos();
                                    tmp.nid_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    tmp.nid_prioridad = dr.GetInt32(dr.GetOrdinal("nid_prioridad"));
                                    tmp.nid_categoria = dr.GetInt32(dr.GetOrdinal("nid_categoria"));
                                    tmp.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.fe_crea = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.no_categoria = dr.GetString(dr.GetOrdinal("no_categoria"));
                                    tmp.no_prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.no_responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    tmp.no_responsable2= dr.GetString(dr.GetOrdinal("no_responsable2"));
                                    tmp.nid_responsable = dr.GetInt32(dr.GetOrdinal("nid_responsable"));
                                    tmp.nid_responsable2 = dr.GetInt32(dr.GetOrdinal("nid_responsable2"));
                                    tmp.no_estado = dr.GetString(dr.GetOrdinal("no_estado"));
                                    tmp.tx_descripcion = dr.GetString(dr.GetOrdinal("tx_descripcion"));
                                }
                            }
                            else
                            {
                                tmp = new Prt_Datos();
                            }
                        }

                    }
                    conection.Close();
                }
                return tmp;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Prt_Solicitud> BuscarSolicitudes(Portafolio_Request entidad)
        {
            List<Prt_Solicitud> retorno = null;
            Prt_Solicitud tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafoliosolicitudes]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.codigo_portafolio);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Prt_Solicitud>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Prt_Solicitud();
                                    tmp.nid_solicitud = dr.GetInt32(dr.GetOrdinal("nid_solicitud"));
                                    tmp.nid_recurso = dr.GetInt32(dr.GetOrdinal("nid_recurso"));
                                    tmp.no_recurso = dr.GetString(dr.GetOrdinal("no_recurso"));
                                    tmp.co_solicitud = dr.GetString(dr.GetOrdinal("co_solicitud"));
                                    tmp.fe_solicitud = dr.GetString(dr.GetOrdinal("fe_solicitud"));
                                    tmp.no_componente = dr.GetString(dr.GetOrdinal("no_componente"));
                                    tmp.no_prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.no_tipo_recurso = dr.GetString(dr.GetOrdinal("no_tipo_recurso"));
                                    tmp.nu_solicitado = dr.GetInt32(dr.GetOrdinal("nu_solicitado"));
                                    tmp.nu_recomendado = dr.GetInt32(dr.GetOrdinal("nu_recursorecomendado"));
                                    
                                    tmp.nu_recursodisponible = dr.GetInt32(dr.GetOrdinal("nu_recursodisponible"));
                                    tmp.nu_recursototal = dr.GetInt32(dr.GetOrdinal("nu_recursototal"));
                                    retorno.Add(tmp);

                                }
                            }
                            else
                            {
                                retorno = new List<Prt_Solicitud>();
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

        public List<Prt_Recurso> BuscarRecursos(Portafolio_Request entidad)
        {
            List<Prt_Recurso> retorno = null;
            Prt_Recurso tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafoliorecursos]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.codigo_portafolio);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Prt_Recurso>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Prt_Recurso();
                                    tmp.nid_recurso = dr.GetInt32(dr.GetOrdinal("nid_recurso"));
                                    tmp.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.nu_separado = dr.GetInt32(dr.GetOrdinal("nu_separado"));
                                    tmp.nu_recursototal = dr.GetInt32(dr.GetOrdinal("nu_recursototal"));
                                    tmp.nu_recursoconsumido = dr.GetInt32(dr.GetOrdinal("nu_recursoconsumido"));
                                    tmp.nu_recursodisponible = dr.GetInt32(dr.GetOrdinal("nu_recursodisponible"));
                                    retorno.Add(tmp);

                                }
                            }
                            else
                            {
                                retorno = new List<Prt_Recurso>();
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

        public int RegistrarBalanceo(int id_user)
        {
            int retorno = 0;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_registrarBalanceo]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_usuario", id_user);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    retorno = dr.GetInt32(dr.GetOrdinal("nid_retorno"));
                                }
                            }
                            else
                            {
                                retorno = 0;
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

        public void RegistrarBalanceoDetalle(Prt_BalanceoTmp obj, int pk, int id_user)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_registrarBalanceoDetalle]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_balanceo", pk);
                        command.Parameters.AddWithValue("@vi_nid_solicitud", obj.solicitud);
                        command.Parameters.AddWithValue("@vi_nu_asignado", obj.configurado);
                        //command.Parameters.AddWithValue("@vi_nid_usuario", id_user);
                        
                        using (SqlDataReader dr = command.ExecuteReader())
                        {

                        }
      
                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Combo> BuscarCategorias()
        {
            List<Combo> retorno = new List<Combo>();
            Combo obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_categoria]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Combo();
                                while (dr.Read())
                                {
                                    obj = new Combo();
                                    obj.codigo = dr.GetInt32(dr.GetOrdinal("nid_categoria"));
                                    obj.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Combo>();
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

        public List<Combo> BuscarPrioridades()
        {
            List<Combo> retorno = new List<Combo>();
            Combo obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_prioridad]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Combo();
                                while (dr.Read())
                                {
                                    obj = new Combo();
                                    obj.codigo = dr.GetInt32(dr.GetOrdinal("nid_prioridad"));
                                    obj.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Combo>();
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

        public List<Portafolio_Iniciativas> ObtenerIniciativas(Portafolio_Request entidad)
        {
            List<Portafolio_Iniciativas> retorno = new List<Portafolio_Iniciativas>();
            Portafolio_Iniciativas obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafolioiniciativas]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.codigo_portafolio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Portafolio_Iniciativas();
                                while (dr.Read())
                                {
                                    obj = new Portafolio_Iniciativas();
                                    obj.nid_relacion = dr.GetInt32(dr.GetOrdinal("nid_relacion"));
                                    obj.nid_iniciativa = dr.GetInt32(dr.GetOrdinal("nid_iniciativa"));
                                    obj.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    obj.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Portafolio_Iniciativas>();
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

        public List<Portafolio_Componentes> ObtenerComponentes(Portafolio_Request entidad)
        {
            List<Portafolio_Componentes> retorno = new List<Portafolio_Componentes>();
            Portafolio_Componentes obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafoliocomponentes]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.codigo_portafolio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj  = new Portafolio_Componentes();
                                while (dr.Read())
                                {
                                    obj = new Portafolio_Componentes();
                                    obj.nid_componente = dr.GetInt32(dr.GetOrdinal("nid_componente"));
                                    obj.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    obj.no_componente = dr.GetString(dr.GetOrdinal("no_componente"));
                                    obj.no_tipo = dr.GetString(dr.GetOrdinal("no_tipo"));
                                    obj.no_fecha_inicio = dr.GetString(dr.GetOrdinal("no_fecha_inicio"));
                                    obj.no_fecha_fin = dr.GetString(dr.GetOrdinal("no_fecha_fin"));
                                    obj.no_prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    obj.no_responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    obj.co_estado = dr.GetString(dr.GetOrdinal("co_estado"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Portafolio_Componentes>();
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

        public List<Responsable_Response> obtenerResponsables(Responsable_Request entidad)
        {
            List<Responsable_Response> retorno = new List<Responsable_Response>();
            Responsable_Response obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_posiblesresponsables]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_no_nombre", entidad.no_nombre);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Responsable_Response();
                                while (dr.Read())
                                {
                                    obj = new Responsable_Response();
                                    obj.nid_usuario = dr.GetInt32(dr.GetOrdinal("nid_usuario"));
                                    obj.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    obj.no_usrlogin = dr.GetString(dr.GetOrdinal("no_usrlogin"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Responsable_Response>();
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

        public List<Iniciativa_Response> obtenerIniciativasDisponibles(Iniciativa_Request entidad)
        {
            List<Iniciativa_Response> retorno = new List<Iniciativa_Response>();
            Iniciativa_Response obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_iniciativasdisponibles]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_no_nombre", entidad.no_nombre);
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);
                        
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Iniciativa_Response();
                                while (dr.Read())
                                {
                                    obj = new Iniciativa_Response();
                                    obj.nid_iniciativa = dr.GetInt32(dr.GetOrdinal("nid_iniciativa"));
                                    obj.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    obj.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Iniciativa_Response>();
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

        public void AsociarIniciativa(AsociarIniciativa_Request entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_iniciativaportafolio]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_iniciativa", entidad.nid_iniciativa);
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                }
                            }
                        }

                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DesasociarIniciativa(DesAsociarIniciativa_Request entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_portafolioiniciativa]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_relacion", entidad.nid_relacion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                }
                            }
                        }

                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Componente_Response> obtenerComponentesDisponibles(Componente_Request entidad)
        {
            List<Componente_Response> retorno = new List<Componente_Response>();
            Componente_Response obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_componentesdisponibles]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_no_nombre", entidad.no_nombre);
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);
                        command.Parameters.AddWithValue("@vi_co_tipo", entidad.co_tipo);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Componente_Response();
                                while (dr.Read())
                                {
                                    obj = new Componente_Response();
                                    obj.nid_codigo = dr.GetInt32(dr.GetOrdinal("nid_codigo"));
                                    obj.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    obj.no_componente = dr.GetString(dr.GetOrdinal("no_componente"));
                                    obj.no_tipo = dr.GetString(dr.GetOrdinal("no_tipo"));
                                    obj.no_fecha_inicio = dr.GetString(dr.GetOrdinal("no_fecha_inicio"));
                                    obj.no_fecha_fin = dr.GetString(dr.GetOrdinal("no_fecha_fin"));
                                    obj.no_prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    obj.no_responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    obj.co_estado = dr.GetString(dr.GetOrdinal("co_estado"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Componente_Response>();
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

        public void AsociarComponente(AsociarComponente_Request entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_componenteportafolio]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);
                        command.Parameters.AddWithValue("@vi_nid_proyecto", entidad.nid_proyecto);
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.nid_programa);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                }
                            }
                        }

                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void DesasociarComponente(DesAsociarComponente_Request entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_portafoliocomponente]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_componente", entidad.nid_componente);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                }
                            }
                        }

                    }
                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public EliminarPortafolio_Response EliminarPortafolio(EliminarPortafolio_Request entidad)
        {
            EliminarPortafolio_Response retorno = new EliminarPortafolio_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_portafolio]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);
                        command.Parameters.AddWithValue("@vi_nid_usuario", entidad.nid_usuario);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if((dr.GetInt32(dr.GetOrdinal("nid_retorno")) > 0)){
                                        retorno.respuesta = 1;
                                        retorno.str_mensaje = "";
                                    }else{
                                        retorno.respuesta = 0;
                                        retorno.str_mensaje = "No se pudo eliminar el Portafolio, debido a que tiene componentes en ejecución";
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

        public ActualizarPortafolio_Response ActualizarPortafolio(ActualizarPortafolio_Request entidad)
        {
            ActualizarPortafolio_Response retorno = new ActualizarPortafolio_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spu_portafolio]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);
                        command.Parameters.AddWithValue("@vi_nid_usuario", entidad.nid_usuario);
                        command.Parameters.AddWithValue("@vi_no_nombre", entidad.no_nombre);
                        command.Parameters.AddWithValue("@vi_nid_categoria", entidad.nid_categoria);
                        command.Parameters.AddWithValue("@vi_nid_prioridad", entidad.nid_prioridad);
                        command.Parameters.AddWithValue("@vi_nid_responsable", entidad.nid_responsable);
                        command.Parameters.AddWithValue("@vi_nid_responsable2", entidad.nid_responsable2);
                        command.Parameters.AddWithValue("@vi_tx_descripcion", entidad.tx_descripcion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    retorno.nid_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    retorno.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
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

        public Asignacion AsignacionCRUD(Asignacion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_ASIGNACION_CRUD]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodAsignacion", entidad.idCodAsignacion);
                        //command.Parameters.AddWithValue("@dtFechaAsignacion", entidad.dtFechaAsignacion);
                        command.Parameters.AddWithValue("@idCodEquipo", entidad.idCodEquipo);
                        command.Parameters.AddWithValue("@iCodPlan", entidad.iCodPlan);

                        command.Parameters.AddWithValue("@vNroDocRepsonsable", entidad.vNroDocRepsonsable);
                        command.Parameters.AddWithValue("@vNombreResponsable", entidad.vNombreResponsable);
                        command.Parameters.AddWithValue("@vApePatResponsable", entidad.vApePatResponsable);
                        command.Parameters.AddWithValue("@vApeMatResponsable", entidad.vApeMatResponsable);

                        command.Parameters.AddWithValue("@vNroDocEncargado", entidad.vNroDocEncargado);
                        command.Parameters.AddWithValue("@vNombreEncargado", entidad.vNombreEncargado);
                        command.Parameters.AddWithValue("@vApePatEncargado", entidad.vApePatEncargado);
                        command.Parameters.AddWithValue("@vApeMatEncargado", entidad.vApeMatEncargado);
                        command.Parameters.AddWithValue("@iUsuarioRegistro", entidad.iUsuarioRegistro);
                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);

                        command.Parameters.AddWithValue("@iOpcion", entidad.iOpcion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAsignacion")))
                                        entidad.idCodAsignacion = dr.GetInt32(dr.GetOrdinal("idCodAsignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("bError")))
                                        entidad.bError = dr.GetBoolean(dr.GetOrdinal("bError"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vMensaje")))
                                        entidad.vMensaje = dr.GetString(dr.GetOrdinal("vMensaje"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Ubigeo> ListarDepartamento()
        {
            List<Ubigeo> Lista = new List<Ubigeo>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_DEPARTAMENTO_LISTAR]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ubigeo>();
                                while (dr.Read())
                                {
                                    Ubigeo ubigeo = new Ubigeo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("DEPA_CODREF")))
                                        ubigeo.DEPA_CODREF = dr.GetString(dr.GetOrdinal("DEPA_CODREF"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("DEPA_DESCRIPCION")))
                                        ubigeo.DEPA_DESCRIPCION = dr.GetString(dr.GetOrdinal("DEPA_DESCRIPCION"));
                                    Lista.Add(ubigeo);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Ubigeo> ListarProvincia(Ubigeo entidad)
        {
            List<Ubigeo> Lista = new List<Ubigeo>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_PROVINCIA_LISTAR]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@DEPA_CODREF", entidad.DEPA_CODREF);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ubigeo>();
                                while (dr.Read())
                                {
                                    Ubigeo ubigeo = new Ubigeo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("prov_codref")))
                                        ubigeo.prov_codref = dr.GetString(dr.GetOrdinal("prov_codref"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("prov_descripcion")))
                                        ubigeo.prov_descripcion = dr.GetString(dr.GetOrdinal("prov_descripcion"));
                                    Lista.Add(ubigeo);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Ubigeo> ListarDistrito(Ubigeo entidad)
        {
            List<Ubigeo> Lista = new List<Ubigeo>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_DISTRITO_LISTAR]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@prov_codref", entidad.prov_codref);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Ubigeo>();
                                while (dr.Read())
                                {
                                    Ubigeo ubigeo = new Ubigeo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("dist_id")))
                                        ubigeo.dist_id = dr.GetInt32(dr.GetOrdinal("dist_id"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dist_descripcion")))
                                        ubigeo.dist_descripcion = dr.GetString(dr.GetOrdinal("dist_descripcion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dist_codref")))
                                        ubigeo.dist_codref = dr.GetString(dr.GetOrdinal("dist_codref"));
                                    Lista.Add(ubigeo);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Responsable BuscarResponsablePorDni(Responsable entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqvisita].[PA_PERSONAL_X_DNI_OBTENER]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@num_documento", entidad.NroDocResponsable);
                        command.Parameters.AddWithValue("@nom_trabajador", entidad.vResponsable);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_paterno")))
                                        entidad.vApePaterno = dr.GetString(dr.GetOrdinal("dsc_paterno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_materno")))
                                        entidad.vApeMaterno = dr.GetString(dr.GetOrdinal("dsc_materno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_nombres")))
                                        entidad.vNombres = dr.GetString(dr.GetOrdinal("dsc_nombres"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_paterno")) && !dr.IsDBNull(dr.GetOrdinal("dsc_materno")) && !dr.IsDBNull(dr.GetOrdinal("dsc_nombres")))
                                        entidad.vResponsable = entidad.vApePaterno + " " + entidad.vApeMaterno + " " + entidad.vNombres;
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Plan> ListarPlanes()
        {
            List<Plan> Lista = new List<Plan>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TM_PLAN_LISTAR]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = command.ExecuteReader()) {
                            if (dr.HasRows) {
                                while (dr.Read()) {
                                    Plan plan = new Plan();
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodTipoPlan")))
                                        plan.idCodTipoPlan = dr.GetInt32(dr.GetOrdinal("idCodTipoPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        plan.vNombre = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        plan.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        plan.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        plan.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                    Lista.Add(plan);
                                }
                            }
                        }
                    }
                }
                return Lista;
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
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_EQUIPO_OBTENER]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vIMEI", entidad.IMEI);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipo")))
                                        entidad.idCodEquipo = dr.GetInt32(dr.GetOrdinal("idCodEquipo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vIMEI")))
                                        entidad.IMEI = dr.GetString(dr.GetOrdinal("vIMEI"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodmodelo")))
                                        entidad.iCodModelo = dr.GetInt32(dr.GetOrdinal("iCodmodelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Modelo")))
                                        entidad.vModelo = dr.GetString(dr.GetOrdinal("Modelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodMarca")))
                                        entidad.iCodMarca = dr.GetInt32(dr.GetOrdinal("idCodMarca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Marca")))
                                        entidad.vMarca = dr.GetString(dr.GetOrdinal("Marca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                                        entidad.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Accesorio> ObtenerAccesorioPorIMEI(Equipo entidad)
        {
            List<Accesorio> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_ACCESORIO_OBTENER_X_IMEI]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vIMEI", entidad.IMEI);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                entidad.AccesorioList = new List<Accesorio>();
                                while (dr.Read())
                                {
                                    Accesorio objEnt = new Accesorio();
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipoDet")))
                                        objEnt.idCodEquipoDet = dr.GetInt32(dr.GetOrdinal("idCodEquipoDet"));
                                    if (entidad.IMEI == null)
                                    {
                                        objEnt.iTotalRecords = 0;
                                    }
                                    else
                                    {
                                        objEnt.iTotalRecords = 10;
                                    }

                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAccesorio")))
                                        objEnt.idCodAccesorio = dr.GetInt32(dr.GetOrdinal("idCodAccesorio"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        objEnt.vAccesorio = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                                        objEnt.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cEstado")))
                                    {
                                        objEnt.cEstado = dr.GetString(dr.GetOrdinal("cEstado"));
                                        //objEnt.vAcciones = "<span data-id='" + objEnt.idCodEquipoDet + "' class='ver ar-bullseye_solid' title='Ver'></span> ";
                                        //objEnt.vAcciones = objEnt.vAcciones + " <span data-id='" + objEnt.idCodEquipoDet + "' class='editar ar-pencil-alt_solid' title='Editar'></span>";
                                        if (objEnt.cEstado == "1"){
                                            objEnt.vAcciones = "<nav class='nav-actions'><a class='danger' data-toggle='tooltip' data-placement='top' title='Eliminar Accesorio' data-id='" + objEnt.idCodEquipoDet + "'><i class='fas fa-trash-alt'></i></a></nav>";
                                        }else if(objEnt.cEstado == "2"){
                                            objEnt.vAcciones = "<nav class='nav-actions'><a class='retornar' data-toggle='tooltip' data-placement='top' title='Devolver Accesorio' data-id='" + objEnt.idCodEquipoDet + "'><i class='fa fa-undo'></i></a><a class='ver' data-toggle='tooltip' data-placement='top' title='Ver Adjunto' data-id='" + objEnt.idCodEquipoDet + "'><i class='fas fa-eye'></i></a></nav>";
                                            //objEnt.vAcciones + " <span data-id='" + objEnt.idCodEquipoDet + "' class='retornar fa fa-undo' title='Devolver Accesorio'></span>";
                                        }
                                    }
                                    entidad.AccesorioList.Add(objEnt);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return entidad.AccesorioList;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Trabajador> BuscarTrabajador(Trabajador entidad)
        {
            List<Trabajador> Lista = new List<Trabajador>();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqvisita].PA_PERSONAL_X_DNI_OBTENER", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@num_documento", entidad.num_documento);
                        command.Parameters.AddWithValue("@nom_trabajador", entidad.Nom_Trabajador);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Trabajador>();
                                while (dr.Read())
                                {
                                    Trabajador trabajador = new Trabajador();
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_area")))
                                        trabajador.cod_area = dr.GetString(dr.GetOrdinal("cod_area"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_area")))
                                        trabajador.dsc_area = dr.GetString(dr.GetOrdinal("dsc_area"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_empresa")))
                                        trabajador.cod_empresa = dr.GetString(dr.GetOrdinal("cod_empresa"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Tip_Personal")))
                                        trabajador.Tip_Personal = dr.GetString(dr.GetOrdinal("Tip_Personal"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_Trabajador")))
                                        trabajador.cod_Trabajador = dr.GetString(dr.GetOrdinal("cod_Trabajador"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_paterno")))
                                        trabajador.dsc_paterno = dr.GetString(dr.GetOrdinal("dsc_paterno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_materno")))
                                        trabajador.dsc_materno = dr.GetString(dr.GetOrdinal("dsc_materno"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_nombres")))
                                        trabajador.dsc_nombres = dr.GetString(dr.GetOrdinal("dsc_nombres"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_estado")))
                                        trabajador.cod_estado = dr.GetString(dr.GetOrdinal("cod_estado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("flg_activo")))
                                        trabajador.flg_activo = dr.GetString(dr.GetOrdinal("flg_activo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_sexo")))
                                        trabajador.cod_sexo = dr.GetString(dr.GetOrdinal("cod_sexo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_documento")))
                                        trabajador.cod_tipo_documento = dr.GetString(dr.GetOrdinal("cod_tipo_documento"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("num_documento")))
                                        trabajador.num_documento = dr.GetString(dr.GetOrdinal("num_documento"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cod_dependencia")))
                                        trabajador.cod_dependencia = dr.GetString(dr.GetOrdinal("cod_dependencia"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dsc_cargo")))
                                        trabajador.dsc_cargo = dr.GetString(dr.GetOrdinal("dsc_cargo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Nom_Trabajador")))
                                        trabajador.Nom_Trabajador = dr.GetString(dr.GetOrdinal("Nom_Trabajador"));

                                    if (!dr.IsDBNull(dr.GetOrdinal("vAnexo")))
                                        trabajador.vAnexo = dr.GetString(dr.GetOrdinal("vAnexo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("movil_institu")))
                                        trabajador.movil_institu = dr.GetString(dr.GetOrdinal("movil_institu"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Email_institu")))
                                        trabajador.Email_institu = dr.GetString(dr.GetOrdinal("Email_institu"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Usuario_institu")))
                                        trabajador.Usuario_institu = dr.GetString(dr.GetOrdinal("Usuario_institu"));
                                    Lista.Add(trabajador);
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Plan ObtenerPlanPorNroCelular(Plan entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TM_PLAN_X_NRO_CEL_OBTENER]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodPlan")))
                                        entidad.iCodPlan = dr.GetInt32(dr.GetOrdinal("iCodPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        entidad.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodTipoPlan")))
                                        entidad.idCodTipoPlan = dr.GetInt32(dr.GetOrdinal("idCodTipoPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        entidad.vNombre = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        entidad.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        entidad.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        entidad.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Accesorio AccesorioCRUD(Accesorio entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_TAB_EQUIPO_ACCESORIO_CRUD]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodEquipoDet", entidad.idCodEquipoDet);
                        command.Parameters.AddWithValue("@idCodEquipo", entidad.idCodEquipo);
                        command.Parameters.AddWithValue("@idCodAccesorio", entidad.idCodAccesorio);
                        command.Parameters.AddWithValue("@vObservacion", entidad.vObservacion);
                        command.Parameters.AddWithValue("@vArchivo", entidad.vArchivo);
                        command.Parameters.AddWithValue("@iOpcion", entidad.iOpcion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipoDet")))
                                        entidad.idCodEquipoDet = dr.GetInt32(dr.GetOrdinal("idCodEquipoDet"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("bError")))
                                        entidad.bError = dr.GetBoolean(dr.GetOrdinal("bError"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vMensaje")))
                                        entidad.vMensaje = dr.GetString(dr.GetOrdinal("vMensaje"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Asignacion ObtenerAsignacionPorId(Asignacion entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_ASIGNAR_OBTENER_DETALLE_X_ID]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodAsignacion", entidad.idCodAsignacion);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodAsignacion")))
                                        entidad.idCodAsignacion = dr.GetInt32(dr.GetOrdinal("idCodAsignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocRepsonsable")))
                                        entidad.vNroDocRepsonsable = dr.GetString(dr.GetOrdinal("vNroDocRepsonsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatResponsable")))
                                        entidad.vApePatResponsable = dr.GetString(dr.GetOrdinal("vApePatResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApeMatResponsable")))
                                        entidad.vApeMatResponsable = dr.GetString(dr.GetOrdinal("vApeMatResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombreResponsable")))
                                        entidad.vNombreResponsable = dr.GetString(dr.GetOrdinal("vNombreResponsable"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroDocEncargado")))
                                        entidad.vNroDocEncargado = dr.GetString(dr.GetOrdinal("vNroDocEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApePatEncargado")))
                                        entidad.vApePatEncargado = dr.GetString(dr.GetOrdinal("vApePatEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vApeMatEncargado")))
                                        entidad.vApeMatEncargado = dr.GetString(dr.GetOrdinal("vApeMatEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombreEncargado")))
                                        entidad.vNombreEncargado = dr.GetString(dr.GetOrdinal("vNombreEncargado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        entidad.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("cEstado")))
                                        entidad.cEstado = dr.GetString(dr.GetOrdinal("cEstado"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dtFechaASignacion")))
                                        entidad.dtFechaASignacion = dr.GetString(dr.GetOrdinal("dtFechaASignacion"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vIMEI")))
                                        entidad.vIMEI = dr.GetString(dr.GetOrdinal("vIMEI"));
                                    //----------------------------------------------------------------------------------
                                    if (!dr.IsDBNull(dr.GetOrdinal("vMarca")))
                                        entidad.vMarca = dr.GetString(dr.GetOrdinal("vMarca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vModelo")))
                                        entidad.vModelo = dr.GetString(dr.GetOrdinal("vModelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        entidad.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        entidad.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        entidad.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vPlan")))
                                        entidad.vPlan = dr.GetString(dr.GetOrdinal("vPlan"));
                                    //-----------------------------------------------------------------------------------
                                    //*************************************************************************************
                                    if (!dr.IsDBNull(dr.GetOrdinal("vDependencia")))
                                        entidad.vDependencia = dr.GetString(dr.GetOrdinal("vDependencia"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vUnidad")))
                                        entidad.vUnidad = dr.GetString(dr.GetOrdinal("vUnidad"));
                                }
                            }
                            if (dr.NextResult())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        entidad.equipo = new Equipo();
                                        if (!dr.IsDBNull(dr.GetOrdinal("MODELO")))
                                            entidad.equipo.vModelo = dr.GetString(dr.GetOrdinal("MODELO"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("1")))
                                            entidad.equipo.mes1 = dr.GetDecimal(dr.GetOrdinal("1"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("2")))
                                            entidad.equipo.mes2 = dr.GetDecimal(dr.GetOrdinal("2"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("3")))
                                            entidad.equipo.mes3 = dr.GetDecimal(dr.GetOrdinal("3"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("4")))
                                            entidad.equipo.mes4 = dr.GetDecimal(dr.GetOrdinal("4"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("5")))
                                            entidad.equipo.mes5 = dr.GetDecimal(dr.GetOrdinal("5"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("6")))
                                            entidad.equipo.mes6 = dr.GetDecimal(dr.GetOrdinal("6"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("7")))
                                            entidad.equipo.mes7 = dr.GetDecimal(dr.GetOrdinal("7"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("8")))
                                            entidad.equipo.mes8 = dr.GetDecimal(dr.GetOrdinal("8"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("9")))
                                            entidad.equipo.mes9= dr.GetDecimal(dr.GetOrdinal("9"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("10")))
                                            entidad.equipo.mes10 = dr.GetDecimal(dr.GetOrdinal("10"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("11")))
                                            entidad.equipo.mes11 = dr.GetDecimal(dr.GetOrdinal("11"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("12")))
                                            entidad.equipo.mes12 = dr.GetDecimal(dr.GetOrdinal("12"));
                                    }
                                }
                            }
                            if (dr.NextResult())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        entidad.accesorio = new Accesorio();
                                        if (!dr.IsDBNull(dr.GetOrdinal("CARGADOR")))
                                            entidad.accesorio.dMontoCargador = dr.GetDecimal(dr.GetOrdinal("CARGADOR"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("AUDIFONOS")))
                                            entidad.accesorio.dMontoAudifonos = dr.GetDecimal(dr.GetOrdinal("AUDIFONOS"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("CABLE_DATOS")))
                                            entidad.accesorio.dMontoCableDatos = dr.GetDecimal(dr.GetOrdinal("CABLE_DATOS"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("ADAPTADOR")))
                                            entidad.accesorio.dMontoAdaptador = dr.GetDecimal(dr.GetOrdinal("ADAPTADOR"));
                                        if (!dr.IsDBNull(dr.GetOrdinal("SIMCARD")))
                                            entidad.accesorio.dMontoSimCard = dr.GetDecimal(dr.GetOrdinal("SIMCARD"));
                                    }
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public Accesorio ObtenerImgPorAccesorio(Accesorio entidad) {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[eqmoviles].[PA_OBTENER_IMG_X_ACCESORIO]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idCodEquipoDet", entidad.idCodEquipoDet);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if (!dr.IsDBNull(dr.GetOrdinal("vArchivo")))
                                        entidad.vArchivo = dr.GetString(dr.GetOrdinal("vArchivo"));
                                }
                            }
                        }
                    }
                    conection.Close();
                }
                return entidad;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Equipo> ObtenerEquiposDisponiblePorIMEI(Equipo entidad)
        {
            List<Equipo> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("eqmoviles.PA_OBTENER_EQP_DISP_X_IMEI", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vIMEI", entidad.IMEI);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Equipo>();
                                while (dr.Read())
                                {
                                    Equipo objEnt = new Equipo();
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodEquipo")))
                                        objEnt.idCodEquipo = dr.GetInt32(dr.GetOrdinal("idCodEquipo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vIMEI")))
                                        objEnt.IMEI = dr.GetString(dr.GetOrdinal("vIMEI"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodmodelo")))
                                        objEnt.iCodModelo = dr.GetInt32(dr.GetOrdinal("iCodmodelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Modelo")))
                                        objEnt.vModelo = dr.GetString(dr.GetOrdinal("Modelo"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodMarca")))
                                        objEnt.iCodMarca = dr.GetInt32(dr.GetOrdinal("idCodMarca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Marca")))
                                        objEnt.vMarca = dr.GetString(dr.GetOrdinal("Marca"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("Estado")))
                                        objEnt.Estado = dr.GetString(dr.GetOrdinal("Estado"));
                                    Lista.Add(objEnt);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Plan> ObtenerCelulareDisponiblePorNroCelular(Plan entidad)
        {
            List<Plan> Lista = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIntranet"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("eqmoviles.PA_OBTENER_PLAN_DISP_X_CELULAR", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vNroCelular", entidad.vNroCelular);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                Lista = new List<Plan>();
                                while (dr.Read())
                                {
                                    Plan objEnt = new Plan();
                                    if (!dr.IsDBNull(dr.GetOrdinal("iCodPlan")))
                                        objEnt.iCodPlan = dr.GetInt32(dr.GetOrdinal("iCodPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNroCelular")))
                                        objEnt.vNroCelular = dr.GetString(dr.GetOrdinal("vNroCelular"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("idCodTipoPlan")))
                                        objEnt.idCodTipoPlan = dr.GetInt32(dr.GetOrdinal("idCodTipoPlan"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("vNombre")))
                                        objEnt.vNombre = dr.GetString(dr.GetOrdinal("vNombre"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadGigas")))
                                        objEnt.dCantidadGigas = dr.GetDecimal(dr.GetOrdinal("dCantidadGigas"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMinutos")))
                                        objEnt.dCantidadMinutos = dr.GetDecimal(dr.GetOrdinal("dCantidadMinutos"));
                                    if (!dr.IsDBNull(dr.GetOrdinal("dCantidadMsj")))
                                        objEnt.dCantidadMsj = dr.GetDecimal(dr.GetOrdinal("dCantidadMsj"));
                                    Lista.Add(objEnt);
                                }
                            }
                        }

                    }
                    conection.Close();
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
}