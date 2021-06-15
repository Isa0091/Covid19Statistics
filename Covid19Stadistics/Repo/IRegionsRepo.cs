using Covid19Stadistics.Dto.Region;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Repo
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
