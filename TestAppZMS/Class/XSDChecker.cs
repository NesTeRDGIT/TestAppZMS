using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace TestAppZMS.Class
{

    public interface IXSDChecker
    {
        List<string> Check(string path);
        Task<List<string>> CheckAsync(string path);
    }

    public class XSDChecker: IXSDChecker
    {
        private string XSDPath { get; set; }
      
        public XSDChecker(string XSDPath)
        {
            this.XSDPath = XSDPath;
        }

        public List<string> Check(string path)
        {
            var errList = new List<string>();
            var xmlSettings = new XmlReaderSettings();
            xmlSettings.Schemas.Add(null, XSDPath);
            xmlSettings.ValidationType = ValidationType.Schema;
            xmlSettings.ValidationEventHandler += (sender, e) =>
            {
                switch (e.Severity)
                {
                    case XmlSeverityType.Error:
                        errList.Add($"ERROR: [{ e.Exception.LineNumber},{e.Exception.LinePosition}] {e.Message}");
                        break;
                    case XmlSeverityType.Warning:
                        errList.Add($"WARNING: [{ e.Exception.LineNumber},{e.Exception.LinePosition}] {e.Message}");
                        break;
                }

            };
            //XmlSettings_ValidationEventHandler;
            using var r = new XmlTextReader(path);
            using var reader = XmlReader.Create(r, xmlSettings);
            while (reader.Read())
            {
            }
            return errList;
        }

        public Task<List<string>> CheckAsync(string path)
        {
            return Task.Run(() => Check(path));
        }

    }
}
