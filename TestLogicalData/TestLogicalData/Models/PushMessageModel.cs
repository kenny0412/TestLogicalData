using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogicalData.Models
{
    public class PushMessageModel
    {
        [JsonProperty(PropertyName = "to")]
        public string token { get; set; }
        public Notification notification { get; set; }
    }
}
