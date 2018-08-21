using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Solicitud_Request
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public int nid_solicitud { get; set; }

        [DataMember]
        public string recurso { get; set; }

        [DataMember]
        public string componente { get; set; }

        [DataMember]
        public string portafolio { get; set; }

        [DataMember]
        public string fecha_solicitud { get; set; }

        [DataMember]
        public string co_estado { get; set; }
    }

    [DataContract]
    public class Solicitud_Response
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public int nid_solicitud { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string componente { get; set; }

        [DataMember]
        public string recurso { get; set; }


        [DataMember]
        public int cantidad { get; set; }

        [DataMember]
        public int balanceo { get; set; }

        
        [DataMember]
        public string fecha_solicitud { get; set; }

        [DataMember]
        public string portafolio { get; set; }

        [DataMember]
        public string co_estado { get; set; }
    }

    [DataContract]
    public class PopUp_Solicitud_Response
    {
        [DataMember]
        public Prt_Datos objeto { get; set; }
        [DataMember]
        public List<Combo> cbo_categoria { get; set; }
        [DataMember]
        public List<Combo> cbo_prioridad { get; set; }
    }

    [DataContract]
    public class GenerarSolicitud_Request
    {
        [DataMember]
        public List<GenerarSolicitud_Req> lista { get; set; }
        
    }

    [DataContract]
    public class GenerarSolicitud_Req
    {
        [DataMember]
        public int nid_recurso { get; set; }
        [DataMember]
        public int nid_componente { get; set; }
        [DataMember]
        public int cantidad { get; set; }
        [DataMember]
        public string descricpcion { get; set; }
        [DataMember]
        public bool show { get; set; }
        [DataMember]
        public string descripcion { get; set; }
    }

    [DataContract]
    public class GenerarSolicitud_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

    [DataContract]
    public class EliminarSolicitud_Request
    {
        [DataMember]
        public int nid_Solicitud { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
    }

    [DataContract]
    public class EliminarSolicitud_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

}