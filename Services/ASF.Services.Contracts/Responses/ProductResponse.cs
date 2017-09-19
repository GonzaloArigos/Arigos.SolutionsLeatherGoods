
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ASF.Entities;

namespace ASF.Services.Contracts.Responses
{
    [DataContract]
    public class ProductResponse
    {
        [DataMember]
       public List<Product> Productos { get; set; }
    }
}
