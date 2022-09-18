using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Helper;
namespace Business.Concrete
{
	public class NetGsmManager: INetGsmService
	{
        public  string SmsGonderNetGsm(string tel, string mesaj, Models.Ayarlar ayarlar)
        {
            string returnValue = string.Empty;

            string IstekAdresi = "https://api.netgsm.com.tr/xmlbulkhttppost.asp";

            string requestXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>

                            <mainbody>

                                <header>

                                    <company dil=""TR"" bayikodu=""11111"">Ticimax</company>

                                    <usercode>" + ayarlar.Kullanici + @"</usercode>

                                    <password>" + ayarlar.Sifre + @"</password>

                                    <startdate></startdate>

                                    <stopdate></stopdate>

                                    <type>1:n</type>

                                    <msgheader>" + ayarlar.ServisSaglayici + @"</msgheader>

                                </header>

                                <body>

                                    <msg><![CDATA[" + mesaj + @"]]></msg>

                                    <no>" + tel + @"</no>

                                </body>

                            </mainbody>";

            returnValue =SharedTools.CreateWebRequestAsync(IstekAdresi, requestXml, "POST", "application/x-www-form-urlencoded", new List<KeyValuePair<string, string>>());

            return returnValue;

        }
    }
}

