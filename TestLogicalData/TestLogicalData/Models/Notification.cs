using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogicalData.Models
{
    public class Notification
    {
        [JsonProperty(PropertyName = "title")]
        public string titulo { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string mensaje { get; set; }
    }
}
