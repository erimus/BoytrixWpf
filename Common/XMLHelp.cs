using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Boytrix.Logic.Business.Common
{
    public static class XMLHelp
    {
        private static XElement _XElement;
        private static XmlSerializer ser;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static XElement XmlSerializer<T>(T obj)
        {
            try
            {
                ser = new XmlSerializer(obj.GetType());
                Stream stream = new MemoryStream();
                ser.Serialize(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(stream))
                {
                    _XElement = XElement.Load(reader);
                }
                stream.Close();
                return _XElement;
            }
            catch
            {
                return null;
            }
        }

        public static T XmlDeserialize<T>(XElement xe)
        {
            try
            {
                ser = new XmlSerializer(typeof(T));
                return (T)ser.Deserialize(xe.CreateReader());
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        public static T XmlDeserialize<T>(Type t, string xe)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xe)))
                {
                    ser = new XmlSerializer(t);

                    return (T)ser.Deserialize(ms);
                }
            }
            catch
            {
                return default(T);
            }
        }
        public static T XmlDeserialize<T>(string xe)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xe)))
                {
                    ser = new XmlSerializer(typeof(T));

                    return (T)ser.Deserialize(ms);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
