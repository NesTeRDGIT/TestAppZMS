using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestAppZMS.File
{
    [Serializable]
    public class NPR_LIST
    {
        [XmlElement(nameof(ZGLV))]
        public ZGLV ZLGV { get; set; }
        [XmlElement(nameof(PACK))]
        public PACK PACK { get; set; }
        [XmlElement(nameof(ZAP))]
        public List<ZAP> ZAP { get; set; }

        public static NPR_LIST ReadFromFile(string path)
        {
            var ser = new XmlSerializer(typeof(NPR_LIST));
            using var st = System.IO.File.OpenRead(path);
            var zl = (NPR_LIST)ser.Deserialize(st);
            return zl;
        }
    }
    [Serializable]
    public class ZGLV
    {
        [XmlElement]
        public string VERSION { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime DATA { get; set; }
        [XmlElement]
        public string FILENAME { get; set; }
    }

    [Serializable]
    [XmlRoot]
    public class PACK
    {
        [XmlElement]
        public int CODE { get; set; }
        [XmlElement]
        public int YEAR { get; set; }
        [XmlElement]
        public int MONTH { get; set; }
        [XmlElement]
        public int DAY { get; set; }
        [XmlElement]
        public int CODE_MO { get; set; }
        [XmlElement]
        public string CODE_LPU { get; set; }
    }
    [Serializable]
    [XmlRoot]
    public class ZAP
    {
        [XmlElement]
        public int N_ZAP { get; set; }
        [XmlElement(nameof(PACIENT))]
        public PACIENT PACIENT { get; set; }
        [XmlElement(nameof(NPR))]
        public List<NPR> NPR { get; set; }
    }
    [Serializable]
    [XmlRoot]
    public class PACIENT
    {
        [XmlElement]
        public string ID_PAC { get; set; }
        [XmlElement]
        public int? VPOLIS { get; set; }
        [XmlElement]
        public string SPOLIS { get; set; }
        [XmlElement]
        public string NPOLIS { get; set; }
        [XmlElement]
        public string SMO { get; set; }
        [XmlElement]
        public string ST_OKATO { get; set; }
        [XmlElement]
        public string FAM { get; set; }
        [XmlElement]
        public string IM { get; set; }
        [XmlElement]
        public string OT { get; set; }
        [XmlElement]
        public int W { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime DR { get; set; }
        [XmlElement]
        public string PHONE { get; set; }
        [XmlElement]
        public string COMENTP { get; set; }
    }
    [Serializable]
    [XmlRoot]
    public class NPR
    {
        [XmlElement]
        public int IDNPR { get; set; }
        [XmlElement]
        public string NPR_NUM { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime DATE { get; set; }
        [XmlElement]
        public int FOR_POM { get; set; }
        [XmlElement]
        public string NPR_MO { get; set; }
        [XmlElement]
        public string NPR_LPU { get; set; }
        [XmlElement]
        public string DEST_MO { get; set; }
        [XmlElement]
        public string DEST_LPU { get; set; }
        [XmlElement]
        public string DS { get; set; }
        [XmlElement]
        public int? PODR { get; set; }
        [XmlElement]
        public int PROFIL { get; set; }
        [XmlElement]
        public string PROFK { get; set; }
        [XmlElement]
        public string CODE_MD { get; set; }
        [XmlElement(DataType = "date")]
        public DateTime PLAN_DATE { get; set; }
        [XmlElement]
        public string COMENTN { get; set; }
    }
}
