using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiMovil.BusinessLayer;
using WebApiMovil.Models;

namespace WebApiMovil.Services
{
    public class EvaluacionBalanceoService
    {
        private EvaluacionBalanceoBL evaluacionBL;

        public EvaluacionBalanceoService()
        {
            evaluacionBL = new EvaluacionBalanceoBL();
        }

        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                return evaluacionBL.BuscarPortafolios(obj);
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
                return evaluacionBL.BuscarPropuestas(obj);
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
                return evaluacionBL.EvaluarPropuesta(obj);
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
                return evaluacionBL.BuscarRecursos();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}