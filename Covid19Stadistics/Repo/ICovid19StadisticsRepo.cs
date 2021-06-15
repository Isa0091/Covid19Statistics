using Covid19Stadistics.Dto.Stadistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Repo
{
    /// <summary>
    /// Manages data access to statistics
    /// </summary>
    public interface ICovid19StadisticsRepo
    {
        /// <summary>
        /// Get a list of the filtered data
        /// </summary>
        /// <param name="filterCovid">filters</param>
        /// <returns></returns>
        Task<List<Covid19StadisticsOutputDto>> GetCovid19StadisticsAsync(FilterCovid19Stadistics filterCovid);

        /// <summary>
        /// Get list of covid without filters
        /// </summary>
        /// <returns></returns>
        Task<List<Covid19StadisticsOutputDto>> GetCovid19StadisticsAsync();
    }
}
