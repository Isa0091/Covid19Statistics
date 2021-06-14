using Covid19Statistics.Dto.Region;
using Covid19Statistics.Repo;
using Covid19Statistics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Statistics.Services
{
    public class RegionsService : IRegionsService
    {
        private readonly IRegionsRepo _regionsRepo;
        public RegionsService(
            IRegionsRepo regionsRepo)
        {
            _regionsRepo = regionsRepo;
        }
        public async Task<List<RegionOutputDto>> GetRegionsAsync()
        {
            List<RegionOutputDto> regionOutputs = await _regionsRepo.GetRegionsAsync();
            return regionOutputs.OrderBy(z => z.Name).ToList();
        }
    }
}
