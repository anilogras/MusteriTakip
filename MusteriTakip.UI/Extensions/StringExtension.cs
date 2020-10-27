using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Extensions
{
    public static class StringExtension
    {
        public static string TelNoDuzenle(this String data)
        {
            string telno;
            if (data == null)
            {
                return data;
            }

            data = data.Trim();

            if (data.Length == 11)
            {
                telno = (data[0] + " (" + data[1] + data[2] + data[3] + ") " + data[4] + data[5] + data[6] + " " + data[7] + data[8] + " " + data[9] + data[10]).ToString();
            }
            else if (data.Length == 10)
            {
                telno = ("0 (" + data[0] + data[1] + data[2] + ") " + data[3] + data[4] + data[5] + " " + data[6] + data[7] + " " + data[8] + data[9]).ToString();

            }
            else
            {
                telno = data;
            }
            return telno;
        }

        public static string WebSiteDuzenle(this String gelenURL)
        {
            gelenURL = gelenURL.Replace("Https://", "Http://").Replace("https://", "Http://");
            int sonuc = gelenURL.IndexOf("Http://");
            if (sonuc == -1)
            {
                gelenURL = "Http://" + gelenURL;
            }

            return gelenURL;
        }
    }
}
