using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class Monitoreo_Request
    {
        [DataMember]
        public int nid_responsable { get; set; }

        [DataMember]
        public string co_proyecto { get; set; }

        [DataMember]
        public string co_portafolio { get; set; }

        [DataMember]
        public string categoria { get; set; }
    }

    [DataContract]
    public class Monitoreo_Response
    {
        [DataMember]
        public int nid_monitoreo { get; set; }

        [DataMember]
        public int nid_proyecto { get; set; }

        [DataMember]
        public string co_proyecto { get; set; }

        [DataMember]
        public string no_proyecto { get; set; }

        [DataMember]
        public int nid_portafolio { get; set; }

        [DataMember]
        public string no_portafolio { get; set; }

        [DataMember]
        public string fecha_crea { get; set; }

        [DataMember]
        public int po_programado { get; set; }

        [DataMember]
        public int po_real { get; set; }

        [DataMember]
        public string no_estado { get; set; }
    }

    [DataContract]
    public class Tarea_Request
    {
        [DataMember]
        public int nid_proyecto { get; set; }
    }

    [DataContract]
    public class Tarea_Response
    {
        [DataMember]
        public int nid_tarea { get; set; }

        [DataMember]
        public int nid_nivel { get; set; }

        [DataMember]
        public string no_codigo { get; set; }

        [DataMember]
        public string no_nombre { get; set; }

        [DataMember]
        public string fecha_crea { get; set; }

        [DataMember]
        public string fecha_inicio { get; set; }

        [DataMember]
        public string fecha_fin { get; set; }

        [DataMember]
        public int po_programado { get; set; }

        [DataMember]
        public int po_real { get; set; }
    }

    [DataContract]
    public class GenerarMonitoreo_Request
    {
        [DataMember]
        public int nid_portafolio { get; set; }
        [DataMember]
        public int nid_proyecto { get; set; }
    }

    [DataContract]
    public class GenerarMonitoreo_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

    [DataContract]
    public class PopUp_Tarea_Response
    {
        [DataMember]
        public Prt_Datos objeto { get; set; }
        [DataMember]
        public List<Combo> cbo_nivel { get; set; }
    }

    [DataContract]
    public class GenerarTarea_Request
    {
        [DataMember]
        public List<GenerarTarea_Req> lista { get; set; }

    }

    [DataContract]
    public class GenerarTarea_Req
    {
        [DataMember]
        public int nid_proyecto { get; set; }
        [DataMember]
        public int nid_tarea { get; set; }
        [DataMember]
        public int nid_nivel { get; set; }
        [DataMember]
        public string no_codigo { get; set; }
        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public string fecha_crea { get; set; }
        [DataMember]
        public string fecha_inicio { get; set; }
        [DataMember]
        public string fecha_fin { get; set; }
    }

    [DataContract]
    public class GenerarTarea_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

    [DataContract]
    public class EditarTarea_Req
    {
        [DataMember]
        public int nid_proyecto { get; set; }
        [DataMember]
        public int nid_tarea { get; set; }
        [DataMember]
        public int nid_nivel { get; set; }
        [DataMember]
        public string no_codigo { get; set; }
        [DataMember]
        public string no_nombre { get; set; }
        [DataMember]
        public string fecha_crea { get; set; }
        [DataMember]
        public string fecha_inicio { get; set; }
        [DataMember]
        public string fecha_fin { get; set; }
        [DataMember]
        public int po_real { get; set; }
    }

    [DataContract]
    public class EditarTarea_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

    [DataContract]
    public class EliminarTarea_Request
    {
        [DataMember]
        public int nid_Tarea { get; set; }
        [DataMember]
        public int nid_usuario { get; set; }
    }

    [DataContract]
    public class EliminarTarea_Response
    {
        [DataMember]
        public string str_mensaje { get; set; }
        [DataMember]
        public int respuesta { get; set; }
    }

}