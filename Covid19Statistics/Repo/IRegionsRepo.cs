using Covid19Statistics.Dto.Region;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Statistics.Repo
{
    /// <summary>
    /// Manages data access to regions
    /// </summary>
    public interface IRegionsRepo
    {
        /// <summary>
        /// get the regiones
        /// </summary>
        /// <returns></returns>
        public Task<List<RegionOutputDto>> GetRegionsAsync();
    }
}
