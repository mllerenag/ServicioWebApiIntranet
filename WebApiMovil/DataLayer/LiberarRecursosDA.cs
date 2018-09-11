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
        public List<PortafolioResponse> BuscarPortafolios(Portafolio_Request entidad)
        {
            List<PortafolioResponse> retorno = null;
            PortafolioResponse tmp = null;
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
                            retorno = new List<PortafolioResponse>();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    tmp = new PortafolioResponse();
                                    tmp.no_codigo = dr.GetString(dr.GetOrdinal("no_codigo"));
                                    tmp.no_nombre = dr.GetString(dr.GetOrdinal("no_nombre"));
                                    tmp.no_prioridad = dr.GetString(dr.GetOrdinal("prioridad"));
                                    tmp.no_categoria = dr.GetString(dr.GetOrdinal("categoria"));
                                    tmp.nid_portafolio = dr.GetInt32(dr.GetOrdinal("nid_portafolio"));
                                    tmp.fecha_creacion = dr.GetString(dr.GetOrdinal("fecha_creacion"));
                                    retorno.Add(tmp);
                                }
                            }
                            else
                            {
                                retorno = new List<PortafolioResponse>();
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