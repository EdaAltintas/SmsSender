using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Helper;
namespace Business.Concrete
{
	public class TelsamManager: ITelsamService
	{
        public string SmsGonderTelsam(string tel, string mesaj, Models.Ayarlar ayarlar)
        {
            string returnValue = string.Empty;

            string IstekAdresi = "http://websms.telsam.com.tr/xmlapi/sendsms";

            tel =SharedTools.TelsamTelFix(tel);

            string requestXml = @"<?xml version=""1.0""?>

                                <SMS>

                                  <authentication>

                                    <username>" + ayarlar.Kullanici + @"</username>

                                    <password>" + ayarlar.Sifre + @"</password>

                                  </authentication>

                                  <message>

                                    <originator>" + ayarlar.ServisSaglayici + @"</originator>

                                    <text>" + mesaj + @"</text>

                                    <unicode></unicode>

                                    <international></international>

                                    <canceltext></canceltext>

                                  </message>

                                  <receivers>

                                    <receiver>" + tel + @"</receiver>

                                  </receivers>

                                </SMS>";

            returnValue = SharedTools.CreateWebRequestAsync(IstekAdresi, requestXml, "POST", "application/x-www-form-urlencoded", new List<KeyValuePair<string, string>>());

            return returnValue;

        }
    }
}

