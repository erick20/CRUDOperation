using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models.GlobalModels
{
    public class ValidationMessageModel
    {
        [JsonProperty("key")]
        public string Key { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
