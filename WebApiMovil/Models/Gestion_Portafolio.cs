using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Portafolio_Request
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public int codigo_portafolio { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string categoria { get; set; }

        [DataMember]
        public string fecha_creacion_ini { get; set; }

        [DataMember]
        public string fecha_creacion_fin { get; set; }

    }

    [DataContract]
    public class Portafolio_Response
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string fecha_creacion { get; set; }

        [DataMember]
        public string categoria { get; set; }

        [DataMember]
        public string prioridad { get; set; }

        [DataMember]
        public string responsable { get; set; }

        [DataMember]
        public int codigo_portafolio { get; set; }

        [DataMember]
        public string co_estado { get; set; }
    }

    [DataContract]
    public class PopUp_Portafolio_Response
    {
        [DataMember]
        public List<Portafolio_Iniciativas> iniciativas { get; set; }
        [DataMember]
        public List<Portafolio_Componentes> componentes { get; set; }
        [DataMember]
        public Prt_Datos objeto {get; set;}
        [DataMember]
        public List<Combo> cbo_categoria { get; set; }
        [DataMember]
        public List<Combo> cbo_prioridad { get; set; }
    }

    [DataContract]
    public class Portafolio_Iniciativas
    {
        [DataMember]
        public int nid_relacion { get; set; }

        [DataMember]
        public int nid_iniciativa { get; set; }

        [DataMember]
        public string no_codigo { get; set; }

        [DataMember]
        public string no_nombre { get; set; }
    }

    [DataContract]
    public class Portafolio_Componentes
    {
        [DataMember]
        public int nid_componente { get; set; }

        [DataMember]
        public string no_codigo { get; set; }

        [DataMember]
        public string no_componente { get; set; }

        [DataMember]
        public string no_tipo { get; set; }

        [DataMember]
        public string no_fecha_inicio { get; set; }

        [DataMember]
        public string no_fecha_fin { get; set; }

        [DataMember]
        public string no_prioridad { get; set; }

         [DataMember]
        public string no_responsable { get; set; }

         [DataMember]
        public string co_estado { get; set; }
    }

    [DataContract]
    public class Combo
    {
        [DataMember]
        public int codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }
    }

    [DataContract]
    public class Responsable_Response
    {
        [DataMember]
        public int nid_usuario { get; set; }
        [DataMember]
        public string no_usrlogin { get; set; }
        [DataMember]
        public string no_nombre { get; set; }
    }

    [DataContract]
    public class Responsable_Request
    {
        [DataMember]
        public string no_nombre { get; set; }
    }

    [DataContract]
    public class Iniciativa_Response
    {
        [DataMember]
        public int nid_iniciativa{ get; set; }
        [DataMember]
        public string no_codigo { get; set; }
        [DataMember]
        public string no_nombre { get; set; }
    }

    [DataContract]
    public class Iniciativa_Request
    {
        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public int nid_portafolio { get; set; }
    }


    [DataContract]
    public class AsociarIniciativa_Request
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
        [DataMember]
        public int nid_iniciativa { get; set; }
    }


    [DataContract]
    public class DesAsociarIniciativa_Request
    {
        [DataMember]
        public int nid_relacion { get; set; }
        [DataMember]
        public int nid_portafolio { get; set; }
    }

    [DataContract]
    public class Componente_Response
    {
        [DataMember]
        public int nid_codigo { get; set; }

        [DataMember]
        public string no_codigo { get; set; }

        [DataMember]
        public string no_componente { get; set; }

        [DataMember]
        public string no_tipo { get; set; }

        [DataMember]
        public string no_fecha_inicio { get; set; }

        [DataMember]
        public string no_fecha_fin { get; set; }

        [DataMember]
        public string no_prioridad { get; set; }

        [DataMember]
        public string no_responsable { get; set; }

        [DataMember]
        public string co_estado { get; set; }
    }

    [DataContract]
    public class Componente_Request
    {
        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public string co_tipo { get; set; }
        [DataMember]
        public int nid_portafolio { get; set; }
    }

    [DataContract]
    public class AsociarComponente_Request
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public int? nid_proyecto { get; set; }
        [DataMember]
        public int? nid_programa { get; set; }
    }


    [DataContract]
    public class DesAsociarComponente_Request
    {
        [DataMember]
        public int nid_componente { get; set; }
        [DataMember]
        public int nid_portafolio { get; set; }
    }

    [DataContract]
    public class EliminarPortafolio_Request
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
    }

    [DataContract]
    public class EliminarPortafolio_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

    [DataContract]
    public class ActualizarPortafolio_Request
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public int nid_categoria { get; set; }
        [DataMember]
        public int nid_prioridad { get; set; }
        [DataMember]
        public int nid_responsable { get; set; }
        [DataMember]
        public int nid_responsable2 { get; set; }
        [DataMember]
        public string tx_descripcion { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
    }

    [DataContract]
    public class ActualizarPortafolio_Response
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public string no_codigo { get; set; }
        [DataMember]
        public string no_mensaje { get; set; }
    }
}