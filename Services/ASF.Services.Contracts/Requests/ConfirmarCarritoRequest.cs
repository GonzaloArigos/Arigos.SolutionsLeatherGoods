﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;

namespace ASF.Services.Contracts.Requests
{
    [DataContract]
    public class ConfirmarCarritoRequest
    {
        [DataMember]
        public string User { get; set; }
    }
}
