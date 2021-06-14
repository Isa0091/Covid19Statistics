using Covid19Statistics.Dto.Region;
using Covid19Statistics.Dto.Stadistics;
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

        public HomeController(
            ICovid19StatisticsService covid19StatisticsService,
            IRegionsService regionsService)
        {
            _covid19StatisticsService = covid19StatisticsService;
            _regionsService = regionsService;
        }

        public async Task<IActionResult> Index(string Iso)
        {
            ReportDetailOutput reportDetailOutput = new ReportDetailOutput()
            {
                 RegionIso= Iso
            };

            List<RegionOutputDto>  listRegionOutputDto = await _regionsService.GetRegionsAsync();
            List<RegionOutput> regionOutputs = listRegionOutputDto.Select(z => new RegionOutput()
            {
                 Iso=z.Code,
                 Name= z.Name

            }).ToList();

            reportDetailOutput.ListRegion = regionOutputs;

            if (string.IsNullOrEmpty(Iso))
            {
                List<RegionStadisticsOutputDto> regionStadistics = await _covid19StatisticsService.GetTopCasesCovidByRegions();

                reportDetailOutput.ReportDataOutput= regionStadistics.Select(z => new ReportDataOutput()
                {
                     Name= z.Name,
                     Cases= z.Confirmed,
                     Deaths= z.Deaths
                }).ToList();
            }

            if (string.IsNullOrEmpty(Iso)==false)
            {
                List<ProvincesStadisticsOutputDto> provincesStadisticsOutputs = 
                    await _covid19StatisticsService.GetTopCasesCovidFilter(new FilterCovid19Statistics(){ 
                       RegionIsoCode= Iso
                });
                reportDetailOutput.ReportDataOutput = provincesStadisticsOutputs.Select(z => new ReportDataOutput()
                {
                    Name = z.Name,
                    Cases = z.Confirmed,
                    Deaths = z.Deaths
                }).ToList();
            }


            string data = SerializeXmlRequest<List<ReportDataOutput>>(reportDetailOutput.ReportDataOutput);
            var result = System.Text.Encoding.Unicode.GetBytes(data);

            return File(result, "application/xml", $"export_{DateTime.UtcNow.Ticks}.xml");

            byte[] data2= SerializeCsv(reportDetailOutput.ReportDataOutput);
            return File(data2, "text/csv", $"export_{DateTime.UtcNow.Ticks}.csv");

            return View(reportDetailOutput);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Serializa una clase a xml
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string SerializeXmlRequest<T>(T data)
        {
            XmlSerializer xsSubmit = new XmlSerializer(data.GetType());
            var xmlrequest = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, data);
                    xmlrequest = sww.ToString();
                }

            }

            return xmlrequest;
        }


        /// <summary>
        /// Serializa una clase a xml
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string SerializeJson<T>(T data)
        {
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// Serializa una clase a xml
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] SerializeCsv<T>(IEnumerable<T> data)
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(data);
                    }// The stream gets flushed here.
                }
                return ms.ToArray();
            }

      }
    }
}
