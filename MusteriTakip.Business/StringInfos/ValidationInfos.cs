using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MusteriTakip.Business.StringInfos
{
    public static class ValidationInfos
    {

        private static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        public static string AlanBosGecilemez(string alanAdi)
        {
            return $"{alanAdi.ToTitleCase()} Alanı Boş Geçilemez.";
        }

        public static string GecerliBirDegerGiriniz(string alanAdi)
        {
            return $"{alanAdi.ToTitleCase()} Alanı İçin Geçerli Bir Değer Giriniz.";
        }

        public static string AlanUzunluguArasiOlmali(int baslangic, int bitis, string alanAdi)
        {
            return $"{alanAdi.ToTitleCase()} Alanı En Az {baslangic} Karakter En Fazla İse {bitis} Karakter Kadar Olmalıdır.";
        }

        public static string DegerlerAyniOlmali(string birinciDegere, string ikinciDeger)
        {
            return $"{birinciDegere.ToTitleCase()} Alanı İle {ikinciDeger.ToTitleCase()} Alanı Birbirine Eşit Olmalıdır.";
        }

        public static string SadeceMetinsel(string alanAdi)
        {
            return $"{alanAdi.ToTitleCase()} Alanı Sadece Metinsel İfadelerden Oluşabilir.";
        }

        public static string SadeceSayisal(string alanAdi)
        {
            return $"{alanAdi.ToTitleCase()} Alanı Sadece Rakamsal İfadelerden Oluşabilir.";
        }

        public static string DegerBulunamadi(string alanAdi)
        {
            return $"{alanAdi.ToTitleCase()} Değeri Bulunamadı.";
        }

        public static string KarakterSayisi(string alanadi , int karakterSayisi)
        {
            return $"{alanadi.ToTitleCase()} Alanı {karakterSayisi} Karakter Uzunluğunda Olmalıdır.";
        }

        public static string GecersizEmail(string alanadi)
        {
            return $"{alanadi.ToTitleCase()} Alanı Geçerli Bir E-Mail Adresi Olmalıdır.";
        }


        public static string DegerlerOlmali(string deger , string alanadi)
        {
            return $"{alanadi} Alanı {deger} Degerlerinden Biri Olmalı";
        }


    }
}
