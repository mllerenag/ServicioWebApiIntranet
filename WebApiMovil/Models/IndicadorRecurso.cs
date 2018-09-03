using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
namespace WebApiMovil.Models
{
    [DataContract]
    public class Filtros_Indicador_Recurso_Response
    {
        [DataMember]
        public List<Combo> recursos { get; set; }
        [DataMember]
        public List<Combo> portafolios { get; set; }
    
    }

    [DataContract]
    public class Data_Indicador_Recurso_Request
    {
        [DataMember]
        public string portafolios { get; set; }
        [DataMember]
        public string recursos { get; set; }

    }

    [DataContract]
    public class Data_Indicador_Recurso_Response
    {
        [DataMember]
        public List<Data_Indicador_Recurso> lista { get; set; }

    }

    [DataContract]
    public class Data_Indicador_Recurso
    {
        [DataMember]
        public int nid_portafolio { get; set; }

        [DataMember]
        public string no_nombre { get; set; }

        [DataMember]
        public int nid_recurso { get; set; }

        [DataMember]
        public string no_recurso { get; set; }
        [DataMember]
        public int nu_recursototal { get; set; }

        [DataMember]
        public int nu_separado { get; set; }

        [DataMember]
        public int nu_recursoconsumido { get; set; }

        [DataMember]
        public int nu_recursodisponible { get; set; }
    }

    [DataContract]
    public class Data_Indicador_Recurso_Componente_Response
    {
        [DataMember]
        public List<Data_Indicador_Recurso_Componente> lista { get; set; }

    }


    [DataContract]
    public class Data_Indicador_Recurso_Componente
    {
        [DataMember]
        public int nid_componente { get; set; }

        [DataMember]
        public string no_componente { get; set; }

        [DataMember]
        public int nu_recurso { get; set; }
    }
}