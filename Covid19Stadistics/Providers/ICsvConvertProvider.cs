using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Stadistics.Providers
{
    public interface ICsvConvertProvider
    {
        /// <summary>
        /// Convert data of iEnumerable to Csv in byte format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] ConverToCsv<T>(IEnumerable<T> data);
    }
}
