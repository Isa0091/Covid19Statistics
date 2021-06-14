﻿using Covid19Statistics.Dto.Stadistics;
using Covid19Statistics.Repo;
using Covid19Statistics.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Statistics.Services
{
    public class Covid19StatisticsService : ICovid19StatisticsService
    {
        private readonly ICovid19StatisticsRepo _covid19StatisticsRepo;
        public Covid19StatisticsService(
            ICovid19StatisticsRepo covid19StatisticsRepo)
        {
            _covid19StatisticsRepo = covid19StatisticsRepo;
        }


        public async Task<List<RegionStadisticsOutputDto>> GetTopCasesCovidByRegions()
        {
            List<RegionStadisticsOutputDto> regionStadisticsOutputDtos = new List<RegionStadisticsOutputDto>();

            List<Covid19StatisticsOutputDto> listCovidStadistic=await _covid19StatisticsRepo.GetCovid19StatisticsAsync();

            regionStadisticsOutputDtos=listCovidStadistic.GroupBy(z => z.IsocodeRegion).Select(a => new RegionStadisticsOutputDto() {

                 Confirmed= a.Sum(x=>x.Cities.Sum(a=>a.Confirmed)),
                 Deaths= a.Sum(x => x.Cities.Sum(a => a.Deaths)),
                 Name= a.First().RegionName

            }).ToList();

            return regionStadisticsOutputDtos.OrderByDescending(z=> z.Confirmed)
                .OrderByDescending(z =>z.Deaths).Take(10).ToList();
        }


        public async Task<List<ProvincesStadisticsOutputDto>> GetTopCasesCovidFilter(FilterCovid19Statistics filterCovid19Statistics)
        {
            List<ProvincesStadisticsOutputDto> provincesStadistics = new List<ProvincesStadisticsOutputDto>();

            List<Covid19StatisticsOutputDto> listCovidStadistic = await _covid19StatisticsRepo.GetCovid19StatisticsAsync(filterCovid19Statistics);

            provincesStadistics = listCovidStadistic.Select(a => new ProvincesStadisticsOutputDto()
            {

                Confirmed = a.Cities.Sum(z=>z.Confirmed),
                Deaths = a.Cities.Sum(z => z.Deaths),
                Name = a.ProvinceName

            }).ToList();

            return provincesStadistics.OrderByDescending(z => z.Confirmed)
               .OrderByDescending(z => z.Deaths).Take(10).ToList();
        }
    }
}