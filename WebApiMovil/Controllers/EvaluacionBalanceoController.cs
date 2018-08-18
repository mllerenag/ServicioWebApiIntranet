using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiMovil.Models;
using WebApiMovil.Services;

namespace WebApi.Controllers
{
    public class EvaluacionBalanceoController : System.Web.Http.ApiController
    {

        EvaluacionBalanceoService evaluacionService;
        public EvaluacionBalanceoController()
        {
            evaluacionService = new EvaluacionBalanceoService();
        }

        [HttpPost]
        [ActionName("BuscarPortafolios")]
        public List<Portafolio_Response> BuscarPortafolios(Portafolio_Request obj)
        {
            try
            {
                return evaluacionService.BuscarPortafolios(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarPropuestas")]
        public List<Propuesta_Response> BuscarPropuestas(Propuesta_Request obj)
        {
            try
            {
                return evaluacionService.BuscarPropuestas(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("EvaluarPropuesta")]
        public Eval_Response EvaluarPropuesta(Eval_Request obj)
        {
            try
            {
                return evaluacionService.EvaluarPropuesta(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ActionName("BuscarRecursos")]
        public List<Combo> BuscarRecursos()
        {
            try
            {
                return evaluacionService.BuscarRecursos();
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}