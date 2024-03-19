using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Kullanıcı adınızı giriniz.");
            string user = Console.ReadLine();
            if (user == "rlanta")
            {
                Console.WriteLine("Şifrenizi giriniz.");
                string password = Console.ReadLine();
                if (password == "12345")
                {
                    Console.WriteLine("Şifre Doğru");
                    int bakiye = 0;
                    int nakit = 1000;
                    string lastlog = "Henüz işlem yapılmamış.";

                starting:
                    starting();

                    string girdi = Console.ReadLine();
                    if (girdi == "1")
                    {
                        Console.WriteLine("Para yatırma bölümünü seçtiniz");
                        Console.WriteLine("Yatırılabilir miktar: " + nakit + "TL");
                        Console.WriteLine("Lütfen yatırmak istediğiniz miktarı giriniz...");
                        int depositAmount = Convert.ToInt32(Console.ReadLine());
                        if (depositAmount <= nakit)
                        {
                            Console.WriteLine("Hesabınıza başarıyla " + depositAmount + "TL" + " yatırıldı.");
                            lastlog = depositAmount + " Tutarlı para yatırma işlemi yapıldı.";
                            nakit = nakit - depositAmount;
                            bakiye = bakiye + depositAmount;
                            Console.WriteLine("Cüzdanınızda " + nakit + "TL" + " kaldı.");
                            Console.WriteLine("Hesabınızda toplam " + bakiye + "TL" + " oldu.");
                        }
                        else if (depositAmount > nakit)
                        {
                            Console.WriteLine("Yeterli nakitiniz bulunmuyor. Lütfen tekrar deneyiniz.");
                            lastlog = depositAmount + " Tutarlı para yatırma işlemi denendi fakat başarılı olunamadı.";
                            goto starting;
                        }
                        Console.ReadLine();
                        goto starting;
                    }

                    if (girdi == "2")
                    {
                        Console.WriteLine("Para çekme bölümünü seçtiniz.");
                        Console.WriteLine("Çekilebilir miktar: " + bakiye + "TL");
                        Console.WriteLine("Lütfen çekmek istediğiniz miktarı giriniz.");
                        int withdrawAmount = Convert.ToInt32(Console.ReadLine());
                        if (withdrawAmount <= bakiye)
                        {
                            Console.WriteLine("Hesabınızdan başarıyla " + withdrawAmount + "TL" + " çekildi.");
                            lastlog = withdrawAmount + " Tutarlı para çekme işlemi.";
                            nakit = nakit + withdrawAmount;
                            bakiye = bakiye - withdrawAmount;
                            Console.WriteLine("Cüzdanınızda toplam " + nakit + "TL" + " oldu.");
                            Console.WriteLine("Hesabınınızda " + bakiye + "TL" + "kaldı.");
                        }
                        else if (withdrawAmount > bakiye)
                        {
                            Console.WriteLine("Yeterli bakiyeniz bulunmuyor. Lütfen tekrar deneyiniz.");
                            lastlog = withdrawAmount + " Tutarlı para çekme işlemi denendi ama başarılı olunamadı.";
                            goto starting;
                        }
                        Console.ReadLine();
                        goto starting;
                    }

                    if (girdi == "3")
                    {
                        Console.WriteLine("Hesap detaylarınıza hoş geldiniz.");
                        Console.WriteLine("Hesap bakiyeniz: " + bakiye + "TL");
                        Console.WriteLine("Cüzdan bakiyeniz: " + nakit + "TL");
                        Console.WriteLine("Son işlem: " + lastlog);
                        Console.WriteLine("Tarih:" + DateTime.Now);
                        Console.ReadLine();
                        goto starting;
                    }
                }
                else
                {
                    Console.WriteLine("Kullanıcı adı veya şifre hatalı, sistem kapatılıyor...");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Kullanıcı adı veya şifre hatalı, sistem kapatılıyor...");
                Console.ReadLine();
            }
        }
        static void starting()
        {
            Console.WriteLine("Merhaba rlanta, hesabınıza hoşgeldiniz. Lütfen yapmak istediğiniz işlemi seçin.");
            Console.WriteLine("- Para yatırma işlemleri için [1]");
            Console.WriteLine("- Para çekme işlemleri için [2]");
            Console.WriteLine("- Bakiye sorgulama için [3]");
        }
    }
}
