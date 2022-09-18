using System;
namespace Business.Abstract
{
	public interface IJetMesajService
	{
		string SmsGonderJetMesaj(string tel, string mesaj, Models.Ayarlar ayarlar);
	}
}

