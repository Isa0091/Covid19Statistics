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
        Task<List<Covid19StatisticsOutputDto>> GetCovid19StadisticsAsync(FilterCovid19Statistics filterCovid);

        /// <summary>
        /// Get list of covid without filters
        /// </summary>
        /// <returns></returns>
        Task<List<Covid19StatisticsOutputDto>> GetCovid19StadisticsAsync();
    }
}
