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
    public class EvaluacionBalanceoDA
    {
        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request entidad)
        {
            List<Portafolio_Response> retorno = null;
            Portafolio_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_portafoliospropuestas]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_codigo", entidad.codigo);
                        command.Parameters.AddWithValue("@vi_nombre", entidad.nombre);
                       
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
                                    tmp.nro_propuestas = dr.GetInt32(dr.GetOrdinal("contar_propuestas"));
                                    tmp.codigo_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
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

        public List<Propuesta_Response> BuscarPropuestas(Propuesta_Request entidad)
        {
            List<Propuesta_Response> retorno = null;
            Propuesta_Response tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_propuestas]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_balanceo", entidad.nid_balanceo);
                        command.Parameters.AddWithValue("@vi_nid_portafolio", entidad.nid_portafolio);
                        command.Parameters.AddWithValue("@vi_no_componente", entidad.no_componente);
                        command.Parameters.AddWithValue("@vi_nid_recurso", entidad.nid_recurso);

                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Propuesta_Response>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Propuesta_Response();
                                    tmp.nid_balanceo = dr.GetInt32(dr.GetOrdinal("nid_balanceo"));
                                    tmp.nid_detalle = dr.GetInt32(dr.GetOrdinal("nid_detalle"));
                                    tmp.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.no_nombre_componente = dr.GetString(dr.GetOrdinal("no_nombre_componente"));
                                    tmp.no_nombre_recurso = dr.GetString(dr.GetOrdinal("no_nombre_recurso"));
                                    tmp.fe_crea = dr.GetString(dr.GetOrdinal("fe_crea"));
                                    tmp.nu_solicitado = dr.GetInt32(dr.GetOrdinal("nu_solicitado"));
                                    tmp.nu_balanceo = dr.GetInt32(dr.GetOrdinal("nu_balanceo"));
                                    tmp.prioridad = dr.GetString(dr.GetOrdinal("no_prioridad"));
                                    tmp.resp_correo = dr.GetString(dr.GetOrdinal("resp_correo"));
                                    tmp.resp_nombre = dr.GetString(dr.GetOrdinal("resp_nombre"));
                                    tmp.bala_correo = dr.GetString(dr.GetOrdinal("bala_correo"));
                                    tmp.bala_nombre = dr.GetString(dr.GetOrdinal("bala_nombre"));

                                    retorno.Add(tmp);

                                }
                            }
                            else
                            {
                                retorno = new List<Propuesta_Response>();
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

        public void EvaluarPropuesta(Eval_Tmp obj)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_spu_detallebalanceo]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_nid_detalle", obj.nid_detalle);
                        command.Parameters.AddWithValue("@vi_nu_accion", obj.accion);
                        command.Parameters.AddWithValue("@vi_no_comentario_rechazo", obj.no_comentario);
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

    }
}