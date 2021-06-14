using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Statistics.Dto.Stadistics
{
    public class Covid19StatisticsCitiesOutputDto
    {
        /// <summary>
        /// Name of city
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Cases confirmed
        /// </summary>
        public int Confirmed { get; set; }
        /// <summary>
        /// Cases death
        /// </summary>
        public int Deaths { get; set; }
        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }

    }
}
