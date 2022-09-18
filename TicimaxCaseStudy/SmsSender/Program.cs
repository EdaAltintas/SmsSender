using System;
using Business.Concrete;
using Core.Helper;
namespace SmsSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var ayarlar=SharedTools.GetAyarlar();
            ayarlar.ServisSaglayici = "JetMesaj";

            SmsSenderManager sender = new();
            var res=sender.SmsGonder("+905348999999", "deneme", Models.Enums.SmsServisSaglayici.JetMesaj,ayarlar);
            Console.WriteLine(res);
        }

    }
}

