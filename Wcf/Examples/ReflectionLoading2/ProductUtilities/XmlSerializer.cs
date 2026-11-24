using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SystemXmlSerializer = System.Xml.Serialization.XmlSerializer;

namespace ProductUtilities
{
    public class XmlSerializer<T> where T : class
    {
        public static string ObjectToXml(T obj)
        {

            string result = string.Empty;
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                {
                    var x = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    x.Serialize(xmlWriter, obj);
                }
                // we just output back to the console for this demo.
                memoryStream.Position = 0; // rewind the stream before reading back.
                using (StreamReader sr = new StreamReader(memoryStream))
                {
                    result = sr.ReadToEnd();
                } // note memory stream disposed by StreamReaders Dispose()
            }
            return result;
        }

        //public static string ObjectToXml(T obj)
        //{
        //    var xmlSerializer = new SystemXmlSerializer(typeof(T));

        //    using (var writer = new StringWriter())
        //    {                
        //        xmlSerializer.Serialize(writer, obj);

        //        return writer.ToString();
        //    }
        //}

        public static T XmlToObject(string xml)
        {
            var xmlSerializer = new SystemXmlSerializer(typeof(T));

            using (var reader = new StringReader(xml))
            {
                return xmlSerializer.Deserialize(reader) as T;
            }
        }
    }

    public class XmlSerializer
    {
        //public string Serialize(object obj)
        //{
        //    var xmlSerializer = new SystemXmlSerializer(obj.GetType());

        //    using (var writer = new StringWriter())
        //    {
        //        xmlSerializer.Serialize(writer, obj);

        //        return writer.ToString();
        //    }
        //}

        public string Serialize(object obj)
        {

            string result = string.Empty;
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                {
                    var x = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                    x.Serialize(xmlWriter, obj);
                }
                // we just output back to the console for this demo.
                memoryStream.Position = 0; // rewind the stream before reading back.
                using (StreamReader sr = new StreamReader(memoryStream))
                {
                    result = sr.ReadToEnd();
                } // note memory stream disposed by StreamReaders Dispose()
            }
            return result;
        }

        public object XmlToObject(Type type, string xml)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
            using (var reader = new StringReader(xml))
            {
                return xmlSerializer.Deserialize(reader);
            }
        }
    }
}
