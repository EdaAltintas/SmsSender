using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Helper;
namespace Business.Concrete
{
	public class SmartMessageManager :ISmartMessageService
	{
        public string SmsGonderSmartMessage(string tel, string mesaj, Models.Ayarlar ayarlar)
        {
            string returnValue = string.Empty;

            string IstekAdresi = "http://api2.smartmessage-engage.com/GET/SMS";

            List<string> Params = new List<string>();

            Params.Add("UserName=" + ayarlar.Kullanici);

            Params.Add("Password=" + ayarlar.Sifre);

            Params.Add("JobId=" + (ayarlar.ServisSaglayici.Contains('|')? ayarlar.ServisSaglayici.Split('|')[1]: ayarlar.ServisSaglayici));

            Params.Add("Message=" + mesaj);

            Params.Add("MobilePhone=" + tel);

            Params.Add("CustomerNo=" + (ayarlar.ServisSaglayici.Contains('|') ? ayarlar.ServisSaglayici.Split('|')[0] : ayarlar.ServisSaglayici));

            Params.Add("PlannedSendingDate=" + DateTime.Now.AddMinutes(1));

            string postData = String.Join("&", Params.ToArray());

            returnValue = SharedTools.CreateWebRequestAsync(IstekAdresi, postData, "GET", "", new List<KeyValuePair<string, string>>());

            return returnValue;

        }
    }
}

