using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Statistics.Web.Models.Report
{
    public class ReportDataOutput
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cases
        /// </summary>
        public int Cases { get; set; }

        /// <summary>
        /// Deaths
        /// </summary>
        public int Deaths { get; set; }
    }
}
