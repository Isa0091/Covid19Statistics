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
        /// 
        /// </summary>
        public Covid19StatisticsOutputDto()
        {
            Cities = new List<Covid19StatisticsCitiesOutputDto>();
        }
        /// <summary>
        /// 
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsocodeRegion { get; set; }
        /// <summary>
        /// province of the stadistics
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// Cities
        /// </summary>
        public List<Covid19StatisticsCitiesOutputDto> Cities { get; set; }
    }
}
