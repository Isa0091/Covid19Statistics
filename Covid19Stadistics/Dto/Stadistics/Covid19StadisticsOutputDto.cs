using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Stadistics.Dto.Stadistics
{
    /// <summary>
    /// data that returns
    /// </summary>
    public class Covid19StadisticsOutputDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Covid19StadisticsOutputDto()
        {
            Cities = new List<Covid19StadisticsCitiesOutputDto>();
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsoCodeRegion { get; set; }
        /// <summary>
        /// province of the stadistics
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// Cases confirmed
        /// </summary>
        public int Confirmed { get; set; }
        /// <summary>
        /// Cases death
        /// </summary>
        public int Deaths { get; set; }
        /// <summary>
        /// Cities
        /// </summary>
        public List<Covid19StadisticsCitiesOutputDto> Cities { get; set; }
    }
}
