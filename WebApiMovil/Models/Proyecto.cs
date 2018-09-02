using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{

    [DataContract]
    public class Prt_Datos_Proyecto
    {
        [DataMember]
        public int nid_proyecto { get; set; }

        [DataMember]
        public string no_codigo { get; set; }

        [DataMember]
        public string fe_crea { get; set; }

        [DataMember]
        public string fe_inicio { get; set; }

        [DataMember]
        public string fe_fin { get; set; }

        [DataMember]
        public string no_nombre { get; set; }

        [DataMember]
        public string no_prioridad { get; set; }

        [DataMember]
        public string no_responsable { get; set; }

        [DataMember]
        public string no_estado { get; set; }


        [DataMember]
        public string no_descripcion { get; set; }

        [DataMember]
        public int nid_prioridad { get; set; }

        [DataMember]
        public int nid_responsable { get; set; }


    }
    [DataContract]
    public class ProyectoI_Request
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public int codigo_proyecto { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string fecha_creacion_ini { get; set; }

        [DataMember]
        public string fecha_creacion_fin { get; set; }

    }

    [DataContract]
    public class ProyectoI_Response
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
        public string fecha_inicio { get; set; }

        [DataMember]
        public string fecha_fin { get; set; }

        [DataMember]
        public string prioridad { get; set; }

        [DataMember]
        public string responsable { get; set; }

        [DataMember]
        public int codigo_proyecto { get; set; }

        [DataMember]
        public string co_estado { get; set; }
    }

    [DataContract]
    public class EliminarProyecto_Request
    {
        [DataMember]
        public int nid_proyecto { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
    }

    [DataContract]
    public class EliminarProyecto_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

    [DataContract]
    public class ActualizarProyecto_Request
    {
        [DataMember]
        public int nid_proyecto { get; set; }
        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public int nid_prioridad { get; set; }
        [DataMember]
        public int nid_responsable { get; set; }

        [DataMember]
        public string tx_descripcion { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
        [DataMember]
        public string fecha_inicio { get; set; }

        [DataMember]
        public string fecha_fin { get; set; }
    }

    [DataContract]
    public class ActualizarProyecto_Response
    {
        [DataMember]
        public int nid_proyecto { get; set; }
        [DataMember]
        public string no_codigo { get; set; }
        [DataMember]
        public string no_mensaje { get; set; }
    }


    public class PopUp_Proyecto_Response
    {
        [DataMember]
        public Prt_Datos_Proyecto objeto {get; set;}
        [DataMember]
        public List<Combo> cbo_prioridad { get; set; }
    }

}
