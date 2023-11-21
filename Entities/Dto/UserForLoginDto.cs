using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class UserForLoginDto 
    {
        [JsonPropertyName("app_id"), DefaultValue("077faac7dba364b3f058193de9fea2e6")]
        public string AppId { get; set; }
        [JsonPropertyName("app_secret"), DefaultValue("bb18138fbd6fe9a2512e8933e6f37a01")]
        public string AppSecret { get; set; }
    }
}
