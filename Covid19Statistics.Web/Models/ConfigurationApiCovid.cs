using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Statistics.Web.Models
{
    public class ConfigurationApiCovid
    {
        /// <summary>
        /// url base of covid api
        /// </summary>
        public string UrlBaseApi { get; set; }

        /// <summary>
        /// Api key of api covid
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Host ofapi
        /// </summary>
        public string ApiHost { get; set; }
    }
}
