using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Statistics.Web.Models.Report
{
    public class ReportDetailOutput
    {
        /// <summary>
        /// Lista of data to the report
        /// </summary>
        public List<ReportDataOutput> ReportDataOutput { get; set; }
        /// <summary>
        /// List of region
        /// </summary>
        public List<RegionOutput> ListRegion { get; set; }
        /// <summary>
        /// Code iso if the user search a specific region
        /// </summary>
        public string RegionIso { get; set; }

        // retorna el objeto SelectList correspondiente para departamentos
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList GetSelectRegions()
        {
            return new Microsoft.AspNetCore.Mvc.Rendering.SelectList(ListRegion ?? new List<RegionOutput>(), "Iso", "Name");
        }
    }
}
