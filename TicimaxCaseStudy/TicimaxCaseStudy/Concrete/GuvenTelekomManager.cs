using System;
using System.IO;
using System.Net;
using System.Text;
using Business.Abstract;
using Core.Helper;

namespace Business.Concrete
{
    public class GuvenTelekomManager:IGuvenTelekomService
    {
        public string SmsGonderGuvenTelekom(string tel, string mesaj,Models.Ayarlar ayarlar)
        {

            string returnValue = string.Empty;

            string IstekAdresi = "http://api.guventelekom.net:8080/api/smspost/v1";

            HttpWebRequest request = WebRequest.Create(new Uri(IstekAdresi)) as HttpWebRequest;

            request.Method = "POST";

            request.ContentType = "application/x-www-form-urlencoded";

            request.Timeout = 5000;

            byte[] data = UTF8Encoding.UTF8.GetBytes(SharedTools.createXmlGuvenTelekom(tel, mesaj,ayarlar)); request.ContentLength = data.Length;

            using (Stream postStream = request.GetRequestStream())
            {

                postStream.Write(data, 0, data.Length);

            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)

            {

                StreamReader reader = new StreamReader(response.GetResponseStream());

                returnValue = reader.ReadToEnd();

            }

            return returnValue;
        }
    }
}
