using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Business.Abstract;
using Core.Helper;
namespace Business.Concrete
{
	public class JetMesajManager: IJetMesajService
	{
        public  string SmsGonderJetMesaj(string tel, string mesaj, Models.Ayarlar ayarlar)
        {
            string returnValue = "";

            string soapStr = @"<?xml version=""1.0"" encoding=""utf-8""?>

                                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">

                                  <soap:Body>

                                    <SmsGonder xmlns=""http://tempuri.org/"">

                                      <kullaniciAd>" + ayarlar.Kullanici + @"</kullaniciAd>

                                      <parola>" + ayarlar.Sifre + @"</parola>

                                      <gsmNo>

                                        <string>" + tel + @"</string>

                                      </gsmNo>

                                      <smsText>

                                        <string>" + mesaj + @"</string>

                                      </smsText>

                                      <gonderimTarihi>" + DateTime.Now.ToString("ddMMyyyyHHmmss") + @"</gonderimTarihi>

                                      <alfaNumeric>" + ayarlar.ServisSaglayici + @"</alfaNumeric>

                                      <chargedNumber></chargedNumber>

                                      <multiSms>false</multiSms>

                                    </SmsGonder>

                                  </soap:Body>

                                </soap:Envelope>";



            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://92.42.35.50:16899/smswebservice.asmx");

            req.Headers.Add("SOAPAction", "\"http://tempuri.org/SmsGonder\"");

            req.ContentType = "text/xml;charset=\"utf-8\"";

            req.Accept = "text/xml";

            req.Method = "POST";



            using (Stream stm = req.GetRequestStream())

            {
                using (StreamWriter stmw = new StreamWriter(stm))

                {
                    stmw.Write(soapStr);
                }
            }

            using (StreamReader responseReader = new StreamReader(req.GetResponse().GetResponseStream()))

            {

                string result = responseReader.ReadToEnd();

                XDocument ResultXML = XDocument.Parse(result);

                returnValue = ResultXML.Descendants(XName.Get("SmsGonderResponse", "http://tempuri.org/")).FirstOrDefault().Element(XName.Get("SmsGonderResult", "http://tempuri.org/")).Value.Split(':')[0];

            }

            return returnValue;

        }
    }
}

