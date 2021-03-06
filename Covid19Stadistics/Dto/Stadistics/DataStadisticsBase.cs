using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Stadistics.Dto.Stadistics
{
    public class DataStadisticsBase
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
