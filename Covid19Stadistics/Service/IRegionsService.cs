using Covid19Stadistics.Dto.Region;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Service
{
    /// <summary>
    /// Data of reions
    /// </summary>
    public interface IRegionsService
    {
        /// <summary>
        /// Get a list of regions
        /// </summary>
        /// <returns></returns>
        Task<List<RegionOutputDto>> GetRegionsAsync();
    }
}
