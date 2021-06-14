using Covid19Statistics.Dto.Stadistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Statistics.Service
{
    public interface ICovid19StatisticsService
    {
        /// <summary>
        /// get data Top cases by regions
        /// </summary>
        /// <returns></returns>
        Task<List<RegionStadisticsOutputDto>> GetTopCasesCovidByRegions();

        /// <summary>
        /// Get top cases filter
        /// </summary>
        /// <param name="filterCovid19Statistics"></param>
        /// <returns></returns>
        Task<List<ProvincesStadisticsOutputDto>> GetTopCasesCovidFilter(FilterCovid19Statistics filterCovid19Statistics);
    }
}
