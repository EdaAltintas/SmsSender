using System;
namespace Business.Abstract
{
	public interface ITelsamService
	{
		string SmsGonderTelsam(string tel, string mesaj,Models.Ayarlar ayarlar);
	}
}

