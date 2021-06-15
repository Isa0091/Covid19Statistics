using Covid19Stadistics.Dto.Stadistics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Service
{
    public interface ICovid19StadisticsService
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
        Task<List<ProvincesStadisticsOutputDto>> GetTopCasesCovidFilter(FilterCovid19Stadistics filterCovid19Statistics);
    }
}
