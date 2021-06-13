using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Statistics.Dto.Stadistics
{
    /// <summary>
    /// data that returns
    /// </summary>
    public class Covid19StatisticsOutputDto
    {
        /// <summary>
        /// province of the stadistics
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// number of cases
        /// </summary>
        public string Cases { get; set; }

        /// <summary>
        /// Deaths
        /// </summary>
        public string Deaths { get; set; }
    }
}
