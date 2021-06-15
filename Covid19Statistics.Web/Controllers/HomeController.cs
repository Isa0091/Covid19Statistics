using Covid19Statistics.Dto.Region;
using Covid19Statistics.Dto.Stadistics;
using Covid19Statistics.Providers;
using Covid19Statistics.Service;
using Covid19Statistics.Web.Models;
using Covid19Statistics.Web.Models.Report;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Covid19Statistics.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICovid19StatisticsService _covid19StatisticsService;
        private readonly IRegionsService _regionsService;
        private readonly ICsvConvertProvider _csvConvertProvider;
        private readonly IJsonConvertProvider _jsonConvertProvider;
        private readonly IXmlConvertProvider _xmlConvertProvider;
        public HomeController(
            ICovid19StatisticsService covid19StatisticsService,
            IRegionsService regionsService,
            ICsvConvertProvider csvConvertProvider,
            IJsonConvertProvider jsonConvertProvider,
            IXmlConvertProvider xmlConvertProvider)
        {
            _covid19StatisticsService = covid19StatisticsService;
            _regionsService = regionsService;
            _csvConvertProvider = csvConvertProvider;
            _jsonConvertProvider = jsonConvertProvider;
            _xmlConvertProvider = xmlConvertProvider;

        }

        [HttpGet]
        public async Task<IActionResult> Index(string iso)
        {
            ReportDetailOutput reportDetailOutput = new ReportDetailOutput()
            {
                RegionIso = iso
            };

            List<RegionOutputDto> listRegionOutputDto = await _regionsService.GetRegionsAsync();
            List<RegionOutput> regionOutputs = listRegionOutputDto.Select(z => new RegionOutput()
            {
                Iso = z.Code,
                Name = z.Name

            }).ToList();

            reportDetailOutput.ListRegion = regionOutputs;
            reportDetailOutput.ReportDataOutput = await GetListReportOutput(iso);

            return View(reportDetailOutput);
        }


        [HttpGet]
        public async Task<IActionResult> GetXmlReport(string iso)
        {
            List<ReportDataOutput> reportData = await GetListReportOutput(iso);
            byte[] result = _xmlConvertProvider.ConvertToXml<List<ReportDataOutput>>(reportData);
            return File(result, "application/xml", $"ReportCovid_{DateTime.UtcNow.Date.ToString("dd/MM/yyyy")}.xml");
        }

        [HttpGet]
        public async Task<IActionResult> GetJsonReport(string iso)
        {
            List<ReportDataOutput> reportData = await GetListReportOutput(iso);
            byte[] result = _jsonConvertProvider.ConvertToJson<List<ReportDataOutput>>(reportData);
            return File(result, "application/json", $"ReportCovid_{DateTime.UtcNow.Date.ToString("dd/MM/yyyy")}.json");
        }

        [HttpGet]
        public async Task<IActionResult> GetCsvReport(string iso)
        {
            List<ReportDataOutput> reportData = await GetListReportOutput(iso);
            byte[] result = _csvConvertProvider.ConverToCsv<ReportDataOutput>(reportData);
            return File(result, "text/csv", $"ReportCovid_{DateTime.UtcNow.Date.ToString("dd/MM/yyyy")}.csv");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region private class

        /// <summary>
        /// Get data for the report
        /// </summary>
        /// <param name="iso"></param>
        /// <returns></returns>
        private async Task<List<ReportDataOutput>> GetListReportOutput(string iso)
        {

            List<ReportDataOutput> ReportDataOutput = new List<ReportDataOutput>();
            if (string.IsNullOrEmpty(iso))
            {
                List<RegionStadisticsOutputDto> regionStadistics = await _covid19StatisticsService.GetTopCasesCovidByRegions();

                ReportDataOutput = regionStadistics.Select(z => new ReportDataOutput()
                {
                    Name = z.Name,
                    Cases = z.Confirmed,
                    Deaths = z.Deaths
                }).ToList();
            }

            if (string.IsNullOrEmpty(iso) == false)
            {
                List<ProvincesStadisticsOutputDto> provincesStadisticsOutputs =
                    await _covid19StatisticsService.GetTopCasesCovidFilter(new FilterCovid19Statistics()
                    {
                        RegionIsoCode = iso
                    });
                ReportDataOutput = provincesStadisticsOutputs.Select(z => new ReportDataOutput()
                {
                    Name = z.Name,
                    Cases = z.Confirmed,
                    Deaths = z.Deaths
                }).ToList();
            }


            return ReportDataOutput;
        }
        #endregion
    }
}
