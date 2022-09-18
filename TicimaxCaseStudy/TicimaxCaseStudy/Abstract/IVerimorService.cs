using System;
namespace Business.Abstract
{
	public interface IVerimorService
	{
		string SmsGonderVerimor(string tel, string mesaj, Models.Ayarlar ayarlar);
	}
}

