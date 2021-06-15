using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Stadistics.Providers
{
    public interface IXmlConvertProvider
    {
        /// <summary>
        /// Conver the data send in format xmls and reutn the bytes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] ConvertToXml<T>(T data);
    }
}
