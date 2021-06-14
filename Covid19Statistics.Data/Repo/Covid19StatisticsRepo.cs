using Covid19Statistics.Data.Covid19Api;
using Covid19Statistics.Data.OpenAPIs.Dto;
using Covid19Statistics.Dto.Stadistics;
using Covid19Statistics.Repo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Statistics.Data.Repo
{
    public class Covid19StatisticsRepo : ICovid19StatisticsRepo
    {
        public Covid19Api.Api _covidApi;
        public Covid19StatisticsRepo(Covid19Api.Api covidApi)
        {
            _covidApi = covidApi;
        }
        public async Task<List<Covid19StatisticsOutputDto>> GetCovid19StatisticsAsync(FilterCovid19Statistics filterCovid)
        {

            ReportListPaginated  reportListPaginated =await _covidApi.ReportsAsync(filterCovid.Date, null,filterCovid.RegionIsoCode,null,filterCovid.ProvinceName,null,(int?)null);
            List<Province> DataProvincesResponse =reportListPaginated.Data.ToList();
            List<Covid19StatisticsOutputDto> covid19StatisticsOutputDto = GetCovid19Statistics(DataProvincesResponse);
            return covid19StatisticsOutputDto;

        }

        public async Task<List<Covid19StatisticsOutputDto>> GetCovid19StatisticsAsync()
        {
            ReportListPaginated reportListPaginated = await _covidApi.ReportsAsync(null, null, null, null,null, null, (int?)null);
            List<Province> DataProvincesResponse = reportListPaginated.Data.ToList();
            List<Covid19StatisticsOutputDto> covid19StatisticsOutputDto = GetCovid19Statistics(DataProvincesResponse);
            return covid19StatisticsOutputDto;
        }


        #region Private methods
        private List<Covid19StatisticsOutputDto> GetCovid19Statistics(List<Province> provinces)
        {
            List<Covid19StatisticsOutputDto> covid19StatisticsOutputDto = new List<Covid19StatisticsOutputDto>();
            foreach (Province province in provinces)
            {
                List<Covid19StatisticsCitiesOutputDto> listCities = new List<Covid19StatisticsCitiesOutputDto>();
                KeyValuePair<string, object> dataCovid = province.AdditionalProperties.FirstOrDefault(z => z.Key == "region");
                DataStadisticsProvince dataStadistics = null;

                if (dataCovid.Value != null)
                {
                   string dataProvince= JsonConvert.SerializeObject(dataCovid.Value);
                    dataStadistics = JsonConvert.DeserializeObject<DataStadisticsProvince>(dataProvince);
                    dataStadistics.cities.ForEach(z =>
                        {
                            listCities.Add(new Covid19StatisticsCitiesOutputDto()
                            {
                                Confirmed = z.Confirmed,
                                Date = z.Date,
                                Deaths = z.Deaths,
                                Name = z.Name

                            });
                        });
                }

                KeyValuePair<string, object> confirmed = province.AdditionalProperties.FirstOrDefault(z => z.Key == "confirmed");
                KeyValuePair<string, object> deaths = province.AdditionalProperties.FirstOrDefault(z => z.Key == "deaths");

                covid19StatisticsOutputDto.Add(new Covid19StatisticsOutputDto()
                {
                    Cities = listCities,
                    IsoCodeRegion = dataStadistics?.ISO,
                    ProvinceName = dataStadistics?.Province,
                    RegionName = dataStadistics?.Name,
                    Confirmed= confirmed.Value != null ? Convert.ToInt32(confirmed.Value) : 0,
                    Deaths= deaths.Value != null ? Convert.ToInt32(deaths.Value) : 0
                });
            }

            return covid19StatisticsOutputDto;
        }

        #endregion
    }
}
