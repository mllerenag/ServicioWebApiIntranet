using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{

    [DataContract]
    public class Propuesta_Request
    {
        public int nid_portafolio{ get; set; }
        public int nid_balanceo { get; set; }
        public int nid_recurso { get; set; }
        public string no_componente { get; set; }
    }

    [DataContract]
    public class Propuesta_Response
    {
        [DataMember]
        public int nid_balanceo{ get; set; }
        [DataMember]
        public int nid_detalle { get; set; }
        [DataMember]
        public string no_codigo { get; set; }
        [DataMember]
        public string prioridad { get; set; }
        [DataMember]
        public string no_nombre_componente { get; set; }
        [DataMember]
        public string no_nombre_recurso { get; set; }
        [DataMember]
        public int nu_solicitado { get; set; }
        [DataMember]
        public int nu_balanceo { get; set; }
        [DataMember]
        public string fe_crea { get; set; }
        [DataMember]
        public string resp_correo { get; set; }
        [DataMember]
        public string resp_nombre { get; set; }
        [DataMember]
        public string bala_correo { get; set; }
        [DataMember]
        public string bala_nombre { get; set; }
     }

    
    [DataContract]
    public class Eval_Request
    {
        public List<string> lista_parametros { get; set; }
        public string no_comentario { get; set; }
        public int accion { get; set; }
        public int idportafolio { get; set; }
    }

    [DataContract]
    public class Eval_Tmp
    {
        public int nid_detalle { get; set; }
        public string no_comentario { get; set; }
        public int accion { get; set; }
    }
    [DataContract]
    public class Eval_Response
    {
        [DataMember]
        public string mensaje { get; set; }
        [DataMember]
        public int resultado { get; set; }
    }

  
}