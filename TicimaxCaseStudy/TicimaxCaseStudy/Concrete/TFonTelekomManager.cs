using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Helper;
namespace Business.Concrete
{
    public class TFonTelekomManager:ITFonTelekomService
    {
        public string SmsGonderTFonTelekom(string tel, string mesaj,Models.Ayarlar ayarlar)
        {
            //var ayarlar = SharedTools.GetAyarlar();
            string istekAdresi = "http://api2.ekomesaj.com/json/syncreply/SendInstantSms";

            var Credential = new
            {
                Username = ayarlar.Kullanici,
                Password = ayarlar.Sifre,
                ResellerID = 1111
            };

            var Sms = new
            {

                SmsCoding = "String",
                SenderName = ayarlar.ServisSaglayici,
                Route = 0,
                ValidityPeriod = 0,
                DataCoding = "Default",
                ToMsisdns = new
                {
                    Msisdn = tel,
                    Name = "",
                    Surname = "",
                    CustomField1 = "",

                },

                ToGroups = new List<int>(),
                IsCreateFromTeplate = false,
                SmsTitle = ayarlar.ServisSaglayici,
                SmsContent = mesaj,
                RequestGuid = "",
                CanSendSmsToDuplicateMsisdn = false,
                SmsSendingType = "ByNumber"

            };

            return SharedTools.CreateWebRequestAsync(istekAdresi, new { Credential, Sms }.ToJsonSerialize(), "POST", "application/json");

        }
    }
}
