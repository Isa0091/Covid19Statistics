using Covid19Stadistics.Dto.Stadistics;
using Covid19Stadistics.Repo;
using Covid19Stadistics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Stadistics.Services
{
    public class Covid19StadisticsService : ICovid19StadisticsService
    {
        private readonly ICovid19StadisticsRepo _covid19StatisticsRepo;
        public Covid19StadisticsService(
            ICovid19StadisticsRepo covid19StatisticsRepo)
        {
            _covid19StatisticsRepo = covid19StatisticsRepo;
        }


        public async Task<List<RegionStadisticsOutputDto>> GetTopCasesCovidByRegions()
        {
            List<RegionStadisticsOutputDto> regionStadisticsOutputDtos = new List<RegionStadisticsOutputDto>();

            List<Covid19StadisticsOutputDto> listCovidStadistic=await _covid19StatisticsRepo.GetCovid19StadisticsAsync();

            regionStadisticsOutputDtos=listCovidStadistic.GroupBy(z => z.IsoCodeRegion).Select(a => new RegionStadisticsOutputDto() {

                 Confirmed= a.Sum(x=>x.Confirmed),
                 Deaths= a.Sum(x => x.Deaths),
                 Name= a.First().RegionName

            }).ToList();

            return regionStadisticsOutputDtos.OrderByDescending(z=> z.Confirmed).Take(10).ToList();
        }


        public async Task<List<ProvincesStadisticsOutputDto>> GetTopCasesCovidFilter(FilterCovid19Stadistics filterCovid19Statistics)
        {
            List<ProvincesStadisticsOutputDto> provincesStadistics = new List<ProvincesStadisticsOutputDto>();

            List<Covid19StadisticsOutputDto> listCovidStadistic = await _covid19StatisticsRepo.GetCovid19StadisticsAsync(filterCovid19Statistics);

            provincesStadistics = listCovidStadistic.Select(a => new ProvincesStadisticsOutputDto()
            {

                Confirmed = a.Confirmed,
                Deaths = a.Deaths,
                Name = a.ProvinceName

            }).ToList();

            return provincesStadistics.OrderByDescending(z => z.Confirmed).Take(10).ToList();
        }
    }
}
