using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19Statistics.Providers
{
    public class JsonConvertProvider : IJsonConvertProvider
    {
        public byte[] ConvertToJson<T>(T data)
        {
            string json = JsonConvert.SerializeObject(data);
            byte[] result = System.Text.Encoding.Unicode.GetBytes(json);
            return result;
        }
    }
}
