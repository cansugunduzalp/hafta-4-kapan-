using System;

abstract class BaseMakine
{
    // Ortak özellikler
    public DateTime UretimTarihi { get; set; }
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }

    // Constructor: Üretim tarihi otomatik olarak atanır
    public BaseMakine()
    {
        UretimTarihi = DateTime.Now; // Üretim tarihi otomatik olarak şu anki tarih olarak atanır
    }

    // Ortak bilgileri yazdıran metod
    public virtual void BilgileriYazdir()
    {
        Console.WriteLine("Üretim Tarihi: " + UretimTarihi.ToString("dd/MM/yyyy"));
        Console.WriteLine("Seri Numarası: " + SeriNumarasi);
        Console.WriteLine("Ad: " + Ad);
        Console.WriteLine("Açıklama: " + Aciklama);
        Console.WriteLine("İşletim Sistemi: " + IsletimSistemi);
    }

    // Abstract metod: Ürün adı bilgilerini yazdırır, her sınıf bunu kendine göre ezmelidir
    public abstract void UrunAdiGetir();
}

class Telefon : BaseMakine
{
    public bool TrLisansli { get; set; }

    // Telefon sınıfı için özellikleri almak ve yazdırmak
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir(); // Base sınıfındaki bilgileri yazdır
        Console.WriteLine("Türkiye Lisanslı mı: " + (TrLisansli ? "Evet" : "Hayır"));
    }

    // Telefon adı bilgisini yazdıran metod
    public override void UrunAdiGetir()
    {
        Console.WriteLine("Telefonunuzun adı ---> " + Ad);
    }
}

class Bilgisayar : BaseMakine
{
    public int UsbGirisSayisi { get; set; }
    public bool Bluetooth { get; set; }

    // Bilgisayar sınıfı için Usb giriş sayısını kontrol etme (Encapsulation)
    public void SetUsbGirisSayisi(int sayi)
    {
        if (sayi == 2 || sayi == 4)
        {
            UsbGirisSayisi = sayi;
        }
        else
        {
            Console.WriteLine("Geçersiz USB Giriş Sayısı! -1 atanıyor.");
            UsbGirisSayisi = -1;
        }
    }

    // Bilgisayar sınıfı için özellikleri almak ve yazdırmak
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir(); // Base sınıfındaki bilgileri yazdır
        Console.WriteLine("USB Giriş Sayısı: " + UsbGirisSayisi);
        Console.WriteLine("Bluetooth: " + (Bluetooth ? "Evet" : "Hayır"));
    }

    // Bilgisayar adı bilgisini yazdıran metod
    public override void UrunAdiGetir()
    {
        Console.WriteLine("Bilgisayarınızın adı ---> " + Ad);
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("Telefon üretmek için 1'e, Bilgisayar üretmek için 2'ye basınız:");
            int secim = int.Parse(Console.ReadLine());

            if (secim == 1)
            {
                // Telefon üretme
                Telefon telefon = new Telefon();
                Console.WriteLine("Telefonun Adını Giriniz:");
                telefon.Ad = Console.ReadLine();
                Console.WriteLine("Telefon Açıklamasını Giriniz:");
                telefon.Aciklama = Console.ReadLine();
                Console.WriteLine("Telefonun İşletim Sistemi:");
                telefon.IsletimSistemi = Console.ReadLine();
                Console.WriteLine("Türkiye Lisanslı mı? (Evet/Hayır):");
                telefon.TrLisansli = Console.ReadLine().ToLower() == "evet";

                telefon.UrunAdiGetir(); // Telefon adı bilgisi
                telefon.BilgileriYazdir(); // Diğer bilgileri yazdır

                Console.WriteLine("Telefon başarıyla üretildi!");

            }
            else if (secim == 2)
            {
                // Bilgisayar üretme
                Bilgisayar bilgisayar = new Bilgisayar();
                Console.WriteLine("Bilgisayarın Adını Giriniz:");
                bilgisayar.Ad = Console.ReadLine();
                Console.WriteLine("Bilgisayar Açıklamasını Giriniz:");
                bilgisayar.Aciklama = Console.ReadLine();
                Console.WriteLine("Bilgisayarın İşletim Sistemi:");
                bilgisayar.IsletimSistemi = Console.ReadLine();
                Console.WriteLine("Bluetooth var mı? (Evet/Hayır):");
                bilgisayar.Bluetooth = Console.ReadLine().ToLower() == "evet";
                Console.WriteLine("USB giriş sayısını giriniz (2 veya 4):");
                int usbSayisi = int.Parse(Console.ReadLine());
                bilgisayar.SetUsbGirisSayisi(usbSayisi); // USB giriş sayısını kontrol etme

                bilgisayar.UrunAdiGetir(); // Bilgisayar adı bilgisi
                bilgisayar.BilgileriYazdir(); // Diğer bilgileri yazdır

                Console.WriteLine("Bilgisayar başarıyla üretildi!");
            }
            else
            {
                Console.WriteLine("Geçersiz seçenek, lütfen tekrar deneyiniz.");
                continue;
            }

            // Başka bir ürün üretmek isteyip istemediğini soralım
            Console.WriteLine("Başka bir ürün üretmek ister misiniz? (Evet/Hayır):");
            string cevap = Console.ReadLine().ToLower();
            if (cevap != "evet")
            {
                devamEt = false;
                Console.WriteLine("İyi günler!");
            }
        }
    }
}
