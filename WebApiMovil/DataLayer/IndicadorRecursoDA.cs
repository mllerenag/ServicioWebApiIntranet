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
    public class IndicadorRecursoDA
    {
        public List<Data_Indicador_Recurso> ObtenerDataGrafico(Data_Indicador_Recurso_Request entidad)
        {
            List<Data_Indicador_Recurso> retorno = null;
            Data_Indicador_Recurso tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_grafico_recurso]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_portafolios", entidad.portafolios);
                        command.Parameters.AddWithValue("@vi_recursos", entidad.recursos);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Data_Indicador_Recurso>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Data_Indicador_Recurso();
                                    tmp.nid_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    tmp.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.nid_recurso = dr.GetInt32(dr.GetOrdinal("nid_recurso"));
                                    tmp.no_recurso = dr.GetString(dr.GetOrdinal("no_recurso"));
                                    tmp.nu_separado = dr.GetInt32(dr.GetOrdinal("nu_separado"));
                                    tmp.nu_recursototal = dr.GetInt32(dr.GetOrdinal("nu_recursototal"));
                                    tmp.nu_recursoconsumido = dr.GetInt32(dr.GetOrdinal("nu_recursoconsumido"));
                                    tmp.nu_recursodisponible = dr.GetInt32(dr.GetOrdinal("nu_recursodisponible"));
                                    retorno.Add(tmp);

                                }
                            }
                            else
                            {
                                retorno = new List<Data_Indicador_Recurso>();
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

        public List<Data_Indicador_Recurso_Componente> ObtenerDataGrafico_Componente(Data_Indicador_Recurso_Request entidad)
        {
            List<Data_Indicador_Recurso_Componente> retorno = null;
            Data_Indicador_Recurso_Componente tmp = null;
            try
            {
                using (SqlConnection conection = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxIndra"].ConnectionString))
                {
                    conection.Open();

                    using (SqlCommand command = new SqlCommand("[pa_sps_grafico_recurso_componente]", conection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@vi_portafolios", entidad.portafolios);
                        command.Parameters.AddWithValue("@vi_recursos", entidad.recursos);
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            retorno = new List<Data_Indicador_Recurso_Componente>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new Data_Indicador_Recurso_Componente();
                                    tmp.nid_componente = dr.GetInt32(dr.GetOrdinal("nid_componente"));
                                    tmp.no_componente = dr.GetString(dr.GetOrdinal("no_componente"));
                                    tmp.nu_recurso = dr.GetInt32(dr.GetOrdinal("nu_recurso"));
                                    retorno.Add(tmp);

                                }
                            }
                            else
                            {
                                retorno = new List<Data_Indicador_Recurso_Componente>();
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