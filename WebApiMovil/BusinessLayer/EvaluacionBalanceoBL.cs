using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.DataLayer;
using WebApiMovil.Models;

namespace WebApiMovil.BusinessLayer
{
    public class EvaluacionBalanceoBL
    {
        private EvaluacionBalanceoDA evaluacionDA;
        private MailBL mailBL;
        public EvaluacionBalanceoBL()
        {
            evaluacionDA = new EvaluacionBalanceoDA();
            mailBL = new MailBL();
        }

        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                if (obj.codigo == null) obj.codigo = "";
                if (obj.nombre == null) obj.nombre = "";
                return evaluacionDA.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Combo> BuscarRecursos()
        {
            try
            {
                return evaluacionDA.BuscarRecursos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Propuesta_Response> BuscarPropuestas(Propuesta_Request obj)
        {
            try
            {
                if (obj.no_componente == null) obj.no_componente = "";
                return evaluacionDA.BuscarPropuestas(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Eval_Response EvaluarPropuesta(Eval_Request obj)
        {
            try
            {
                Eval_Response retorno = new Eval_Response();
                if (obj.no_comentario == null) obj.no_comentario = "";
                Propuesta_Request pr_para = new Propuesta_Request();
                pr_para.nid_portafolio = obj.idportafolio;
                List<Propuesta_Response> propuestas_gen = BuscarPropuestas(pr_para);
                List<Propuesta_Response> propuestas_dt = new List<Propuesta_Response>();
                Propuesta_Response propuesta_tmp = new Propuesta_Response();
                List<Eval_Tmp> evaluaciones_tmp = new List<Eval_Tmp>();
                Eval_Tmp evl_tmp = new Eval_Tmp();
                for (int x = 0; x < obj.lista_parametros.Count(); x++)
                {
                    evl_tmp = new Eval_Tmp();
                    evl_tmp.nid_detalle = int.Parse(obj.lista_parametros[x]);
                    evl_tmp.no_comentario = obj.no_comentario;
                    evl_tmp.accion = obj.accion;
                    evaluaciones_tmp.Add(evl_tmp);
                }

                for (int x = 0; x < evaluaciones_tmp.Count(); x++)
                {
                    evaluacionDA.EvaluarPropuesta(evaluaciones_tmp[x]);
                    propuesta_tmp = propuestas_gen.Where(y => y.nid_detalle.Equals(evaluaciones_tmp[x].nid_detalle)).SingleOrDefault();
                    if (propuesta_tmp != null)
                    {
                        propuestas_dt.Add(propuesta_tmp);
                    }

                }

                if (obj.accion == 0)
                {
                    retorno.resultado = 1;
                    retorno.mensaje = "Se desaprobó satisfactoriamente las propuestas marcadas";
                }
                else
                {
                    retorno.resultado = 1;
                    retorno.mensaje = "Se aprobó satisfactoriamente las propuestas marcadas";
                    EnviarCorreos_Responsables(propuestas_dt);
                    EnviarCorreos_Balanceadores(propuestas_dt);
                }

              
                return retorno;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EnviarCorreos_Responsables(List<Propuesta_Response> propuestas)
        {
            string mensaje = "";
            foreach (Propuesta_Response obj in propuestas)
            {
                mensaje = "";
                mensaje += "<p> Estimado " + obj.resp_nombre + "</p>";
                mensaje += "<br>";
                mensaje += "<p> Se le ha asignado " + obj.nu_balanceo + " " +  obj.no_nombre_recurso + " a su ";
                mensaje += (obj.no_codigo.Contains("PY") ? "Proyecto " : "Programa") + " : " + obj.no_codigo + " (";
                mensaje += obj.no_nombre_componente + ")";
                mensaje += "<br>";

                mailBL.EnviarMail(obj.resp_correo,"","Asignación de Recursos",mensaje, new List<string>(), true, true);
            }
        }

        public void EnviarCorreos_Balanceadores(List<Propuesta_Response> propuestas)
        {
            List<int> balanceos = new List<int>();
            string mensaje = "";
            List<Propuesta_Response> balanceos_tmp = new List<Propuesta_Response>();
            foreach (Propuesta_Response obj in propuestas)
            {
                if (balanceos.Where(x => x.Equals(obj.nid_balanceo)).Count() == 0)
                {
                    balanceos.Add(obj.nid_balanceo);
                }
            }

            foreach (int b in balanceos)
            {
                balanceos_tmp = propuestas.Where(x => x.nid_balanceo.Equals(b)).ToList();
                mensaje = "";
                mensaje += "<p> Estimado " + balanceos_tmp[0].bala_nombre + "</p>";
                mensaje += "<br>";
                mensaje += "<p> Se han aprobado los siguientes balanceos emitido </p>";
                mensaje += "<br><br>";
                foreach (Propuesta_Response obj in propuestas)
                {
                    mensaje += "<p>" + obj.nid_balanceo + " - " + obj.no_nombre_componente + " : " + obj.nu_balanceo + " " + obj.no_nombre_recurso;
                }

                mailBL.EnviarMail(balanceos_tmp[0].bala_correo, "", "Aprobacion de Balanceo", mensaje, new List<string>(), true, true);
            
            }
        }
    }
}