using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAuthSystem.Application.DTOs.Account
{
    public class MetricStatisticDTO
    {
        [JsonProperty("Period")]
        public string Period { get; set; }
        [JsonProperty("Value")]
        public int Value { get; set; }
    }
}
