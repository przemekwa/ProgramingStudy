using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ProgramingStudy.Job
{
    [XmlRoot(ElementName ="productsSelgros")]
    public class ProductsSelgros
    {
        [XmlElement(ElementName ="product")]
        public List<Product> Products { get; set; }
    }

    [Serializable]
    public struct Product
    {
        [XmlElement(ElementName = "id", Order = 8)]
        public int Id { get; set; }

        [XmlArray(ElementName = "product_numbers", Order = 32)]
        [XmlArrayItem(ElementName = "product_number")]
        public List<int> ProductNumbers { get; set; }

        [XmlElement(ElementName = "unit", Order = 43)]
        public string Unit { get; set; }

        [XmlElement(ElementName = "prev_file", Order = 29)]
        public string PrevFile { get; set; }

        [XmlElement(ElementName = "price_netto", Order = 31)]
        public string PriceNetto { get; set; }

        [XmlElement(ElementName = "price_brutto", Order = 30)]
        public string PriceBrutto { get; set; }

        [XmlElement(ElementName = "category", Order = 2)]
        public string Category { get; set; }

        [XmlElement(ElementName = "logs", Order = 17)]
        public string Logs { get; set; }

        [XmlElement(ElementName = "name", Order = 19)]
        public string Name { get; set; }

        [XmlElement(ElementName = "description", Order = 4)]
        public string Description { get; set; }

        [XmlElement(ElementName = "pack", Order = 27)]
        public string Pack { get; set; }

        [XmlElement(ElementName = "alcohol", Order = 1)]
        public string Alcohol { get; set; }

        [XmlElement(ElementName = "only_gastro", Order = 26)]
        public string IsGastro { get; set; }

        [XmlElement(ElementName = "start_date", Order = 40)]
        public string StartDate { get; set; }

        [XmlElement(ElementName = "end_date", Order = 5)]
        public string EndDate { get; set; }

        [XmlArray(ElementName = "halls", Order = 6)]
        [XmlArrayItem(ElementName = "hall")]
        public List<int> Halls { get; set; }

        [XmlElement(ElementName = "logo_premia_10_1", Order = 12)]
        public string LogoPremia_10_1 { get; set; }

        [XmlElement(ElementName = "logo_premia_10_2", Order = 13)]
        public string LogoPremia_10_2 { get; set; }

        [XmlElement(ElementName = "logo_premia_10_4", Order = 14)]
        public string LogoPremia_10_4 { get; set; }

        [XmlElement(ElementName = "logo_super_cena", Order = 15)]
        public string LogoSuperPrice { get; set; }

        [XmlElement(ElementName = "logo_hit", Order = 11)]
        public string LogoHit { get; set; }

        [XmlElement(ElementName = "stop", Order = 41)]
        public string Stop { get; set; }

        [XmlElement(ElementName = "premia_opis", Order = 28)]
        public string PremiaDescription { get; set; }

        [XmlElement(ElementName = "logo_weekend", Order = 16)]
        public string LogoWeekend { get; set; }

        [XmlElement(ElementName = "cena_dnia", Order = 3)]
        public string PriceOfTheDay { get; set; }

        [XmlElement(ElementName = "threshold", Order = 44)]
        public string Threshold { get; set; }

        [XmlElement(ElementName = "group_wawi", Order = 45)]
        public string GroupWawi { get; set; }

        [XmlElement(ElementName = "group_unit", Order = 46)]
        public string GroupUnit { get; set; }

        [XmlElement(ElementName = "group_master", Order = 47)]
        public string GroupMaster { get; set; }


    };

    public class SqlToXML : IStudyTest
    {
        //const string pathToFile_in = "d:/Pobrane/selgros_prod_23_2018_top_2000.txt";
        const string pathToFile_in = "d:/Pobrane/selgros_tab_xml_file.txt";
        const string pathToFile_out = "d:/xml_selgros.xml";

        public void Study()
        {
            var ps = new ProductsSelgros
            {
                Products = new List<Product>()
            };

            foreach (var line in File.ReadAllLines(pathToFile_in))
            {
                var array = line.Split(new char[] { '\t' }, StringSplitOptions.None);

                ps.Products.Add(new Product
                {
                    Id = int.Parse(array[4]),
                    Name = array[5],
                    Description = array[6].Replace('\u0002', ' '),
                    ProductNumbers = new List<int>(), //array[7],
                    //producktSelgros array[8],
                    Pack = array[9],
                    Unit = array[10],
                    PrevFile = array[11],
                    PriceNetto = array[12],
                    PriceBrutto = array[13],
                    Logs = array[14],
                    Category = array[15],
                    Alcohol = array[16],
                    IsGastro = array[17],
                    StartDate = array[18],
                    EndDate = array[19],
                    Halls = array[20] == null ? (List<int>)null : new List<int>(array[20].Split(new[] { ", " }, StringSplitOptions.None).Select(s => int.Parse(s))),
                    LogoPremia_10_1 = array[21],
                    LogoPremia_10_2 = array[22],
                    LogoPremia_10_4 = array[23],
                    LogoSuperPrice = array[24],
                    LogoHit = array[25],
                    Stop = array[26],
                    PremiaDescription = array[27],
                    LogoWeekend = array[28],
                    PriceOfTheDay = array[29],
                    Threshold = array[30],
                    GroupWawi = array[31],
                    GroupUnit = array[32],
                    GroupMaster = array[33],
                });
            }

            this.BuildXml(ps);
        }

        public void BuildXml(ProductsSelgros list)
        {
            var ns = new XmlSerializerNamespaces();

            ns.Add("","");

            var xmls = new XmlSerializer(typeof(ProductsSelgros));
            
            using (var sw = new StreamWriter(pathToFile_out))
            {
                using (var writer = XmlWriter.Create(sw))
                {
                    xmls.Serialize(writer, list, ns);
                    sw.Flush();
                }
            }
        }
    }
}
