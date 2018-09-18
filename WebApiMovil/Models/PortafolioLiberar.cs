using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{

    [DataContract]
    public class PortafolioLiberar_Request
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public int codigo_portafolio { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string tipo_filtro { get; set; }

        [DataMember]
        public int codigo_filtro { get; set; }
    }

    [DataContract]
    public class PortafolioLiberar_Response
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string descripcion { get; set; }

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
    public class RecursolioLiberar_Response
    {
        [DataMember]
        public int codigo_recurso { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public int total { get; set; }

        [DataMember]
        public int adicional { get; set; }
    }

    [DataContract]
    public class ComponenteCerrado_Response
    {
        [DataMember]
        public int codigo_componente { get; set; }

        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public int tipo_componente { get; set; }

        [DataMember]
        public string prioridad { get; set; }
    }

    [DataContract]
    public class RecursosComponente_Response
    {
        [DataMember]
        public int codigo_componente { get; set; }

        [DataMember]
        public string componente { get; set; }

        [DataMember]
        public string prioridad { get; set; }

        [DataMember]
        public int codigo_recurso { get; set; }

        [DataMember]
        public string recurso { get; set; }

        [DataMember]
        public int total_recurso { get; set; }
    }

    [DataContract]
    public class LiberarRecursoComponente_Request
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public int nid_componente { get; set; }
        [DataMember]
        public int nid_recurso { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
    }

    [DataContract]
    public class LiberarRecursoComponente_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }
}