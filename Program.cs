using System;
using System.Xml;

namespace TatilNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string? userInput4 = null;
            do
            {
                Console.WriteLine("Tatil.Net'e hoşgeldiniz!! Size sunabileceğimiz 3 adet lokasyonumuz var: \n1 - Bodrum (Paket başlangıç fiyatı 4000 TL) \n2 - Marmaris (Paket başlangıç fiyatı 3000 TL)\n3 - Çeşme (Paket başlangıç fiyatı 5000 TL)");
                Console.Write("\nLütfen tercihinizi belirtiniz: ");

                int price1 = 0; // Paket fiyatları için değişken

                string? userInput1 = Console.ReadLine();

                userInput1 = userInput1 ?? "";
                string userInputUpper = char.ToUpper(userInput1[0]) + userInput1.Substring(1).ToLower();

                // Listedeki konum seçilene kadar soruyu tekrarlar
                if (!Enum.TryParse(userInput1, true, out TatilYeri tatilYeri))
                {
                    do
                    {
                        Console.WriteLine("\nSeçtiğiniz konum listede yok. Lütfen bir konum seçiniz:\n1 - Bodrum (Paket başlangıç fiyatı 4000 TL) \n2 - Marmaris (Paket başlangıç fiyatı 3000 TL)\n3 - Çeşme (Paket başlangıç fiyatı 5000 TL)");
                        userInput1 = Console.ReadLine();

                    } while (!Enum.TryParse(userInput1, true, out tatilYeri));
                }

                Console.Write("\nTatil için kişi sayısını giriniz: ");

                int userInput2 = Convert.ToInt32(Console.ReadLine()); // kişi sayısı için değişken


                // Seçilen yere göre yapılabicek etkinlikleri gösterir
                if (Enum.TryParse(userInput1, true, out tatilYeri))
                {
                    switch (tatilYeri)
                    {
                        case TatilYeri.Çeşme:
                            Console.WriteLine("\nÇeşme, Alaçatı'nın şirin sokakları ve Ilıca Plajı’yla ünlü. Sörf yapabilir, termal kaynaklarda rahatlayabilirsiniz. Çeşme’nin Kumru’sunu ve Alaçatı tatlılarını denemelisiniz.");
                            price1 = 5000;
                            Console.WriteLine("Enter tuşuna basın ve devam edin...");

                            // Enter tuşuna basılana kadar bekler
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                            {
                                // Boş döngü, sadece Enter tuşu bekleniyor
                            }
                            break;
                        case TatilYeri.Bodrum:
                            Console.WriteLine("\nBodrum, hem tarihi hem de doğal güzellikleriyle öne çıkıyor. Bodrum Kalesi ve Antik Tiyatro'yu gezebilir, Bitez ve Ortakent'te denize girebilirsiniz. Akşamları Barlar Sokağı'nda eğlenebilir, Yalıkavak Marina'da alışveriş yapabilirsiniz.");
                            price1 = 4000;
                            Console.WriteLine("Enter tuşuna basın ve devam edin...");

                            // Ente tuşuna basılana kadar bekler
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                            {
                                // Boş döngü, enter tuşu bekleniyor
                            }
                            break;

                        case TatilYeri.Marmaris:
                            Console.WriteLine("\nMarmaris, doğal güzellikler ve su aktiviteleriyle cazip. Marmaris Kalesi’ni gezebilir, tekne turlarıyla Cennet Adası'nı keşfedebilirsiniz. Ayrıca, jeep safari turlarıyla doğayı keşfetmek de keyifli olacaktır.");
                            price1 = 3000;
                            Console.WriteLine("Enter tuşuna basın ve devam edin...");

                            // Enter tuşuna basılana kadar bekler
                            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                            {
                                // Boş döngü, enter tuşu bekleniyor
                            }
                            break;
                    }
                }

                Console.WriteLine("\nLütfen ulaşım türünü seçiniz: \n1- Kara yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL )\n2- Hava yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL)");
                Console.Write("Lütfen yukarıdaki seçeneklerden bir tanesini seçiniz (1/2): ");

                int price2 = 0; // ulaşım şekli için fiyatı tutan değişken

                int userInput3 = Convert.ToInt32(Console.ReadLine());

                string? ulasimAraci = null;

                bool devamEt = true; // ** döngüden çıkınca if işleminin devam etmesi için kullanılan bool değişkeni 


                while (devamEt)
                {
                    if (userInput3 == 1)
                    {
                        price2 = 1500;
                        ulasimAraci = "Kara";
                        devamEt = false;
                    }
                    else if (userInput3 == 2)
                    {
                        price2 = 4000;
                        ulasimAraci = "Hava";
                        devamEt = false;
                    }
                    else
                    {
                        // Listedeki ulaşım şekillerinden biri seçilene kadar tekrar eder **
                        do
                        {
                            Console.WriteLine("\nGeçersiz işlem. Lütfen tekrar seçiniz:  \n1- Kara yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL )\n2- Hava yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL)");
                            userInput3 = Convert.ToInt32(Console.ReadLine());

                        } while (userInput3 != 1 && userInput3 != 2);
                    }
                }


                int result = price1 + userInput2 * (price2);

                Console.WriteLine($"\nGidilecek lokasyon: {userInputUpper}\nKişi sayısı: {userInput2} \nUlaşım aracı: {ulasimAraci}\nToplam bedel: {result}");


                Console.WriteLine("\nBaşka bir tatil planlamak ister misiniz (E/H): ");
                userInput4 = Console.ReadLine();

                
            } while (userInput4 == "E");
            

        }

        enum TatilYeri
        {
            Bodrum,
            Marmaris,
            Çeşme
        }

    }
}