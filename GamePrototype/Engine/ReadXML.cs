using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GamePrototype.Engine
{
    public class ReadXML
    {
        XmlDocument xmlDocument;
        
        private const string mapFile = "map.tmx";

        public ReadXML()
        {
            xmlDocument = new XmlDocument();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), mapFile);
            xmlDocument.Load(filePath);
        }

        public XmlNodeList GetNodes()
        {
            return xmlDocument.DocumentElement.SelectNodes("layer");
        }

    }
}
