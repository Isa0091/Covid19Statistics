using Covid19Stadistics.Dto.Region;
using Covid19Stadistics.Repo;
using Covid19Stadistics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Services
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
