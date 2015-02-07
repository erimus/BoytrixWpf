using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Boytrix.Logic.DataTransfer.Materializer
{
    public static  class  BoytrixSerializer
    {


        public static string SerializeParams<T>( List<T> paramList)
        {

            XDocument doc = new XDocument();
       
            XmlSerializer serializer = new XmlSerializer(paramList.GetType());

            XmlWriter writer = doc.CreateWriter();

            serializer.Serialize(writer, paramList);

            writer.Close();

            return doc.ToString();
        }

        public static string SerializeObject<T>(
                               Encoding encoding,
                               XmlSerializerNamespaces ns,
                               bool omitDeclaration,
                               List<T> paramList)
        {
            MemoryStream ms = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(paramList.GetType());
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = false;
            settings.OmitXmlDeclaration = omitDeclaration;
            settings.Encoding = encoding;
            XmlWriter writer = XmlWriter.Create(ms, settings);
            serializer.Serialize(writer, paramList, ns);
            return encoding.GetString(ms.ToArray()); ;
        }


    


        public static string SerializeObject<T>(T obj)
        {
            try
            {
                string xmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(T));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                xmlString = UTF8ByteArrayToString(memoryStream.ToArray()); return xmlString;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static List<T> DeserializeParams<T>(string elementName, string theXml)
        {

            string str =
                     @"<?xml version='1.0' encoding='utf-16'?>" + theXml;

            XDocument doc = XDocument.Parse(str);

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Root";
            //xRoot.Namespace = "http://www.medicanimal.com";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);

            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            XmlReader reader = doc.CreateReader();


            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }

        public static List<T> DeserializeParams<T>(string theXml)
        {
            //Load the xml string into a document
            //Get the Root element Name so it knows what the list consists off.
            //

        
            string str =
                     @"<?xml version='1.0' encoding='utf-16'?>" + theXml ;

            XDocument doc = XDocument.Parse(str);

            XElement el1 = doc.Root;

            string elementName = el1.Name.ToString();

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = elementName;
            //xRoot.Namespace = "http://www.medicanimal.com";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), xRoot);

            //System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

            XmlReader reader = doc.CreateReader();

           
            List<T> result = (List<T>)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }


        static public String UTF8ByteArrayToString(Byte[] characters)
        {

            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return constructedString;
        }

        static public Byte[] StringToUTF8ByteArray(String pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }


    }
}
