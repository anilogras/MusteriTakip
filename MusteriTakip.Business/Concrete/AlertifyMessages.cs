using MusteriTakip.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Concrete
{
    public class AlertifyMessages : IAlertifyMessages 
    {
        public string Success(string mesaj)
        {
            return $"alertify.success('{mesaj}');";
        }

        public string Error(string mesaj)
        {
            return $"alertify.error('{mesaj}');";
        }

        public string Warning(string mesaj)
        {
            return $"alertify.warning('{mesaj}');";
        }

        public string CheckResult (bool sonuc , string islemAdi)
        {
            if (sonuc == true) {
                return $"alertify.success('{islemAdi}başarılı');"; 
            }
            else
            {
                return $"alertify.error('{islemAdi} İşlemi Başarısız');";
            }
                
        }

    }
}
