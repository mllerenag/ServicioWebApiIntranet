using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{


        [DataContract]
        public class PortafolioResponse
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
            public string fecha_creacion { get; set; }



        }
}