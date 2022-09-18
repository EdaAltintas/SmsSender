using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Helper;
namespace Business.Concrete
{
	public class VerimorManager:IVerimorService
	{
        public  string SmsGonderVerimor(string tel, string mesaj, Models.Ayarlar ayarlar)
        {
            string istekAdresi = "http://sms.verimor.com.tr/v2/send.json";
            var Sms = new
            {

                username = ayarlar.Kullanici,

                password = ayarlar.Sifre,

                source_addr = ayarlar.ServisSaglayici,

                valid_for = "24:00",

                datacoding = "1",

                messages = new List<object>
                {
                    new
                    {
                       msg = mesaj,
                       dest = tel
                    }
                }

            };

            return SharedTools.CreateWebRequestAsync(istekAdresi, Sms.ToJsonSerialize(), "POST", "application/json");

        }
    }
}

