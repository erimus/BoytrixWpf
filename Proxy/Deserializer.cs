//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using System.Xml.Serialization;

//namespace Boytrix.Logic.DataTransfer.Materializer
//{
//    public class Deserializer
//    {
//        public static List<T> DeSerializeObject<T>(string elementName, string theXml, List<T> paramList)
//        {
//            try
//            {
               
//                string str =
//                  @"<?xml version='1.0' encoding='utf-16'?>" + theXml;

//                XDocument doc = XDocument.Parse(str);
//                XmlRootAttribute xRoot = new XmlRootAttribute();
//                xRoot.ElementName = "Root";
//                //xRoot.Namespace = "http://www.medicanimal.com";
//                xRoot.IsNullable = true;

//                XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);

//                //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

//                System.Xml.XmlReader reader = doc.CreateReader();


//                List<T> result = (List<T>)serializer.Deserialize(reader);
//                reader.Close();

//                return result;
//            }
//            catch(Exception ex)
//            {
//                throw (ex);
//            }
//        }
//    }
//}

