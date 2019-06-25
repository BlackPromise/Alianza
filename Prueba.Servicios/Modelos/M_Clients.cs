using System;
using System.Runtime.Serialization;

namespace Prueba.Servicios.Modelos
{
    [DataContract]
    public class M_Clients
    {
        private string id = "";
        public MongoDB.Bson.ObjectId _id { get; set; }
        //Identificador
        [DataMember]
        public string SharedKey { get => string.IsNullOrEmpty(id)? _id.ToString():id; set { id = value; } }
        //Nombre
        [DataMember]
        public string BusinessId { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public DateTime DataAdded { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public bool State { get; set; }
    }
}
