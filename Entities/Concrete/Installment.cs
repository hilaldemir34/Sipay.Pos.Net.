using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Installment
    {
        [JsonPropertyName("credit_card")]
        public string credit_card { get; set; }

        [JsonPropertyName("amount")]
        public double amount { get; set; }

        [JsonPropertyName("currency_code")]
        public string currency_code { get; set; }

        [JsonPropertyName("merchant_key")]
        public string merchant_key { get; set; }

        [JsonPropertyName("is_recuring")]
        public bool is_recurring { get; set; }

        [JsonPropertyName("is_2d")]
        public bool is_2d { get; set; }

      
      
    }
}
