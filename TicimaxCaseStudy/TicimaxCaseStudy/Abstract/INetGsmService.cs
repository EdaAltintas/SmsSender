using System;
namespace Business.Abstract
{
	public interface INetGsmService
	{
		string SmsGonderNetGsm(string tel, string mesaj, Models.Ayarlar ayarlar);
	}
}

