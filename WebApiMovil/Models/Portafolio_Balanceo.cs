using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{

    [DataContract]
    public class Prt_Datos
    {
        [DataMember]
        public int nid_portafolio { get; set; }

        [DataMember]
        public string no_codigo { get; set; }

        [DataMember]
        public string fe_crea { get; set; }

        [DataMember]
        public string no_nombre { get; set; }

        [DataMember]
        public string no_categoria { get; set; }

        [DataMember]
        public string no_prioridad { get; set; }

        [DataMember]
        public string no_responsable { get; set; }

        [DataMember]
        public string no_responsable2 { get; set; }
        [DataMember]
        public string no_estado { get; set; }

        [DataMember]
        public string tx_descripcion { get; set; }

        [DataMember]
        public int nid_categoria { get; set; }

        [DataMember]
        public int nid_prioridad { get; set; }

        [DataMember]
        public int nid_responsable { get; set; }

        [DataMember]
        public int nid_responsable2 { get; set; }
        
    }

    [DataContract]
    public class Prt_Solicitud
    {
        [DataMember]
        public int nid_solicitud { get; set; }
        [DataMember]
        public string co_solicitud { get; set; }

        [DataMember]
        public string fe_solicitud { get; set; }


        [DataMember]
        public string no_prioridad { get; set; }

        [DataMember]
        public string no_componente { get; set; }

        [DataMember]
        public string no_tipo_recurso { get; set; }

        [DataMember]
        public string no_recurso { get; set; }

        [DataMember]
        public int nid_recurso { get; set; }

        [DataMember]
        public int nu_solicitado { get; set; }

        [DataMember]
        public int nu_recomendado { get; set; }
        [DataMember]
        public int nu_recursodisponible { get; set; }

        [DataMember]
        public int nu_recursototal { get; set; }
    }

    [DataContract]
    public class Prt_Request
    {
        public List<string> lista_parametros { get; set; }
        public string portafolio { get; set; }
        public string id_user { get; set; }
    }

    [DataContract]
    public class Prt_Response
    {
        [DataMember]
        public string mensaje { get; set; }
        [DataMember]
        public int resultado { get; set; }
    }

    [DataContract]
    public class Prt_BalanceoTmp
    {
        public int solicitud { get; set; }
        public int configurado { get; set; }
    }
    [DataContract]
    public class Prt_Recurso
    {
        [DataMember]
        public int nid_recurso { get; set; }

        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public int nu_recursototal { get; set; }

        [DataMember]
        public int nu_separado { get; set; }

        [DataMember]
        public int nu_recursoconsumido { get; set; }

        [DataMember]
        public int  nu_recursodisponible { get; set; }
    }

    [DataContract]
    public class Prt_Balanceo
    {
        [DataMember]
        public List<Prt_Recurso> recursos { get; set; }
        [DataMember]
        public List<Prt_Solicitud> solicitudes { get; set; }
        [DataMember]
        public Prt_Datos datos { get; set; }
    }
}