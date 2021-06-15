using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Stadistics.Dto.Stadistics
{
    /// <summary>
    /// Data filter
    /// </summary>
    public class FilterCovid19Stadistics
    {

        /// <summary>
        /// Iso code of region
        /// </summary>
        public string RegionIsoCode { get; set; }

        /// <summary>
        /// Iso code of region
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }

    }
}
