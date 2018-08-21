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
    public class SolicitudDA
    {
        public ResultadoLogin Login(ResultadoLogin entidad)
        {
            ResultadoLogin retorno = null;
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
                            else
                            {
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

        public List<Solicitud_Response> BuscarSolicitudes(Solicitud_Request entidad)
        {
            List<Solicitud_Response> retorno = null;
            Solicitud_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_solicitud_recurso]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_solicitud", entidad.codigo);
                        command.Parameters.AddWithValue("@vi_recurso", entidad.recurso);
                        command.Parameters.AddWithValue("@vi_portafolio", entidad.portafolio);
                        command.Parameters.AddWithValue("@vi_componente", entidad.componente);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Solicitud_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Solicitud_Response();
                                    tmp.codigo = dr.GetString(dr.GetOrdinal("co_solicitud"));
                                    tmp.nid_solicitud = dr.GetInt32(dr.GetOrdinal("nid_solicitud"));
                                    tmp.recurso = dr.GetString(dr.GetOrdinal("no_recurso"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.recurso = dr.GetString(dr.GetOrdinal("no_recurso"));
                                    tmp.balanceo = dr.GetInt32(dr.GetOrdinal("balanceo"));
                                    tmp.cantidad = dr.GetInt32(dr.GetOrdinal("nu_solicitado"));
                                    tmp.componente = dr.GetString(dr.GetOrdinal("no_componente"));
                                    tmp.portafolio = dr.GetString(dr.GetOrdinal("no_portafolio"));
                                    tmp.fecha_solicitud = dr.GetString(dr.GetOrdinal("fe_solicitud"));
                                    tmp.co_estado = dr.GetString(dr.GetOrdinal("co_estado"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<Solicitud_Response>();
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

        public EliminarSolicitud_Response EliminarSolicitud(EliminarSolicitud_Request entidad)
        {
            EliminarSolicitud_Response retorno = new EliminarSolicitud_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_solicitud]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_solicitud", entidad.nid_Solicitud);
                        command.Parameters.AddWithValue("@vi_nid_usuario", entidad.nid_usuario);
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
                                        retorno.str_mensaje = "No se pudo eliminar la solicitud, debido a que tiene componentes en ejecución";
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

        public List<Combo> BuscarRecursos()
        {
            List<Combo> retorno = new List<Combo>();
            Combo obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_recursos]", conection))
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
                                    obj.codigo = dr.GetInt32(dr.GetOrdinal("nid_recurso"));
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

        public GenerarSolicitud_Response GenerarSolicitud(GenerarSolicitud_Req obj)
        {
            GenerarSolicitud_Response retorno = new GenerarSolicitud_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_solicitud]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_recurso", obj.nid_recurso);
                        command.Parameters.AddWithValue("@vi_nid_componente", obj.nid_componente);
                        command.Parameters.AddWithValue("@vi_nu_solicitado", obj.cantidad);
                        command.Parameters.AddWithValue("@vi_no_nombre", obj.descripcion);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    if ((dr.GetInt32(dr.GetOrdinal("nid_retorno")) > 0))
                                    {
                                        retorno.respuesta = 1;
                                        retorno.str_mensaje = dr.GetString(dr.GetOrdinal("msj_retorno"));
                                    }
                                    else
                                    {
                                        retorno.respuesta = 0;
                                        retorno.str_mensaje = "No se pudo eliminar la solicitud, debido a que tiene componentes en ejecución";
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