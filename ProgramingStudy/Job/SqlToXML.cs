using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProgramingStudy.Job
{
    [Serializable]
    public struct Product
    {
       [XmlElement(ElementName ="id", Order = 8)]
        public int Id { get; set; }

        [XmlArray(ElementName ="product_numbers", Order = 32)]
        [XmlArrayItem(ElementName ="product_number")]
        public List<int> ProductNumbers { get; set; }

        [XmlElement(ElementName ="unit", Order = 43)]
        public string Unit { get; set; }

        [XmlElement(ElementName ="prev_file", Order = 29)]
        public string PrevFile { get; set; }

        [XmlElement(ElementName ="price_netto", Order = 31)]
        public string PriceNetto { get; set; }

        [XmlElement(ElementName ="price_brutto", Order = 30)]
        public string PriceBrutto { get; set; }

        [XmlElement(ElementName ="category", Order = 2)]
        public string Category { get; set; }

        [XmlElement(ElementName ="logs", Order = 17)]
        public string Logs { get; set; }

        [XmlElement(ElementName ="name", Order = 19)]
        public string Name { get; set; }

        [XmlElement(ElementName ="description", Order = 4)]
        public string Description { get; set; }

        [XmlElement(ElementName ="pack", Order = 27)]
        public string Pack { get; set; }

        [XmlElement(ElementName ="alcohol", Order = 1)]
        public string Alcohol { get; set; }

        [XmlElement(ElementName ="only_gastro", Order = 26)]
        public string IsGastro { get; set; }

        [XmlElement(ElementName ="start_date", Order = 40)]
        public string StartDate { get; set; }

        [XmlElement(ElementName ="end_date", Order = 5)]
        public string EndDate { get; set; }

         [XmlArray(ElementName ="halls", Order = 6)]
        [XmlArrayItem(ElementName ="hall")]
        public List<int> Halls { get; set; }

        [XmlElement(ElementName ="logo_premia_10_1", Order = 12)]
        public string LogoPremia_10_1 { get; set; }

        [XmlElement(ElementName ="logo_premia_10_2", Order = 13)]
        public string LogoPremia_10_2 { get; set; }

        [XmlElement(ElementName ="logo_premia_10_4", Order = 14)]
        public string LogoPremia_10_4 { get; set; }

        [XmlElement(ElementName ="logo_super_cena", Order = 15)]
        public string LogoSuperPrice { get; set; }

        [XmlElement(ElementName ="logo_hit", Order = 11)]
        public string LogoHit { get; set; }

        [XmlElement(ElementName ="stop", Order = 41)]
        public string Stop { get; set; }

        [XmlElement(ElementName ="premia_opis", Order = 28)]
        public string PremiaDescription { get; set; }

        [XmlElement(ElementName ="logo_weekend", Order = 16)]
        public string LogoWeekend { get; set; }

        [XmlElement(ElementName ="cena_dnia", Order = 3)]
        public string PriceOfTheDay { get; set; }

        [XmlElement(ElementName ="threshold", Order = 44)]
        public string Threshold { get; set; }

        [XmlElement(ElementName ="group_wawi", Order = 45)]
        public string GroupWawi { get; set; }

        [XmlElement(ElementName ="group_unit", Order = 46)]
        public string GroupUnit { get; set; }

        [XmlElement(ElementName ="group_master", Order = 47)]
        public string GroupMaster { get; set; }


    };

    public class SqlToXML : IStudyTest
    {


        public void Study()
        {
            const string pathToFile = "d:/Pobrane/selgros_test.csv";

            var list = new List<Product>();

            list.Add(new Product
            {
                Id = 1234,
                ProductNumbers = new List<int> { 1, 2, 3, 4 }
            });

            //foreach (var line in File.ReadAllLines(pathToFile))
            //{
            //    var array = line.Split(new char[] { ';'},StringSplitOptions.None);




            //}

            this.BuildXml(list);


        }

        public void BuildXml(List<Product> list)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(List<Product>));
            var xml = "";

            using (var sww = new StreamWriter("d:/xml_selgros.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, list);
                    
                    sww.Flush();

                }
            }
        }

    }
}
