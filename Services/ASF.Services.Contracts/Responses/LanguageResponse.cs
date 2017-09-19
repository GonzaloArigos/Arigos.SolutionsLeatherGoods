using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ASF.Entities;

namespace ASF.Services.Contracts.Responses
{
    [DataContract]
    public class LanguageResponse
    {
        [DataMember]
        public Dictionary<string,string> Result;
    }
}
