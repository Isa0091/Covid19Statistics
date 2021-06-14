using Covid19Statistics.Dto.Stadistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Statistics.Repo
{
    /// <summary>
    /// Manages data access to statistics
    /// </summary>
    public interface ICovid19StatisticsRepo
    {
        /// <summary>
        /// Get a list of the filtered data
        /// </summary>
        /// <param name="filterCovid">filters</param>
        /// <returns></returns>
        public Task<List<Covid19StatisticsOutputDto>> GetCovid19StatisticsAsync(FilterCovid19Statistics filterCovid);
    }
}
