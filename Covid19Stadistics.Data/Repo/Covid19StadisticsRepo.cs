using Covid19Statistics.Data.Covid19Api;
using Covid19Stadistics.Dto.Stadistics;
using Covid19Stadistics.Repo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covid19Stadistics.Data.OpenAPIs.Dto;

namespace Covid19Stadistics.Data.Repo
{
    public class Covid19StadisticsRepo : ICovid19StadisticsRepo
    {
        public Covid19Statistics.Data.Covid19Api.Api _covidApi;
        public Covid19StadisticsRepo(Covid19Statistics.Data.Covid19Api.Api covidApi)
        {
            _covidApi = covidApi;
        }
        public async Task<List<Covid19StadisticsOutputDto>> GetCovid19StadisticsAsync(FilterCovid19Stadistics filterCovid)
        {

            ReportListPaginated  reportListPaginated =await _covidApi.ReportsAsync(filterCovid.Date, null,filterCovid.RegionIsoCode,null,filterCovid.ProvinceName,null,(int?)null);
            List<Province> DataProvincesResponse =reportListPaginated.Data.ToList();
            List<Covid19StadisticsOutputDto> covid19StatisticsOutputDto = GetCovid19Stadistics(DataProvincesResponse);
            return covid19StatisticsOutputDto;

        }

        public async Task<List<Covid19StadisticsOutputDto>> GetCovid19StadisticsAsync()
        {
            ReportListPaginated reportListPaginated = await _covidApi.ReportsAsync(null, null, null, null,null, null, (int?)null);
            List<Province> DataProvincesResponse = reportListPaginated.Data.ToList();
            List<Covid19StadisticsOutputDto> covid19StatisticsOutputDto = GetCovid19Stadistics(DataProvincesResponse);
            return covid19StatisticsOutputDto;
        }


        #region Private methods
        private List<Covid19StadisticsOutputDto> GetCovid19Stadistics(List<Province> provinces)
        {
            List<Covid19StadisticsOutputDto> covid19StatisticsOutputDto = new List<Covid19StadisticsOutputDto>();
            foreach (Province province in provinces)
            {
                List<Covid19StadisticsCitiesOutputDto> listCities = new List<Covid19StadisticsCitiesOutputDto>();
                KeyValuePair<string, object> dataCovid = province.AdditionalProperties.FirstOrDefault(z => z.Key == "region");
                DataStadisticsProvince dataStadistics = null;

                if (dataCovid.Value != null)
                {
                   string dataProvince= JsonConvert.SerializeObject(dataCovid.Value);
                    dataStadistics = JsonConvert.DeserializeObject<DataStadisticsProvince>(dataProvince);
                    dataStadistics.cities.ForEach(z =>
                        {
                            listCities.Add(new Covid19StadisticsCitiesOutputDto()
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

                if(!string.IsNullOrEmpty(dataStadistics?.Province))
                covid19StatisticsOutputDto.Add(new Covid19StadisticsOutputDto()
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
