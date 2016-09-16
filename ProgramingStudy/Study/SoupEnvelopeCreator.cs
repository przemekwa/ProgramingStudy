using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProgramingStudy.Study
{
   
    public class CreateInstalmentArgument
    {
        public int AccountId { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanProfileId { get; set; }
        public List<int> InputSchedule { get; set; }
        public string UserName { get; set; }
        public bool RealTimePosting { get; set; }
        public bool IsValidationEnabled { get; set; }
        public string Reason { get; set; }
        public string CorrelationId { get; set; }
        public string UserId { get; set; }

    }

    [XmlType(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SOAPEnvelope
    {
        [XmlAttribute(AttributeName = "soapenv", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public string soapenva { get; set; }

        [XmlAttribute(AttributeName = "xsd", Namespace = "http://www.w3.org/2001/XMLSchema")]
        public string xsd { get; set; }

        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string xsi { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public ResponseBody<CreateInstalmentArgument> body { get; set; }

        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
        public SOAPEnvelope()
        {
            xmlns.Add("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            xmlns.Add("prim", "http://bzwbk.com/services/prime/");
        }
    }

    [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class ResponseBody<T>
    {
        [XmlElement(Namespace = "http://bzwbk.com/services/prime/")]
        public T CreateInstalment { get; set; }
    }

    //
    // URL: http://pragmaticparag.blogspot.com/2012/07/soap-parser-utility-using-xml.html
    //

    class SoupEnvelopeCreator : IStudyTest
    {
        public void Study()
        {
            var se = new SOAPEnvelope
            {
                body = new ResponseBody<CreateInstalmentArgument>
                {
                    CreateInstalment = new CreateInstalmentArgument { UserName = "Przemek"}
                }
            };

            var soapserializer = new XmlSerializer(typeof(SOAPEnvelope));

            string result;

            using (var ms = new MemoryStream())
            {
                soapserializer.Serialize(ms, se);

                result = Encoding.UTF8.GetString(ms.ToArray());

                Console.WriteLine(result);
            }


            HttpWebRequest request = CreateWebRequest();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"");

            var t = soapEnvelopeXml.InnerText;

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();
                    Console.WriteLine(soapResult);
                }
            }

        }

        public HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"http://wro1706v.centrala.bzwbk/wbk2/PrimeApi2/ApiInstalmentServices.svc");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}
