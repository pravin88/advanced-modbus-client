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
    class XMLHelper
    {
        /// <summary>
        /// Converts a XML string to C# object
        /// </summary>
        public static Configuration xmlToObject(string xmlText)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Configuration));

            // Load the object saved above by using the Deserialize function
            Configuration LoadedObj = (Configuration)SerializerObj.Deserialize(new StringReader(xmlText));

            return LoadedObj;
        }

        /// <summary>
        /// Converts a C# object into a XML string
        /// </summary>
        public static string objectToXml(Configuration configuration)
        {

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Configuration));

            StringWriter sw = new StringWriter();
            SerializerObj.Serialize(sw, configuration);
            return sw.ToString();
        }
    }
}
