using System;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;
using Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace Core.Helper
{
    public static class SharedTools
    {
        public static string ToJsonSerialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static string clearTurkishChars(string str)
        {
            str = str.Trim().Replace("ü", "u")
            .Replace("ı", "i")
            .Replace("ö", "o")
            .Replace("ü", "u")
            .Replace("ş", "s")
            .Replace("ğ", "g")
            .Replace("ç", "c")
            .Replace("Ü", "U")
            .Replace("İ", "I")
            .Replace("Ö", "O")
            .Replace("Ü", "U")
            .Replace("Ş", "S")
            .Replace("Ğ", "G")
            .Replace("Ç", "C");

            return str;
        }

        public static string TelsamTelFix(this string telefon)
        {

            if (telefon.Length == 12)
            {
                telefon = telefon.Substring(2, 10);

            }
            else if (telefon.Length == 11)
            {
                telefon = telefon.Substring(1, 10);

            }
            return telefon;

        }
        public static Ayarlar GetAyarlar()
        {
            IConfigurationBuilder conBuild = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "settings.json");
            conBuild.AddJsonFile(path, false);
            var root = conBuild.Build();
            Ayarlar ayarlar = new();
            ayarlar.Kullanici = root.GetSection("Kullanici").Value;
            ayarlar.Sifre = root.GetSection("Sifre").Value;
            return ayarlar;
        }

        public static string CreateWebRequestAsync(string url, string requestdata, string methodT, string contentType, List<KeyValuePair<string, string>> keyValuePairs = null)
        {


            var request = (HttpWebRequest)WebRequest.Create(url);

            var data = Encoding.ASCII.GetBytes(requestdata);

            request.Method = methodT;
            request.ContentType = contentType;
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            return new StreamReader(response.GetResponseStream()).ReadToEnd();

        }
        public static string createXmlGuvenTelekom(string tel, string mesaj,Models.Ayarlar ayarlar)

        {
            StringBuilder sb = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings();

            settings.Encoding = Encoding.Unicode;

            settings.Indent = true;

            settings.IndentChars = ("	");

            using (XmlWriter writer = XmlWriter.Create(sb, settings))

            {

                writer.WriteStartElement("sms");

                writer.WriteElementString("username", ayarlar.Kullanici);

                writer.WriteElementString("password", ayarlar.Sifre);

                writer.WriteElementString("header", ayarlar.ServisSaglayici);

                writer.WriteElementString("validity", "2880");

                writer.WriteStartElement("message");

                writer.WriteStartElement("gsm");

                writer.WriteElementString("no", tel);

                writer.WriteEndElement(); //gsm

                writer.WriteStartElement("msg");

                writer.WriteCData(clearTurkishChars(mesaj));

                writer.WriteEndElement(); //msg 

                writer.WriteEndElement(); //message 

                writer.WriteEndElement(); // sms 

                writer.Flush();

            }

            return sb.ToString();

        }
    }
}
