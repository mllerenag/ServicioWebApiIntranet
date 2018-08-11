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
    public class ProgramaDA
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

        public List<Programa_Response> BuscarProgramas(Programa_Request entidad)
        {
            List<Programa_Response> retorno = null;
            Programa_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_programas]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_codigo", entidad.codigo);
                        command.Parameters.AddWithValue("@vi_nombre", entidad.nombre);
                        command.Parameters.AddWithValue("@vi_fechaini", entidad.fecha_creacion_ini);
                        command.Parameters.AddWithValue("@vi_fechafin", entidad.fecha_creacion_fin);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Programa_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Programa_Response();
                                    tmp.codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.descripcion = (dr.IsDBNull(dr.GetOrdinal("tx_descripcion")) ? "" : dr.GetString(dr.GetOrdinal("tx_descripcion")));
                                    tmp.fecha_creacion = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.fecha_inicio = dr.GetString(dr.GetOrdinal("no_fecha_inicio"));
                                    tmp.fecha_fin = dr.GetString(dr.GetOrdinal("no_fecha_fin"));
                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.responsable = dr.GetString(dr.GetOrdinal("no_responsable"));
                                    tmp.codigo_programa = dr.GetInt32(dr.GetOrdinal("nid_programa"));
                                    tmp.co_estado = dr.GetString(dr.GetOrdinal("co_estado"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<Programa_Response>();
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


        public Prt_Datos_Programa ObtenerPrograma(Programa_Request entidad)
        {
            Prt_Datos_Programa tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_programaindividual]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.codigo_programa);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Prt_Datos_Programa();
                                    tmp.nid_programa = dr.GetInt32(dr.GetOrdinal("nid_programa"));
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
                                tmp = new Prt_Datos_Programa();
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

        public List<Programa_Proyectos> ObtenerProyectos(Programa_Request entidad)
        {
            List<Programa_Proyectos> retorno = new List<Programa_Proyectos>();
            Programa_Proyectos obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_programaproyectos]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.codigo_programa);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Programa_Proyectos();
                                while (dr.Read())
                                {
                                    obj = new Programa_Proyectos();
                                    obj.nid_relacion = dr.GetInt32(dr.GetOrdinal("nid_relacion"));
                                    obj.nid_programa = dr.GetInt32(dr.GetOrdinal("nid_programa"));
                                    obj.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    obj.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Programa_Proyectos>();
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

        public List<Proyecto_Response> obtenerProyectosDisponibles(Proyecto_Request entidad)
        {
            List<Proyecto_Response> retorno = new List<Proyecto_Response>();
            Proyecto_Response obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_proyectosdisponibles]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_no_nombre", entidad.no_nombre);
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.nid_programa);
                        
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                obj = new Proyecto_Response();
                                while (dr.Read())
                                {
                                    obj = new Proyecto_Response();
                                    obj.nid_proyecto = dr.GetInt32(dr.GetOrdinal("nid_proyecto"));
                                    obj.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    obj.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    retorno.Add(obj);
                                }
                            }
                            else
                            {
                                retorno = new List<Proyecto_Response>();
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

        public void AsociarProyecto(AsociarProyecto_Request entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_proyectoprograma]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.nid_programa);
                        command.Parameters.AddWithValue("@vi_nid_proyecto", entidad.nid_proyecto);

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

        public void DesasociarProyecto(DesAsociarProyecto_Request entidad)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_programaproyecto]", conection))
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

        public EliminarPrograma_Response EliminarPrograma(EliminarPrograma_Request entidad)
        {
            EliminarPrograma_Response retorno = new EliminarPrograma_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_programa]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.nid_programa);
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
                                        retorno.str_mensaje = "No se pudo eliminar el Programa, debido a que tiene componentes en ejecución";
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

        public ActualizarPrograma_Response ActualizarPrograma(ActualizarPrograma_Request entidad)
        {
            ActualizarPrograma_Response retorno = new ActualizarPrograma_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spu_programa]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_programa", entidad.nid_programa);
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
                                    retorno.nid_programa = dr.GetInt32(dr.GetOrdinal("nid_programa"));
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

        

    }
}
