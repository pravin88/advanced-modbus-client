using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace Project423
{
    class XMLHelper<T1>
    {
        /// <summary>
        /// Converts a XML string to C# object
        /// </summary>
        public static T1 xmlToObject(string xmlText)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(T1));
            
            return (T1)SerializerObj.Deserialize(new StringReader(xmlText));
        }

        /// <summary>
        /// Converts a C# object into a XML string
        /// </summary>
        public static string objectToXml(T1 configuration)
        {

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(typeof(T1));

            StringWriter sw = new StringWriter();
            SerializerObj.Serialize(sw, configuration);
            return sw.ToString();
        }
        
        /// <summary>
        /// Reads the string data from the given file
        /// </summary>
        public static string readFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var stream = new StreamReader(filePath))
                {
                    return stream.ReadToEnd();
                }
            }

            return "";
        }

        public static void saveFile(string filePath, string data)
        {
            using (var stream = new StreamWriter(filePath))
            {
                stream.Write(data);
            }
        }
    }
}
