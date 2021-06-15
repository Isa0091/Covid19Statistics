using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Covid19Stadistics.Providers
{
    public class CsvConvertProvider : ICsvConvertProvider
    {
        public byte[] ConverToCsv<T>(IEnumerable<T> data)
        {
            var cc = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(stream: ms, encoding: new UTF8Encoding(true)))
                {
                    using (var cw = new CsvWriter(sw, cc))
                    {
                        cw.WriteRecords(data);
                    }
                }
                return ms.ToArray();
            }

        }
    }
}
