using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linked_list_2_ogretmen
{
    class Program
    {
        static void Main(string[] args)
        {
            // boyut, pivot, sayac, j, k, data adlarında 6 tane int değerinde değişken tanımlanıyor
            int boyut, pivot, sayac, j, k, data;

            // iki tane sınırsız dizi oluşturuluyor. Bunların değeri int olum biri asıl dizi verilerini tutacakken diğeri 1. dizinin
            //sıralanmış indeks numaralarını tutmaktadır.
            List<int> la = new List<int>();
            List<int> lb = new List<int>();
            
            //yaratılacak dizinin boyutu seçilir ve boyut değişkenine kayıt edilir.
            Console.Write("Dizi boyutunu belirtin: ");
            boyut = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");

            //for döngüsü ile girilen dizi boyunu kadar dönecek şekilde ayarlanır
            // ve la dizisine girilen veriler kayıt edilir, şimdilik lb dizisinede değişmek sureti ile -1 sayısı kayıt edilir
            for (int i = 0; i < boyut; i++)
            {
                Console.Write((i + 1) + ". Sayınızı giriniz: ");
                data = Convert.ToInt32(Console.ReadLine());
                la.Add(data);
                lb.Add(-1);
                Console.Write("\n");
            }

            // bool değerinde  5 tane değişken tanımlanır
            // devam değişkeni dizide veri arama kısmının sürüp sürmeyeceğini kontrol eder
            // eklesinMi değişkeni aranan diziyi bulamadıktan sonra ekleyip eklemeyeceğini kontrol etmek için
            // varMi değişkeni aranan veri la dizisinde varlığını kontrol etmekte
            // eklediMi değişkeni yeni verinin diziye ekleyip eklemediğini kontrol eder
            //silsinMi değişkeni ise aranan veriyi bulmuş ise silinip silnmeyeceğini kontrol etmektedir.
            bool devam = true, eklesinMi = true, varMi = false, eklediMi = false, silinsinMi = false;

            // ort, ilk, son, aranan, lbAranan değişkenleri tanımlanıyor.
            int ort = 0, ilk, son, aranan = 0, lbAranan = 0;

            //Sayıyı aramak için döngü. Eğer devam true ise while döngüsü terkar edecektir
            while (devam)
            {

                //la dizisinin indeks verilerine göre lb dizisinde küçükten büyüğe sıralanır
                boyut = la.Count;
                lb.Clear();

                
                for (int i = 0; i < la.Count; i++)
                {
                    lb.Add(-1);
                }
                
                //la dizisinin teker teker elemalnarı kotnrol ediliyor. Veriler bir kaç veriden büyükse okadar sayac artılıyor
                //böylece lb dizisinde la dizisinin küçükten büyüğe sıralanışının indeks veri hali şeklinde tutuluyor
                for (j = 0; j < boyut; j++)
                {
                    pivot = la[j];
                    sayac = 0;
                    for (k = 0; k < boyut; k++)
                    {
                        if (la[k] < pivot)
                            sayac++;
                    }
                    while (lb[sayac] > 0)
                        sayac++;
                    lb[sayac] = j;

                }


                //eğer bir sayı eklenmemiş ise bir sayı arratırmak için Kullancıya aratılacak sayı soruluyor.
                if (eklediMi == false)
                {
                    Console.Write("Aranan Sayı: ");
                    aranan = Convert.ToInt32(Console.ReadLine());
                }

                ilk = 0;
                son = boyut - 1;

                //binary search ile istenilen veri aranır.
                //ilk sayısının sondan küçük eşittir mi diye kontrol ettirerek while döngüsü başlatılıyor
                //kısacası burada ilk önce sıralanmış la dizisinin ortadaki sayısı ile aranan sayı karışlatırılır
                //1. if te aranan sayı sıralanmış la dizisindeki ortadaki saıya eşit olup olmadığına bakılır
                //eşit ise aranan sayı ortadaki sayıdır ve döngü break edilir. eğer değilse aranan sayı küçük mü
                // büyük mü diye kontrol dilir eğer büyük ise ortadaki sayıdan büyük sayıların orta verisi ile karışlatırılır
                // ve böyle terkar kontrol ettirilir eşit mi küçük mü büyük mü diye böylece tüm verileri aranan veriye eşit mi diye
                // kontrol ettirmeden Binary Search sayesinde hızlı bir şekilde buluyoruz
                while (ilk <= son)
                {
                    ort = (ilk + son) / 2;
                    if (la[lb[ort]] == aranan)
                    {
                        lbAranan = lb[ort];
                        varMi = true;
                        break;
                    }
                    else if (la[lb[ort]] < aranan)
                    {
                        ilk = ort + 1;
                    }
                    else
                    {
                        son = ort - 1;
                    }
                    varMi = false;
                }

                //istenilen veri var mı yok mu diye kontrol edilir
                if (varMi == true)
                {
                    //önceden bir veri eklenmiş mi diye kontrol edilir
                    if (eklediMi == false)
                    {
                        //la yı yazdırır
                        Console.Write("\n ******************* la dizisi **********************\n\n ");
                        foreach (var a in la)
                        {
                            Console.Write(a + ", ");
                        }

                        //lb yi yazdırır
                        Console.Write("\n ******************** lb dizisi *********************\n\n ");
                        foreach (var a in lb)
                        {
                            Console.Write(a + ", ");
                        }
                        //la  dizisini küçükten büyüğe sıralar
                        Console.Write("\n ******************** küçükten büyüğe ***************\n\n ");
                        foreach (int a in lb)
                            Console.Write(la[a] + ", ");
                        Console.Write("\n ----------------------------------------------------\n\n ");


                        Console.Write(aranan + " Sayısı dizide mevcuttur! \n Dizinin = " + (ort + 1) + ". elemanıdır. \n Silmek ister misiniz?  (true/false) ");
                        silinsinMi = Convert.ToBoolean(Console.ReadLine());

                        //aranan eleman silinsin mi?
                        if (silinsinMi == true)
                        {
                            la.Remove(aranan);
                            lb.Remove(lbAranan);
                            Console.Write("\n\n Silme işlemi tamamlandı! \n");
                          
                            Console.Write("\n ----------------------------------------------------\n\n ");

                            silinsinMi = false;
                        }
                        else
                        {
                            Console.Write("  Devam etmek ister misiniz?  (true/false) ");
                            devam = Convert.ToBoolean(Console.ReadLine());
                        }
                        Console.Write("\n ******************************************\n ");
                    }
                    else
                    {
                        //la yı yazdırır
                        Console.Write("\n ******************* la dizisi ***********************\n ");
                        foreach (var a in la)
                        {
                            Console.Write(a + ", ");
                        }

                        //lb yi yazdırır
                        Console.Write("\n ******************** lb dizisi**********************\n ");
                        foreach (var a in lb)
                        {
                            Console.Write(a + ", ");
                        }
                        //la  dizisini küçükten büyüğe sıralar
                        Console.Write("\n ******************** küçükten büyüğe **********************\n ");
                        foreach (int a in lb)
                            Console.Write(la[a] + ", ");
                        Console.Write("\n ******************** **********************\n ");

                        Console.Write(aranan + " Sayısı diziye eklendi! \n Dizinin = " + (ort + 1) + ". elemanıdır. \n Aramaya devam edelim mi? (true/false)  ");
                        devam = Convert.ToBoolean(Console.ReadLine());
                        eklediMi = false;
                        Console.Write("\n ******************************************\n ");
                    }

                }
                else
                {
                    Console.Write("\n");
                    Console.Write(aranan + " Sayısı dizide mevcut değildir! Veriyi eklemek ister misiniz? (true/false) ");
                    eklesinMi = Convert.ToBoolean(Console.ReadLine());
                    Console.Write("\n /////////////////////////////////////////////   \n ");

                    //Sayının eklenip eklenmeyeceğini kontrol edip sayıyı ekleneceğini belirliyor.
                    if (eklesinMi == true)
                    {

                        la.Add(aranan);
                        eklediMi = true;
                        varMi = true;
                    }
                    else
                    {
                        eklediMi = false;
                        varMi = false;
                    }


                }

            }

            Console.ReadLine();
        }
    }
}
