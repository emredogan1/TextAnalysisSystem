using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisSystem
{
    internal class Program
    {
        /// <summary>
        /// Metinin karakter sayisini hesaplar.
        /// </summary>
        /// <param name="metin">kulllanicidan alinan metin</param>
        /// <returns>Metnin Karakter Sayisi</returns>
        static int KarakterSayisi(string metin)
        {
            int karakterSayisi = metin.Replace(" ","").Length;//replace ile boşlukları kaldırıyoruz.
            return karakterSayisi;
        }
        /// <summary>
        /// Metinin Kelime Sayisini Hesaplar.
        /// </summary>
        /// <param name="metin">kulllanicidan alinan metin</param>
        /// <returns>Metnin Kelime Sayisi</returns>
        static int KelimeSayisi(string metin)
        {
            if (string.IsNullOrWhiteSpace(metin))
                return 0;
            char[] ayraclar = { ' ', ',', '.', '!', '?', ';', ':' };
            string[] kelimeler = metin.Split(ayraclar,StringSplitOptions.RemoveEmptyEntries);
            return kelimeler.Length;
        }
        /// <summary>
        /// Metindeki Sesli Harf Sayisini Hesaplar
        /// </summary>
        /// <param name="metin">kulllanicidan alinan metin</param>
        /// <returns>Metindeki Sesli Harf Sayisi</returns>
        static int SesliHarfSayisi(string metin)
        {
            string sesliHarfler = "aeıioöuü";
            int sayac = 0;
            foreach(char harf in metin.ToLower())
            {
                if((char.IsLetter(harf)) && (sesliHarfler.Contains(harf)))
                    sayac++;
            }
            return sayac;            
        }
        /// <summary>
        /// Metindeki Sessiz Harf Sayisini Hesaplar
        /// </summary>
        /// <param name="metin">kulllanicidan alinan metin</param>
        /// <returns>Metindeki Sessiz Harf Sayisi</returns>
        static int SessizHarfSayisi(string metin)
        {
            string sessizharfler = "bcçdfgğhjklmnprsştuvyz";
            int sayac = 0;
            foreach (char harf in metin.ToLower())
            {
                if ((char.IsLetter(harf)) && (sessizharfler.Contains(harf)))
                    sayac++;
            }
            return sayac;
        }
        /// <summary>
        /// Metni Tersine Cevirir
        /// </summary>
        /// <param name="metin">kulllanicidan alinan metin</param>
        /// <returns>Metnin Ters Cevrilmis Hali</returns>
        static string TersCevir(string metin)
        {
            char[] karakterler = metin.ToCharArray();
            Array.Reverse(karakterler);
            return new string(karakterler);
        }
        /// <summary>
        /// Metnin Polindrom mu Olduğunu Kontrol Eder
        /// </summary>
        /// <param name="metin">kulllanicidan alinan metin</param>
        /// <returns>Metin Polindrom mu</returns>
        static bool PolindromMu(string metin)
        {
            string temizMetin = metin.Replace(" ","").ToLower();
            string tersi = TersCevir(temizMetin);
            return temizMetin == tersi;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---METİN ANALİZ SİSTEMİ---");
            Console.Write("Lütfen analiz etmek istediğiniz metini giriniz:");
            string metin = Console.ReadLine();
            Console.WriteLine($"\nMetin: \"{metin}\"");
            Console.WriteLine($"Karakter Sayısı(Boşluklar dahil değil): {KarakterSayisi(metin)}");
            Console.WriteLine($"Kelime Sayısı: {KelimeSayisi(metin)}");
            Console.WriteLine($"Sesli Harf Sayısı: {SesliHarfSayisi(metin)}");
            Console.WriteLine($"Sessiz Harf Sayısı: {SessizHarfSayisi(metin)}");
            Console.WriteLine($"Büyük Harf: {metin.ToUpper()}");
            Console.WriteLine($"Küçük Harf: {metin.ToLower()}");
            Console.WriteLine($"Tersi: {TersCevir(metin)}");
            Console.WriteLine($"Polindrom mu: {(PolindromMu(metin) ? "Evet!":"Hayır!")}");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Bu program Emre Doğan tarafından yazılmıştır.");
            Console.WriteLine("Tarih: 17.08.2025");
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}
