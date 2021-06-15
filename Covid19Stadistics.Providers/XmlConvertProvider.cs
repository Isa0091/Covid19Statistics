using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Covid19Stadistics.Providers
{
    public class XmlConvertProvider : IXmlConvertProvider
    {
        public byte[] ConvertToXml<T>(T data)
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

            if(!string.IsNullOrEmpty(xmlrequest))
                return  System.Text.Encoding.Unicode.GetBytes(xmlrequest);

            return null;
        }

    }
}
