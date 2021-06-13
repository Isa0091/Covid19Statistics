using Covid19Statistics.Dto.Region;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<RegionOutputDto> GetRegionsAsync();
    }
}
