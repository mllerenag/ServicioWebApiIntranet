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
    public class PlanificarDA
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

        public List<Monitoreo_Response> BuscarMonitoreos(Monitoreo_Request entidad)
        {
            List<Monitoreo_Response> retorno = null;
            Monitoreo_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_proyecto_monitoreo]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nid_responsable", entidad.nid_responsable);
                        command.Parameters.AddWithValue("@vi_portafolio", entidad.co_portafolio);
                        command.Parameters.AddWithValue("@vi_proyecto", entidad.co_proyecto);
                        command.Parameters.AddWithValue("@vi_categoria", entidad.categoria);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Monitoreo_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Monitoreo_Response();
                                    tmp.nid_monitoreo = dr.GetInt32(dr.GetOrdinal("nid_monitoreo"));
                                    tmp.nid_proyecto = dr.GetInt32(dr.GetOrdinal("nid_proyecto"));
                                    tmp.co_proyecto = dr.GetString(dr.GetOrdinal("co_proyecto"));
                                    tmp.no_proyecto = dr.GetString(dr.GetOrdinal("no_proyecto"));
                                    tmp.nid_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    tmp.no_portafolio = dr.GetString(dr.GetOrdinal("no_portafolio"));

                                    tmp.fecha_crea = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.po_programado = dr.GetInt32(dr.GetOrdinal("po_programado"));
                                    tmp.po_real = dr.GetInt32(dr.GetOrdinal("po_real"));
                                    tmp.no_estado = dr.GetString(dr.GetOrdinal("no_estado"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<Monitoreo_Response>();
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

        public List<Tarea_Response> BuscarTareas(Tarea_Request entidad)
        {
            List<Tarea_Response> retorno = null;
            Tarea_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_proyecto_tarea]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_proyecto", entidad.nid_proyecto);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Tarea_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Tarea_Response();
                                    tmp.nid_tarea = dr.GetInt32(dr.GetOrdinal("nid_tarea"));
                                    tmp.nid_nivel = dr.GetInt32(dr.GetOrdinal("nid_nivel"));
                                    tmp.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.fecha_inicio = dr.GetString(dr.GetOrdinal("fe_inicio"));
                                    tmp.fecha_fin = dr.GetString(dr.GetOrdinal("fe_fin"));
                                    tmp.po_programado = dr.GetInt32(dr.GetOrdinal("po_programado"));
                                    tmp.po_real = dr.GetInt32(dr.GetOrdinal("po_real"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<Tarea_Response>();
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

        public List<Combo> BuscarNivel()
        {
            List<Combo> retorno = new List<Combo>();
            Combo obj = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_nivel]", conection))
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
                                    obj.codigo = dr.GetInt32(dr.GetOrdinal("nid_nivel"));
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

        public GenerarMonitoreo_Response GenerarMonitoreo(GenerarMonitoreo_Request obj)
        {
            GenerarMonitoreo_Response retorno = new GenerarMonitoreo_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_proyecto_monitoreo]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_portafolio", obj.nid_portafolio);
                        command.Parameters.AddWithValue("@vi_nid_proyecto", obj.nid_proyecto);
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
                                        retorno.str_mensaje = "No se generó el monitoreo, debido a que hubo error en los datos";
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

        public GenerarTarea_Response GenerarTarea(GenerarTarea_Req obj)
        {
            GenerarTarea_Response retorno = new GenerarTarea_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spi_proyecto_tarea]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_proyecto", obj.nid_proyecto);
                        command.Parameters.AddWithValue("@vi_nid_nivel", obj.nid_nivel);
                        command.Parameters.AddWithValue("@vi_no_codigo", obj.no_codigo);
                        command.Parameters.AddWithValue("@vi_no_nombre", obj.no_nombre);
                        command.Parameters.AddWithValue("@vi_fe_inicio", obj.fecha_inicio);
                        command.Parameters.AddWithValue("@vi_fe_fin", obj.fecha_fin);
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
                                        retorno.str_mensaje = "No se generó la tarea, debido a que hubo error en los datos";
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

        public EditarTarea_Response EditarTarea(EditarTarea_Req obj)
        {
            EditarTarea_Response retorno = new EditarTarea_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spu_proyecto_tarea]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_proyecto", obj.nid_proyecto);
                        command.Parameters.AddWithValue("@vi_nid_tarea", obj.nid_tarea);
                        command.Parameters.AddWithValue("@vi_nid_nivel", obj.nid_nivel);
                        command.Parameters.AddWithValue("@vi_no_codigo", obj.no_codigo);
                        command.Parameters.AddWithValue("@vi_no_nombre", obj.no_nombre);
                        command.Parameters.AddWithValue("@vi_fe_inicio", obj.fecha_inicio);
                        command.Parameters.AddWithValue("@vi_fe_fin", obj.fecha_fin);
                        command.Parameters.AddWithValue("@vi_po_real", obj.po_real);

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
                                        retorno.str_mensaje = "No se editó la tarea, debido a que hubo error en los datos";
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

        public EliminarTarea_Response EliminarTarea(EliminarTarea_Request entidad)
        {
            EliminarTarea_Response retorno = new EliminarTarea_Response();
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spd_proyecto_tarea]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_tarea", entidad.nid_Tarea);
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
                                        retorno.str_mensaje = "No se pudo eliminar la tarea, debido a que se encuentra en ejecución";
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