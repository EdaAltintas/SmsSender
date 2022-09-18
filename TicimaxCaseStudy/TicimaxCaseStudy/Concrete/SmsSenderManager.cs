using System;
using System.Net;
using Models;

namespace Business.Concrete
{
	public class SmsSenderManager
	{
        public string SmsGonder(string Telefon, string Mesaj,Models.Enums.SmsServisSaglayici smsServisSaglayici,Ayarlar ayarlar)

        {
            string returnValue = string.Empty;

            if (!string.IsNullOrEmpty(Telefon))
            {

                Telefon = Telefon.Replace("+", string.Empty).Replace(" ", string.Empty);

                if (Telefon.Length == 10)
                {
                    Telefon = "90" + Telefon;
                }

                else if (Telefon.Length == 11)
                {
                    Telefon = "9" + Telefon;
                }

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                switch (smsServisSaglayici)
                {
                    case Models.Enums.SmsServisSaglayici.GuvenTelekom:
                        GuvenTelekomManager guvenTelekomManager = new();
                        returnValue=guvenTelekomManager.SmsGonderGuvenTelekom(Telefon, Mesaj,ayarlar);
                        break;
                    case Models.Enums.SmsServisSaglayici.TFonTelekom:
                        TFonTelekomManager fonTelekomManager = new();
                        returnValue = fonTelekomManager.SmsGonderTFonTelekom(Telefon, Mesaj,ayarlar);
                        break;
                    case Models.Enums.SmsServisSaglayici.JetMesaj:
                        JetMesajManager jetMesajManager = new();
                        returnValue = jetMesajManager.SmsGonderJetMesaj(Telefon, Mesaj,ayarlar);
                        break;
                    case Models.Enums.SmsServisSaglayici.NetGsm:
                        NetGsmManager netGsmManager = new();
                        returnValue = netGsmManager.SmsGonderNetGsm(Telefon, Mesaj,ayarlar);
                        break;
                    case Models.Enums.SmsServisSaglayici.SmartMessage:
                        SmartMessageManager smartMessageManager = new();
                        returnValue = smartMessageManager.SmsGonderSmartMessage(Telefon, Mesaj,ayarlar);
                        break;
                    case Models.Enums.SmsServisSaglayici.Telsam:
                        TelsamManager telsamManager = new();
                        returnValue = telsamManager.SmsGonderTelsam(Telefon, Mesaj,ayarlar);
                        break;
                    case Models.Enums.SmsServisSaglayici.Verimor:
                        VerimorManager verimorManager = new();
                        returnValue = verimorManager.SmsGonderVerimor(Telefon, Mesaj,ayarlar);
                        break;
                    default:
                        break;
                }
            }

            return returnValue;

        }
    }
}

