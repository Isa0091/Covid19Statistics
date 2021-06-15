using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Statistics.Providers
{
    public interface IJsonConvertProvider
    {
        /// <summary>
        /// Convert Data in json and return the byte
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] ConvertToJson<T>(T data);
    }
}
