using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Statistics.Data.OpenAPIs.Dto
{

    /// <summary>
    /// data os api
    /// </summary>
    public class DataStadisticsCities
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("confirmed")]
        public int Confirmed { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }

    /// <summary>
    /// data os api
    /// </summary>
    public class DataStadisticsProvince
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("iso")]
        public string ISO { get; set; }

        [JsonProperty("Province")]
        public string Province { get; set; }

        [JsonProperty("cities")]
       public List<DataStadisticsCities> cities { get; set; }
    }


}
