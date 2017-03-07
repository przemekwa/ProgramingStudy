using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy
{
    public class AppConfigStudy : IStudyTest
    {
        public void Study()
        {
            var d = new ReportsPdfMarginsConfiguration();

            Console.WriteLine(d["BlatCoorDepartment"].Top);
        }
    }


    public  class ReportsPdfMarginsConfiguration
    {
        public  ReportsPdfMarginsDataSection ReportsPdfMarginsDataSection { get; private set; }

         public ReportsPdfMarginsConfiguration()
        {
            ReportsPdfMarginsDataSection = ConfigurationManager.GetSection(ReportsPdfMarginsDataSection.SectionName) as ReportsPdfMarginsDataSection;
        }

        public  ReportPdfMarginElement this[string reportName]
        {
            get
            {
                if (this.ReportsPdfMarginsDataSection == null)
                {
                    return null;
                }

                return this.ReportsPdfMarginsDataSection.ReportPdfMarginCollection.Cast<ReportPdfMarginElement>().SingleOrDefault(s => s.Name == reportName);
            }
        }
    }

    public class ReportsPdfMarginsDataSection : ConfigurationSection
    {
        public const string SectionName = "ReportsPdfMarginsDataSection";

        private const string ReportPdfMarginName = "ReportPdfMarginElement";

        [ConfigurationProperty(ReportPdfMarginName)]
        [ConfigurationCollection(typeof(ReportPdfMarginCollection), AddItemName = "add")]


        public ReportPdfMarginCollection ReportPdfMarginCollection
        {
            get
            {
                return (ReportPdfMarginCollection)base[ReportPdfMarginName];
            }
        }
    }

    public class ReportPdfMarginCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ReportPdfMarginElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ReportPdfMarginElement)element).Name;
        }
    }

    public class ReportPdfMarginElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("top", IsRequired = true)]
        public float Top
        {
            get { return float.Parse(this["top"].ToString()); }
            set { this["top"] = value; }
        }

        [ConfigurationProperty("bottom", IsRequired = true)]
        public float Bottom
        {
            get { return float.Parse(this["bottom"].ToString()); }
            set { this["bottom"] = value; }
        }

        [ConfigurationProperty("left", IsRequired = true)]
        public float Left
        {
            get { return float.Parse(this["left"].ToString()); }
            set { this["left"] = value; }
        }

        [ConfigurationProperty("right", IsRequired = true)]
        public float Right
        {
            get { return float.Parse(this["right"].ToString()); }
            set { this["right"] = value; }
        }
    }
}
