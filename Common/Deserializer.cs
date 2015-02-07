using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Boytrix.Logic.Business.Common
{
    public class Deserializer
    {

        public static T Deserialize<T>(XDocument doc)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (var reader = doc.Root.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static string CleanEmptyTags(String xml)
        {
            Regex regex = new Regex(@"(\s)*<(\w)*(\s)*/>");
            return regex.Replace(xml, string.Empty);
        }
     
        public static IEnumerable<T> DeserializeParams<T>(XDocument doc)
        {

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "UsersUsersGroups";
            //xRoot.Namespace = "http://www.medicanimal.com";
            xRoot.IsNullable = true;

            string d = doc.ToString().Replace("\r\n", string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);

            XmlReader reader = doc.CreateReader();

            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return result;
            //mlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);
        }

        public static List<T> DeSerializeObject<T>(string elementName, string theXml)
        {
            try
            {
               


                XDocument doc = XDocument.Parse(theXml);

                //var xdoc = new XDocument(new XElement("Root", doc.Root));

                XDocument xdoc = new XDocument(
                        new XDeclaration("1.0", "utf-16", "yes"),
                        new XElement(elementName,
                       doc.Descendants(elementName).Elements()
                       )
               );


              

                XmlRootAttribute xRoot = new XmlRootAttribute();

                xRoot.ElementName = elementName;
                xRoot.IsNullable = false;




                XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);


                XmlReader reader = xdoc.CreateReader();


                List<T> result = (List<T>)serializer.Deserialize(reader);
                reader.Close();

                return result;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }


    }
}

