using Covid19Statistics.Dto.Stadistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Statistics.Repo
{
    /// <summary>
    /// Manages data access to statistics
    /// </summary>
    public interface Covid19StatisticsRepo
    {
        /// <summary>
        /// Get a list of the filtered data
        /// </summary>
        /// <param name="filterCovid">filters</param>
        /// <returns></returns>
        public List<Covid19StatisticsOutputDto> GetCovid19Statistics(FilterCovid19Statistics filterCovid);
    }
}
