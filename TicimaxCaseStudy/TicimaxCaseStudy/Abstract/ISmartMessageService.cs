using System;
namespace Business.Abstract
{
	public interface ISmartMessageService
	{
		string SmsGonderSmartMessage(string tel, string mesaj, Models.Ayarlar ayarlar);
	}
}

