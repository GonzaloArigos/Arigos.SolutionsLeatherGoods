using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ASF.Entities;

namespace ASF.Services.Contracts.Responses
{
    [DataContract]
    public class SubirImagenResponse
    {
        [DataMember]
        public int IdImage;
        public byte[] Image;
    }
}
