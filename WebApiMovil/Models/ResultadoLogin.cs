using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebApiMovil.Models
{
    [DataContract]
    public class ResultadoLogin
    {
        [DataMember]
        public string msj { get; set; }

        [DataMember]
        public string user { get; set; }

        [DataMember]
        public string pwd { get; set; }

        [DataMember]
        public int user_code { get; set; }

        [DataMember]
        public int nid_perfil { get; set; }
        [DataMember]
        public string nombreusuario { get; set; }
    }
}