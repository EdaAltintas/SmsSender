using System;
namespace Business.Abstract
{
    public interface ITFonTelekomService
    {
       string SmsGonderTFonTelekom(string tel, string mesaj,Models.Ayarlar ayarlar);
    }
}
