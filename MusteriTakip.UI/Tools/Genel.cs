using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusteriTakip.UI.Tools
{
    public class Genel
    {
        /// <summary>
        /// Telefon No Boşluksuz  ve Parantezsiz Hale Getirilir 
        /// </summary>
        /// <param name="tel">Boşlıuklu Olarak Telefon no</param>
        /// <returns></returns>
        public string TelefonNoSifila(string tel)
        {
            string telno = tel.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            return telno;
        }

        /// <summary>
        /// Telefon Numaralarını Boşluklu Yapıda Yazar
        /// (0000) 000 00 00
        /// Eğer Telefon No 11 den Fazla Karakterle Girilmişse Doğrudan geri Döndürülür
        /// </summary>
        /// <param name="tel">Gönderilen Telefon No</param>
        /// <returns></returns>
        public string TelefonNoDuzenle(string tel)
        {
            string telno;
            if (tel == null)
            {
                return tel;
            }

            tel = tel.Trim();

            if (tel.Length == 11)
            {
                telno = (tel[0] + " (" + tel[1] + tel[2] + tel[3] + ") " + tel[4] + tel[5] + tel[6] + " " + tel[7] + tel[8] + " " + tel[9] + tel[10]).ToString();
            }
            else if (tel.Length == 10)
            {
                telno = ("0 (" + tel[0] + tel[1] + tel[2] + ") " + tel[3] + tel[4] + tel[5] + " " + tel[6] + tel[7] + " " + tel[8] + tel[9]).ToString();

            }
            else
            {
                telno = tel;
            }
            return telno;
        }



        /// <summary>
        /// Web Siteleri Başına Http:// Ekler
        /// </summary>
        /// <param name="gelenURL">Url Yolu</param>
        /// <returns>Httpli Url yi Geri Döndürür</returns>
        public string URLDuzenle(string gelenURL)
        {
            gelenURL = gelenURL.Replace("Https://", "Http://").Replace("https://", "Http://");
            int sonuc = gelenURL.IndexOf("Http://");
            if (sonuc == -1)
            {
                gelenURL = "Http://" + gelenURL;
            }

            return gelenURL;
        }

     
        public string SeoUrl(string url)
        {
            if (url != null)
            {
                url = url.Replace("ş", "s");
                url = url.Replace("Ş", "s");
                url = url.Replace("İ", "i");
                url = url.Replace("I", "i");
                url = url.Replace("ı", "i");
                url = url.Replace("ö", "o");
                url = url.Replace("Ö", "o");
                url = url.Replace("ü", "u");
                url = url.Replace("Ü", "u");
                url = url.Replace("Ç", "c");
                url = url.Replace("ç", "c");
                url = url.Replace("ğ", "g");
                url = url.Replace("Ğ", "g");
                url = url.Replace(" ", "-");
                url = url.Replace("---", "-");
                url = url.Replace("?", "");
                url = url.Replace("/", "");
                url = url.Replace(".", "");
                url = url.Replace("'", "");
                url = url.Replace("#", "");
                url = url.Replace("%", "");
                url = url.Replace("&", "");
                url = url.Replace("*", "");
                url = url.Replace("!", "");
                url = url.Replace("@", "");
                url = url.Replace("+", "");
                url = url.ToLower();
                url = url.Trim();
                // tüm harfleri küçült
                string encodedUrl = (url ?? "").ToLower();
                // & ile " " yer değiştirme
                encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");
                // " " karakterlerini silme
                encodedUrl = encodedUrl.Replace("'", "");
                // geçersiz karakterleri sil
                encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");
                // tekrar edenleri sil
                encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");
                // karakterlerin arasına tire koy
                encodedUrl = encodedUrl.Trim('-');
                return encodedUrl;
            }
            else
            {
                return "";
            }
        }

    }
}
