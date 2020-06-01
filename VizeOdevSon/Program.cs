using System;
using System.Linq;

//Zafer Güler

namespace VizeOdev
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kartlar = { "k1", "k2", "k3", "k4", "k5", "m1", "m2", "m3", "m4", "m5", "s1", "s2", "s3", "s4", "s5", "rd", "rd", "rd" };
            string[] kKartlar = { "k1", "k2", "k3", "k4", "k5" };
            string[] mKartlar = { "m1", "m2", "m3", "m4", "m5" };
            string[] sKartlar = { "s1", "s2", "s3", "s4", "s5" };
            string[] renkSecme = { "k", "m", "s" };
            string[] enSonAtilanKart = { "" };
            string[] oyuncu1Kartlari = new string[6];
            string[] oyuncu2Kartlari = new string[6];
            string[] oyuncu3Kartlari = new string[6];
            string atilanKart = "";
            string enSonKartinIlkIndexi = "";
            string enSonKartinSonIndexi = "";

            int[] oyunSirasiDizisi = new int[3];
            int paskntrl = 0;
            int elSayisi = 0;

            bool pcOyunaIlkBaslarsa = true;
            bool kartKontrol = true;
            bool kartKontrol2 = true;
            bool oyunDevemEtmeDurumu = true;
            bool kartAtildiKontrol = true;
            bool rdKartiKullanmaDurumu = true;
            bool renkDegistirmeKartiKullansin = true;

            Console.WriteLine("Kart Oyununa Hoşgeldiniz");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---Kurallar---\n-Yerdeki kartın rengiyle aynı bir renge sahip kart atılması durumunda");
            Console.WriteLine("-Yerdeki kartın rakamıyla aynı bir rakama sahip kart atılması durumunda");
            Console.WriteLine("-Özel kart kullanılması durumunda");
            Console.WriteLine("-Attıgınız kart gecerlidir");
            Console.WriteLine();
            Console.WriteLine("-Elinizde uygun bir kart yok ise 'pas' yazınız!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;


            //Kartların oyunculara dağıtılmasını sağlıyorum.

            Console.WriteLine("-----------------------------------");
            Console.Write("Sizin Kartlarınız => ");
            Random dagit = new Random();
            for (int i = 0; i < 6; i++)
            {
                int no = dagit.Next(0, kartlar.Length);

                if (kartlar[no] != "")
                {
                    oyuncu1Kartlari[i] = kartlar[no];
                    kartlar[no] = "";
                    Console.Write(oyuncu1Kartlari[i]);
                    Console.Write(" ");
                }
                else
                {
                    i--;
                }

            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.Write("Oyuncu 2 Kartları => ");
            for (int i = 0; i < 6; i++)
            {
                int no = dagit.Next(0, kartlar.Length);

                if (kartlar[no] != "")
                {
                    oyuncu2Kartlari[i] = kartlar[no];
                    kartlar[no] = "";
                    Console.Write(oyuncu2Kartlari[i]);
                    Console.Write(" ");
                }
                else
                {
                    i--;
                }

            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.Write("Oyuncu 3 Kartları => ");
            for (int i = 0; i < 6; i++)
            {
                int no = dagit.Next(0, kartlar.Length);

                if (kartlar[no] != "")
                {
                    oyuncu3Kartlari[i] = kartlar[no];
                    kartlar[no] = "";
                    Console.Write(oyuncu3Kartlari[i]);
                    Console.Write(" ");
                }
                else
                {
                    i--;
                }

            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------");



            //Oyun sırasının belirlenmesi.

            Console.WriteLine("---Oyun Sirasi---");
            Random oyunaBaslayacakKisi = new Random();
            for (int i = 0; i < 3; i++)
            {
                int nos = oyunaBaslayacakKisi.Next(1, 4);
                if (oyunSirasiDizisi.Contains(nos) == false)
                {
                    oyunSirasiDizisi[i] = nos;
                    Console.Write(i + 1);
                    Console.Write("- Oyuncu ");
                    Console.WriteLine(oyunSirasiDizisi[i]);
                }
                else
                {
                    i--;
                }

            }


            Console.WriteLine("-------------------------------");
            while (oyunDevemEtmeDurumu == true)
            {
                for (int m = 0; m < 3; m++)
                {
                    //Oyuncu 1
                    if (oyunSirasiDizisi[m] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        //Oyuncu 1'in attıgı kartların gecerliligini kontrol ediyorum.

                        while (kartKontrol == true && kartKontrol2 == true)
                        {
                            Console.Write("Kartlariniz => ");
                            for (int i = 0; i < oyuncu1Kartlari.Length; i++)
                            {
                                Console.Write(oyuncu1Kartlari[i]);
                                Console.Write(" ");
                            }


                            Console.WriteLine();
                            Console.Write("Atmak Istediginiz Karti Seciniz => ");
                            atilanKart = Console.ReadLine();

                            //Oyuncu 1 oyuna ilk baslarsa ve rd kartını kullanırsa buraya giriyor.
                            while (elSayisi == 0 && atilanKart == "rd" && oyuncu1Kartlari.Contains("rd") && kartKontrol == true)
                            {
                                if (oyuncu1Kartlari.Contains("rd"))
                                {
                                    Console.WriteLine("Ozel Kart Ile Oyun Baslamaz. Lutfen Yeni Kart Seciniz => ");
                                    atilanKart = Console.ReadLine();
                                }
                                else
                                {
                                    int no = Array.IndexOf(oyuncu1Kartlari, atilanKart);
                                    oyuncu1Kartlari[no] = "";
                                    kartKontrol = false;
                                }
                            }
                            //Oyuncu 1 elinde olmayan bir kart girerse burada kontrol ettiriyorum.
                            while (kartKontrol2 == true)
                            {
                                if (oyuncu1Kartlari.Contains(atilanKart) == false && atilanKart != "pas")
                                {
                                    Console.Write("Gecerli Bir Kart Atınız Lutfen => ");
                                    atilanKart = Console.ReadLine();
                                }
                                else if (elSayisi == 0 && atilanKart == "rd")
                                {
                                    Console.Write("Ozel Kart Ile Oyun Baslamaz. Lutfen Yeni Kart Seciniz => ");
                                    atilanKart = Console.ReadLine();
                                }
                                else if (elSayisi == 0 && atilanKart == "pas" )
                                {
                                    Console.Write("Ilk el pas denmez. Yeni Kart Seciniz => ");
                                    atilanKart = Console.ReadLine();
                                }
                                else if ((atilanKart.Contains(enSonKartinIlkIndexi) == false && atilanKart.Contains(enSonKartinSonIndexi) == false) && atilanKart != "rd" && elSayisi != 0 && atilanKart != "pas")
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write("Lutfen En Son Atılan Karta Uygun Bir Kart Atınız => ");
                                    atilanKart = Console.ReadLine();
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                //Oyuncu 1 el sayısı sıfır değilken rd kartını kullanırsa buraya girmesini istedim.
                                else if (elSayisi != 0 && atilanKart == "rd")
                                {
                                    while (rdKartiKullanmaDurumu == true)
                                    {
                                        Console.Write("Yeni Rengi Seciniz Lutfen => 'k' 'm' 's' =>  ");
                                        string ucRenktenBiriniSecme = Console.ReadLine();
                                        int rdIndexNosu = Array.IndexOf(oyuncu1Kartlari, "rd"); //Oyuncu 1'in rd kartın olduğu yere "" atıyorum.
                                        oyuncu1Kartlari[rdIndexNosu] = "";
                                        if (renkSecme.Contains(ucRenktenBiriniSecme) == true)
                                        {

                                            //Yerdeki son kartın rengiyle aynı bir renk atarsa buraya giriyor.
                                            bool asd = true; 
                                            while (asd == true)
                                            {
                                                if (ucRenktenBiriniSecme == Convert.ToString(enSonAtilanKart[0][0]))
                                                {
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                    Console.Write("En Son Atılan Kart Ile Aynı Renge Sahip Bir Kart Atmayiniz. Yeniden Bir Renk Seciniz => ");
                                                    ucRenktenBiriniSecme = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    asd = false;
                                                }
                                            }
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            for (int i = 1; i < 7; i++)
                                            {
                                                if (oyuncu1Kartlari.Contains("k" + i) == true && ucRenktenBiriniSecme == "k")
                                                {
                                                    atilanKart = "k" + enSonAtilanKart[0][1];
                                                    Console.WriteLine("Yerdeki Yeni Kart => " + atilanKart);
                                                    break;
                                                }
                                                else if (oyuncu1Kartlari.Contains("m" + i) == true && ucRenktenBiriniSecme == "m")
                                                {
                                                    atilanKart = "m" + enSonAtilanKart[0][1];
                                                    Console.WriteLine("Yerdeki Yeni Kart => " + atilanKart);
                                                    break;
                                                }
                                                else if (oyuncu1Kartlari.Contains("s" + i) == true && ucRenktenBiriniSecme == "s")
                                                {
                                                    atilanKart = "s" + enSonAtilanKart[0][1];
                                                    Console.WriteLine("Yerdeki Yeni Kart => " + atilanKart);
                                                    break;
                                                }
                                                else if (renkSecme.Contains(ucRenktenBiriniSecme) == false)
                                                {
                                                    Console.WriteLine("Lutfen Elinizde Olan Renklerden Birini seciniz");
                                                }
                                            }
                                            Console.ForegroundColor = ConsoleColor.White;
                                            rdKartiKullanmaDurumu = false;
                                            kartKontrol2 = false;
                                        }
                                        //Seçmesi gereken renkler dışında bir renk seçerse eğer buraya giriyor.
                                        else if (renkSecme.Contains(ucRenktenBiriniSecme) == false)
                                        {
                                            Console.WriteLine("Lutfen 'k' 'm' 's' Haricinde Bir Renk Atmayiniz");
                                        }
                                    }
                                }
                                //Eğer oyuncu1 pas yazarsa sıra diğer oyuncuya geçiyor.
                                else if (atilanKart == "pas")
                                {
                                    atilanKart = enSonAtilanKart[0]; //Oyuncu 1 pas attıktan sonra oyuncu 1 den önceki oyuncunun attığı kartı atilan karta eşitliyorum.
                                    Console.WriteLine("Pas Hakkınızı Kullandınız");
                                    kartKontrol2 = false;
                                }
                                //Oyuncu 1'in attığı kart yerine "" atıyorum.
                                else
                                {
                                    int no = Array.IndexOf(oyuncu1Kartlari, atilanKart);
                                    oyuncu1Kartlari[no] = "";
                                    kartKontrol2 = false;
                                }
                            }
                            kartKontrol = false;
                        }
                        elSayisi++;
                        rdKartiKullanmaDurumu = true;
                        kartKontrol = true;
                        kartKontrol2 = true;
                        pcOyunaIlkBaslarsa = false;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("-------------------------------");
                    }


                    //Oyuncu 2
                    if (oyunSirasiDizisi[m] == 2)
                    {
                        if (kKartlar.Contains(atilanKart) == true) //Atılan kartın rengi kırmızı ise buraya giriyor.
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                if (oyuncu2Kartlari.Contains("k" + (i))) //Oyuncu 2'nin elinde kırmızı renkte bir kart olup olmadıgını kontrol ettiriyorum.
                                {
                                    atilanKart = "k" + i;
                                    int indexNo = Array.IndexOf(oyuncu2Kartlari, atilanKart); //Atılan kartın kaçıncı indexde olduğunu buluyoruz.
                                    oyuncu2Kartlari[indexNo] = ""; // oyuncu2Kartları dizisinde atilan kartın yerine "" ifadesi kullandım.
                                    Console.WriteLine("Oyuncu 2 nin Attıgı Kart => " + atilanKart);
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    break;
                                }
                            }

                        }
                        else if (mKartlar.Contains(atilanKart) == true)
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                if (oyuncu2Kartlari.Contains("m" + (i)))
                                {
                                    atilanKart = "m" + i;
                                    int indexNo = Array.IndexOf(oyuncu2Kartlari, atilanKart);
                                    oyuncu2Kartlari[indexNo] = "";
                                    Console.WriteLine("Oyuncu 2 nin Attıgı Kart => " + atilanKart);
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    break;
                                }
                            }
                        }
                        else if (sKartlar.Contains(atilanKart) == true)
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                if (oyuncu2Kartlari.Contains("s" + (i)))
                                {
                                    atilanKart = "s" + i;
                                    int indexNo = Array.IndexOf(oyuncu2Kartlari, atilanKart);
                                    oyuncu2Kartlari[indexNo] = "";
                                    Console.WriteLine("Oyuncu 2 nin Attıgı Kart => " + atilanKart);
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    break;
                                }
                            }
                        }

                        //Oyuna ilk oyuncu 2 baslarsa eger direk buraya giriyor.
                        else if (pcOyunaIlkBaslarsa == true)
                        {
                            bool secilenKartrdmı = true;
                            while (secilenKartrdmı == true) //Oyuncu 2 random bir kart seciyor eger rd secerse tekrar secsin diye while kullandım.
                            {
                                Random bilgisayarinKartSecmeDurumu = new Random();
                                int secim = bilgisayarinKartSecmeDurumu.Next(0, oyuncu2Kartlari.Length);
                                if (oyuncu2Kartlari[secim] != "rd")
                                {
                                    atilanKart = oyuncu2Kartlari[secim];
                                    Console.WriteLine("Oyuncu 2 nin Attıgı Kart => " + atilanKart);
                                    oyuncu2Kartlari[secim] = "";
                                    pcOyunaIlkBaslarsa = false;
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    secilenKartrdmı = false;
                                }
                            }
                        }
                        if (kartAtildiKontrol == true) //Oyuncu 2 yerde olan kart ile aynı renge sahip bir kartı yok ise aynı rakamda var mı diye kontrol etmesi için buraya giriyor.
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                string aranan = Convert.ToString(i);
                                if (atilanKart.LastIndexOf(aranan) == 1)
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        if (oyuncu2Kartlari[j].LastIndexOf(aranan) == 1)
                                        {
                                            atilanKart = oyuncu2Kartlari[j];
                                            oyuncu2Kartlari[j] = "";
                                            Console.WriteLine("Oyuncu 2 nin Attıgı Kart => " + atilanKart);
                                            renkDegistirmeKartiKullansin = false;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }

                        //Oyuncu 2 uygun bir kart atamaz ise rd kartı var ise kullanmak icin buraya giriyor.
                        if (renkDegistirmeKartiKullansin == true)
                        {
                            if (oyuncu2Kartlari.Contains("rd") == true)
                            {
                                int rdIndexNosu = Array.IndexOf(oyuncu2Kartlari, "rd");
                                oyuncu2Kartlari[rdIndexNosu] = "";
                                bool asdd = true; //Hocam boola ne isim vereceğimi bulamadım :)
                                for (int i = 1; i < 7; i++)
                                {
                                    //Oyuncu 2 nın elinde hangi renkte bir kart var ise onu atması icin for icinde dönüyor.
                                    if (oyuncu2Kartlari.Contains("k" + i) == true)
                                    {

                                        atilanKart = "k" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 2 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                        break;
                                    }
                                    else if (oyuncu2Kartlari.Contains("m" + i) == true)
                                    {
                                        atilanKart = "m" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 2 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                        break;
                                    }
                                    else if (oyuncu2Kartlari.Contains("s" + i) == true)
                                    {
                                        atilanKart = "s" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 2 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                        break;
                                    }
                                }
                                //Oyuncu 2 'nin elinde seçeceği bir renk yok ise random bir renk seçiyor.
                                while (asdd == true)
                                {
                                    Random asd = new Random();
                                    int rndm = asd.Next(0, 3);

                                    if (rndm == 0)
                                    {
                                        atilanKart = "k" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 2 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                    }
                                    else if (rndm == 1)
                                    {
                                        atilanKart = "m" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 2 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                    }
                                    else if (rndm == 2)
                                    {
                                        atilanKart = "s" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 2 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                    }
                                }
                            }
                            //Hiçbir uygun kart yok ise pas atıp geçiyor.
                            else
                            {
                                Console.WriteLine("Oyuncu 2 Pas Hakkını Kullandı");
                            }

                        }
                        Console.WriteLine();
                        Console.Write("Oyuncu 2 nın Kartları => ");
                        for (int i = 0; i < oyuncu2Kartlari.Length; i++)
                        {
                            Console.Write(oyuncu2Kartlari[i]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------");
                    }
                    elSayisi++;
                    kartAtildiKontrol = true;
                    renkDegistirmeKartiKullansin = true;

                    //Oyuncu 3
                    //Oyuncu 2 için geçerli olan her şey oyuncu 3 için de geçerli.
                    if (oyunSirasiDizisi[m] == 3)
                    {
                        if (kKartlar.Contains(atilanKart) == true)
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                if (oyuncu3Kartlari.Contains("k" + (i)))
                                {
                                    atilanKart = "k" + i;
                                    int indexNo = Array.IndexOf(oyuncu3Kartlari, atilanKart); //Atılan kartın kaçıncı indexde olduğunu buluyoruz.
                                    oyuncu3Kartlari[indexNo] = ""; // oyuncu2Kartları dizisinde atilan kartın yerine "" ifadesi kullandım.
                                    Console.WriteLine("Oyuncu 3 un Attıgı Kart => " + atilanKart);
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    break;
                                }
                            }


                        }
                        else if (mKartlar.Contains(atilanKart) == true)
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                if (oyuncu3Kartlari.Contains("m" + (i)))
                                {
                                    atilanKart = "m" + i;
                                    int indexNo = Array.IndexOf(oyuncu3Kartlari, atilanKart);
                                    oyuncu3Kartlari[indexNo] = "";
                                    Console.WriteLine("Oyuncu 3 un Attıgı Kart => " + atilanKart);
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    break;
                                }
                            }

                        }
                        else if (sKartlar.Contains(atilanKart) == true)
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                if (oyuncu3Kartlari.Contains("s" + (i)))
                                {
                                    atilanKart = "s" + i;
                                    int indexNo = Array.IndexOf(oyuncu3Kartlari, atilanKart);
                                    oyuncu3Kartlari[indexNo] = "";
                                    Console.WriteLine("Oyuncu 3 un Attıgı Kart => " + atilanKart);
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    break;
                                }
                            }

                        }
                        else if (pcOyunaIlkBaslarsa == true)
                        {
                            bool secilenKartrdmı = true;
                            while (secilenKartrdmı == true)
                            {
                                Random bilgisayarinKartSecmeDurumu = new Random();
                                int secim = bilgisayarinKartSecmeDurumu.Next(0, oyuncu3Kartlari.Length);
                                if (oyuncu3Kartlari[secim] != "rd")
                                {
                                    atilanKart = oyuncu3Kartlari[secim];
                                    Console.WriteLine("Oyuncu 3 un Attıgı Kart => " + atilanKart);
                                    elSayisi = 1;
                                    oyuncu3Kartlari[secim] = "";
                                    pcOyunaIlkBaslarsa = false;
                                    kartAtildiKontrol = false;
                                    renkDegistirmeKartiKullansin = false;
                                    secilenKartrdmı = false;
                                }
                            }


                        }
                        if (kartAtildiKontrol == true)
                        {
                            for (int i = 1; i < 7; i++)
                            {
                                string aranan = Convert.ToString(i);
                                if (atilanKart.LastIndexOf(aranan) == 1)
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        if (oyuncu3Kartlari[j].LastIndexOf(aranan) == 1)
                                        {
                                            atilanKart = oyuncu3Kartlari[j];
                                            oyuncu3Kartlari[j] = "";
                                            Console.WriteLine("Oyuncu 3 un Attıgı Kart => " + atilanKart);
                                            renkDegistirmeKartiKullansin = false;
                                            break;
                                        }
                                    }
                                    break;
                                }

                            }
                        }

                        if (renkDegistirmeKartiKullansin == true)
                        {
                            if (oyuncu3Kartlari.Contains("rd") == true)
                            {
                                int rdIndexNosu = Array.IndexOf(oyuncu3Kartlari, "rd");
                                oyuncu3Kartlari[rdIndexNosu] = "";
                                bool asdd = true; //Hocam boola ne isim vereceğimi bulamadım :)
                                for (int i = 1; i < 7; i++)
                                {
                                    if (oyuncu3Kartlari.Contains("k" + i) == true)
                                    {
                                        atilanKart = "k" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 3 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                        break;
                                    }
                                    else if (oyuncu3Kartlari.Contains("m" + i) == true)
                                    {
                                        atilanKart = "m" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 3 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                        break;
                                    }
                                    else if (oyuncu3Kartlari.Contains("s" + i) == true)
                                    {
                                        atilanKart = "s" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 3 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                        break;
                                    }
                                }
                                while (asdd == true)
                                {
                                    Random asd = new Random();
                                    int rndm = asd.Next(0, 3);

                                    if (rndm == 0)
                                    {
                                        atilanKart = "k" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 3 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                    }
                                    else if (rndm == 1)
                                    {
                                        atilanKart = "m" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 3 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                    }
                                    else if (rndm == 2)
                                    {
                                        atilanKart = "s" + enSonAtilanKart[0][1];
                                        Console.WriteLine("Oyuncu 3 rd Kartını Kullandı Yeni Kart => " + atilanKart);
                                        asdd = false;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Oyuncu 3 Pas Hakkını Kullandı");
                            }

                        }
                        Console.WriteLine();
                        Console.Write("Oyuncu 3 Un Kartları => ");
                        for (int i = 0; i < oyuncu3Kartlari.Length; i++)
                        {
                            Console.Write(oyuncu3Kartlari[i]);
                            Console.Write(" ");
                        }
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------");
                    }

                    if (atilanKart != "rd" && atilanKart != "pas")
                    {
                        enSonAtilanKart[0] = atilanKart;
                        enSonKartinIlkIndexi = Convert.ToString(enSonAtilanKart[0][0]);
                        enSonKartinSonIndexi = Convert.ToString(enSonAtilanKart[0][1]);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    kartAtildiKontrol = true;
                    renkDegistirmeKartiKullansin = true;
                    elSayisi++;

                    Console.ForegroundColor = ConsoleColor.Yellow;

                    //Eğer oyunculardan birinin hiçbir kartı kalmaz ise oyunu o kazanıyor.
                    if (oyuncu1Kartlari[0] == "" && oyuncu1Kartlari[1] == "" && oyuncu1Kartlari[2] == "" && oyuncu1Kartlari[3] == "" && oyuncu1Kartlari[4] == "" && oyuncu1Kartlari[5] == "")
                    {
                        Console.WriteLine("----Oyunu Siz Kazandınız----");
                        oyunDevemEtmeDurumu = false;
                        break;
                    }
                    else if (oyuncu2Kartlari[0] == "" && oyuncu2Kartlari[1] == "" && oyuncu2Kartlari[2] == "" && oyuncu2Kartlari[3] == "" && oyuncu2Kartlari[4] == "" && oyuncu2Kartlari[5] == "")
                    {
                        Console.WriteLine("-----Oyunu Oyuncu 2 Kazandi-----");
                        oyunDevemEtmeDurumu = false;
                        break;
                    }
                    else if (oyuncu3Kartlari[0] == "" && oyuncu3Kartlari[1] == "" && oyuncu3Kartlari[2] == "" && oyuncu3Kartlari[3] == "" && oyuncu3Kartlari[4] == "" && oyuncu3Kartlari[5] == "")
                    {
                        Console.WriteLine("-----Oyunu Oyuncu 3 Kazandi-----");
                        oyunDevemEtmeDurumu = false;
                        break;
                    }

                    //Atılan kart pas ise buraya giriyor paskntrl arttırıyor eğer 3 tane pas atılmışsa yerdeki kart 3 el değişmemiş
                    //demektir bu yüzden oyun berabere bitiyor.
                    if (atilanKart == "pas")
                    {
                        paskntrl++;
                        if (paskntrl == 3)
                        {
                            Console.WriteLine("---Oyun Beraberlikle Sonuclandı---");
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Oyun Sonlandı");
            Console.ReadKey();
        }

    }
}
