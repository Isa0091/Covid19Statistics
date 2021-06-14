using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Statistics.Web.Models.Report
{
    public class RegionOutput
    {
        /// <summary>
        /// Code Iso of the regios
        /// </summary>
        public string Iso { get; set; }
        /// <summary>
        /// Name of region
        /// </summary>
        public string Name { get; set; }
    }
}
