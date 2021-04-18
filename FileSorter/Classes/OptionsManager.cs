using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace FileSorter.Classes
{
    public class OptionsManager
    {
        public const string Constant = "<empty>";
        private const string _fileConfigName = @"Data\AppConfiguration.xml";

        internal static Dictionary<string, string> ReadFolders()
        {
            var document = OpenDocument();
            var folder = document?.Root?.Elements("Folders");
            var folders = folder?.Elements("Folder");

            var result = new Dictionary<string, string>();
            foreach(var item in folders)
                result.Add(item.Attribute("name")?.Value, item.Attribute("path")?.Value);
            
            return result;
        }

        private static XDocument OpenDocument()
        {            
            FileInfo fi = new FileInfo(_fileConfigName);
            var di = fi.Directory;
            if (!di.Exists)
                di.Create();

            if (!fi.Exists)
            {
                using (var stream = File.Create(_fileConfigName)) { }
                CreateBaseFile(_fileConfigName);
            }

            return XDocument.Load(_fileConfigName);
        }

        private static void CreateBaseFile(string fileName)
        {
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(XName.Get("AppConfiguration"),
                new object[]
                    {
                        new XElement(XName.Get("Filter"), new XAttribute(XName.Get("value"), ""),  new XAttribute(XName.Get("splitter"), ";")),
                        new XElement(XName.Get("Folders"))
                    }));

            doc.Save(fileName);
        }

        internal static KeyValuePair<string, char> ReadFilter()
        {
            var document = OpenDocument();
            var element = document?.Root?.Elements("Filter");
            var value = element.Attributes("value").SingleOrDefault();
            var splitter = element.Attributes("splitter").SingleOrDefault();

            if (value == null && splitter == null)
                return new KeyValuePair<string, char>(Constant, ' ');
            else if (value != null && splitter != null)
                return new KeyValuePair<string, char>(value.Value, splitter.Value[0]);
            else if (value != null)
                return new KeyValuePair<string, char>(value.Value, ' ');

            return new KeyValuePair<string, char>(Constant, splitter.Value[0]);
        }

        internal static void WriteData(string filterText, string splitterText, Dictionary<string, string> updatedFolders)
        {
            var document = OpenDocument();
            var element = document?.Root?.Elements("Filter").SingleOrDefault();
            if(element == null)
                document?.Root?.Add(new XElement(XName.Get("Filter"), new XAttribute(XName.Get("value"), ""), new XAttribute(XName.Get("splitter"), "")));

            var value = element.Attributes("value").SingleOrDefault();
            var splitter = element.Attributes("splitter").SingleOrDefault();
            
            value.Value = filterText;
            splitter.Value = splitterText;

            var folder = document.Root.Elements("Folders").Single();
            var folders = folder.Elements("Folder");
            folders.Remove();

            foreach (var item in updatedFolders)
                folder.Add(new XElement(XName.Get("Folder"),
                    new XAttribute(XName.Get("name"), item.Key), 
                    new XAttribute(XName.Get("path"), String.IsNullOrEmpty(item.Value) ? string.Empty : item.Value)));

            document.Save(_fileConfigName);
        }
    }
}
