using Covid19Statistics.Data.Covid19Api;
using Covid19Stadistics.Dto.Region;
using Covid19Stadistics.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Data.Repo
{
    public class RegionsRepo : IRegionsRepo
    {
        public Covid19Statistics.Data.Covid19Api.Api _covidApi;
        public RegionsRepo(Covid19Statistics.Data.Covid19Api.Api covidApi)
        {
            _covidApi = covidApi;
        }
        public async Task<List<RegionOutputDto>> GetRegionsAsync()
        {
            List<RegionOutputDto> listRegionsOutput = new List<RegionOutputDto>();

            RegionListPaginated regionsApi= await _covidApi.RegionsAsync(null, Covid19Statistics.Data.Covid19Api.Order.Name, Covid19Statistics.Data.Covid19Api.Sort.Asc);

            listRegionsOutput=regionsApi.Data.ToList().Select(z => new RegionOutputDto()
            {
                 Code= z.Iso,
                 Name= z.Name

            }).ToList();

            return listRegionsOutput;
        }
    }
}
