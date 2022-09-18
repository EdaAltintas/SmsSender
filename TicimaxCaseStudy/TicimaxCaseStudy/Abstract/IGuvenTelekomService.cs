using System;
namespace Business.Abstract
{
    public interface IGuvenTelekomService
    {
        string SmsGonderGuvenTelekom(string tel, string mesaj,Models.Ayarlar ayarlar);
    }
}
