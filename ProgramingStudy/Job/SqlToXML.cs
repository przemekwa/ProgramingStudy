using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace ProgramingStudy.Job
{
    public class Header
    {

         [XmlElement(ElementName = "promo_period")]
        public int PromoPeriod { get; set; }

        [XmlElement(ElementName = "promo_start")]
        public string PromoStartXml
        {
            get
            {
                return GetDate(PromoStart);

            }
            set
            {
                PromoStartXml = value;
            }
        }

        [XmlElement(ElementName = "promo_end")]
        public string PromoEndXml
        {
            get
            {
                return GetDate(PromoEnd);

            }
            set
            {
                PromoEndXml = value;
            }
        }

        [XmlElement(ElementName = "xml_date")]
        public string XmlDateXml
        {
            get
            {
                return GetDate(XmlDate);

            }
            set
            {
                XmlDateXml = value;
            }
        }


        [XmlIgnore]
        public DateTime PromoStart { get; set; }

        [XmlIgnore]
        public DateTime PromoEnd { get; set; }

        [XmlIgnore]
        public DateTime XmlDate { get; set; }

         private string GetDate(DateTime date) => date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }

    [XmlRoot(ElementName = "productsSelgros")]
    public class ProductsSelgros
    {
        [XmlElement(ElementName = "header")]
        public Header Header {get;set;}

        [XmlElement(ElementName = "product")]
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

    public class SqlToXML : StudyBase, IStudyTest
    {
        const string pathToFile_in = "d:/Pobrane/current.txt";
        //const string pathToFile_in = "d:/Pobrane/selgros_tab_xml_file.txt";
        const string pathToFile_out = "d:/current.xml";

        public void Study()
        {
            var ps = new ProductsSelgros
            {
                Products = new List<Product>(),
                Header= new Header { XmlDate =  DateTime.Now }
            };


            foreach (var line in File.ReadAllLines(pathToFile_in).Select((l, i) => new { Text = l, Number = i }))
            {
                var array = line.Text.Split(new char[] { '\t' }, StringSplitOptions.None);

                try
                {
                    ps.Header.PromoPeriod = int.Parse(array[0]);
                    ps.Header.PromoStart = DateTime.ParseExact(array[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    ps.Header.PromoEnd = DateTime.ParseExact(array[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    var p = new Product();

                    p.Id = int.Parse(array[4]);
                    p.Name = array[5];
                    p.Description = array[6].Replace('\u0002', ' ').Replace("@@@@", Environment.NewLine).Replace("@@", Environment.NewLine).Trim();
                    p.ProductNumbers = new List<int>(); //array[7];
                    //producktSelgros array[8];
                    p.Pack = array[9];
                    p.Unit = array[10];
                    p.PrevFile = GetHash(array[11]);
                    p.PriceNetto = array[12];
                    p.PriceBrutto = array[13];
                    p.Logs = array[14];
                    p.Category = array[15];
                    p.Alcohol = array[16];
                    p.IsGastro = array[17];
                    p.StartDate = array[18];
                    p.EndDate = array[19];
                    p.Halls = array[20] == null ? (List<int>)null : new List<int>(array[20].Split(new[] { ", " }, StringSplitOptions.None).Select(s => int.Parse(s)));
                    p.LogoPremia_10_1 = array[21];
                    p.LogoPremia_10_2 = array[22];
                    p.LogoPremia_10_4 = array[23];
                    p.LogoSuperPrice = array[24];
                    p.LogoHit = array[25];
                    p.Stop = array[26];
                    p.PremiaDescription = array[27];
                    p.LogoWeekend = array[28];
                    p.PriceOfTheDay = array[29];
                    p.Threshold = array[30];
                    p.GroupWawi = array[31];
                    p.GroupUnit = array[32];
                    p.GroupMaster = array[33];


                    ps.Products.Add(p);

                    break;
                }
                catch (Exception e)
                {
                    _log.Error(e, $"Line number {line.Number}");

                    continue;
                }


            }


            ps.Header.XmlDate = DateTime.Now;

            this.BuildXml(ps);
        }

        private string GetHash(string v)
        {
            if (string.IsNullOrEmpty(v) || v == "NULL")
            {
                return string.Empty;
            }

            var uri = new Uri(v);
            var apiKey = "023b0890f2284913b6a7bf64b45723a7beaa95c03f014ffe80fb9d17e497ee58";

            var match = Regex.Match(uri.PathAndQuery, "([0-9A-Fa-f]{8}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{4}[-][0-9A-Fa-f]{12})$");

            if (match.Success)
            {
                var id = Guid.Parse(match.Value);
                var hash = ProgramingStudy.Study.Helper.GetSha256($"{id}{apiKey}");
                var newUri = $"{uri.Scheme}://{uri.Host}:{uri.Port}/Image/{hash}/{id}";

                return newUri;
            }
            return v;
        }

        public void BuildXml(ProductsSelgros list)
        {
            var ns = new XmlSerializerNamespaces();

            ns.Add("", "");

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
