using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriTakip.Business.Services
{
    public interface IAlertifyMessages
    {
        string Success(string mesaj);
        string Error(string mesaj);
        string Warning(string mesaj);
        string CheckResult(bool sonuc, string islemAdi);
    }
}
