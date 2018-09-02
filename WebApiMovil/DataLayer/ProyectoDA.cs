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
    public class ProyectoDA
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

        public List<ProyectoI_Response> BuscarProyectos(ProyectoI_Request entidad)
        {
            List<ProyectoI_Response> retorno = null;
            ProyectoI_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_proyectos]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_codigo", entidad.codigo);
                        command.Parameters.AddWithValue("@vi_nombre", entidad.nombre);
                        command.Parameters.AddWithValue("@vi_fechaini", entidad.fecha_creacion_ini);
                        command.Parameters.AddWithValue("@vi_fechafin", entidad.fecha_creacion_fin);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<ProyectoI_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new ProyectoI_Response();
                                    tmp.codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.descripcion = (dr.IsDBNull(dr.GetOrdinal("tx_descripcion")) ? "" : dr.GetString(dr.GetOrdinal("tx_descripcion")));
                                    tmp.fecha_creacion = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.fecha_inicio = dr.GetString(dr.GetOrdinal("no_fecha_inicio"));
                                    tmp.fecha_fin = dr.GetString(dr.GetOrdinal("no_fecha_fin"));
                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    tmp.codigo_proyecto = dr.GetInt32(dr.GetOrdinal("nid_proyecto"));
                                    tmp.co_estado = dr.GetString(dr.GetOrdinal("co_estado"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<ProyectoI_Response>();
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
        
        public EliminarProyecto_Response EliminarProyecto(EliminarProyecto_Request entidad)
        {
            EliminarProyecto_Response retorno = new EliminarProyecto_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_proyecto]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_proyecto", entidad.nid_proyecto);
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
                                        retorno.str_mensaje = "No se pudo eliminar el Proyecto, debido a que tiene componentes en ejecución";
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

        public ActualizarProyecto_Response ActualizarProyecto(ActualizarProyecto_Request entidad)
        {
            ActualizarProyecto_Response retorno = new ActualizarProyecto_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spu_proyecto]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_proyecto", entidad.nid_proyecto);
                        command.Parameters.AddWithValue("@vi_no_nombre", entidad.no_nombre);
                        command.Parameters.AddWithValue("@vi_nid_prioridad", entidad.nid_prioridad);
                        command.Parameters.AddWithValue("@vi_nid_responsable", entidad.nid_responsable);
                        command.Parameters.AddWithValue("@vi_tx_descripcion", entidad.tx_descripcion);
                        command.Parameters.AddWithValue("@vi_dt_fecha_fin", entidad.fecha_fin);
                        command.Parameters.AddWithValue("@vi_dt_fecha_inicio", entidad.fecha_inicio);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    retorno.nid_proyecto = dr.GetInt32(dr.GetOrdinal("nid_proyecto"));
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

        public Prt_Datos_Proyecto ObtenerProyecto(ProyectoI_Request entidad)
        {
            Prt_Datos_Proyecto tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_proyectoindividual]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_proyecto", entidad.codigo_proyecto);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Prt_Datos_Proyecto();
                                    tmp.nid_proyecto = dr.GetInt32(dr.GetOrdinal("nid_proyecto"));
                                    tmp.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.nid_responsable = dr.GetInt32(dr.GetOrdinal("nid_responsable"));
                                    tmp.fe_crea = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.no_prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.no_responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    tmp.no_estado = dr.GetString(dr.GetOrdinal("no_estado"));
                                    tmp.fe_inicio = dr.GetString(dr.GetOrdinal("no_fecha_inicio"));
                                    tmp.fe_fin = dr.GetString(dr.GetOrdinal("no_fecha_fin"));
                                    tmp.no_nombre = (dr.IsDBNull(dr.GetOrdinal("no_nombre")) ? "" : dr.GetString(dr.GetOrdinal("no_nombre")));
                                    tmp.no_descripcion = (dr.IsDBNull(dr.GetOrdinal("tx_descripcion")) ? "" : dr.GetString(dr.GetOrdinal("tx_descripcion")));
                                    tmp.nid_prioridad = dr.GetInt32(dr.GetOrdinal("nid_prioridad"));
                                }
                            }
                            else
                            {
                                tmp = new Prt_Datos_Proyecto();
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


    }
}
