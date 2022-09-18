using System;
namespace Business.Abstract
{
	public interface ISmsSenderService
	{
		string SmsGonder(string Telefon, string Mesaj, Models.Enums.SmsServisSaglayici smsServisSaglayici);
	}
}

