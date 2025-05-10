using ProductManagement.Data;
using ProductManagement.Models.Entities;

Console.WriteLine("Hangi veri türüyle çalışmak istersiniz?");
Console.WriteLine("1 - Roman");
Console.WriteLine("2 - Şiir");
Console.Write("Seçiminiz: ");
string secim = Console.ReadLine();

if (secim == "1")
{
    RomanIslemleri();
}
else if (secim == "2")
{
    SiirIslemleri();
}
else
{
    Console.WriteLine("Geçersiz seçim.");
}

static void RomanIslemleri()
{
    var romanRepo = new GenericRepository<Roman>("romanlar.json");

    bool devam = true;
    while (devam)
    {
        Console.WriteLine("\n--- Roman İşlemleri ---");
        Console.WriteLine("1 - Roman Ekle");
        Console.WriteLine("2 - Roman Listele");
        Console.WriteLine("3 - Roman Güncelle");
        Console.WriteLine("4 - Roman Sil");
        Console.WriteLine("5 - Çıkış");
        Console.Write("Seçim: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                var yeniRoman = new Roman();
                Console.Write("Yazar: ");
                yeniRoman.Yazar = Console.ReadLine();
                Console.Write("Başlık: ");
                yeniRoman.Baslik = Console.ReadLine();
                Console.Write("Sayfa Sayısı: ");
                yeniRoman.SayfaSayisi = int.Parse(Console.ReadLine());
                Console.Write("Özeti: ");
                yeniRoman.Ozeti = Console.ReadLine();
                romanRepo.Create(yeniRoman);
                break;

            case "2":
                foreach (var r in romanRepo.GetAll())
                {
                    Console.WriteLine($"{r.Id} - {r.Baslik} ({r.Yazar}) [{r.SayfaSayisi} syf]");
                    Console.WriteLine($"Özet: {r.Ozeti}");
                    Console.WriteLine("------------------------");
                }
                break;

            case "3":
                Console.Write("Güncellenecek ID: ");
                int gId = int.Parse(Console.ReadLine());
                var gRoman = romanRepo.GetById(gId);
                if (gRoman != null)
                {
                    Console.Write("Yeni Başlık: ");
                    gRoman.Baslik = Console.ReadLine();
                    romanRepo.Update(gRoman);
                }
                else Console.WriteLine("Roman bulunamadı.");
                break;

            case "4":
                Console.Write("Silinecek ID: ");
                int sId = int.Parse(Console.ReadLine());
                romanRepo.Delete(sId);
                break;

            case "5":
                devam = false;
                break;
        }
    }
}

void SiirIslemleri()
{
    var siirRepo = new GenericRepository<Siir>("siirler.json");

    bool devam = true;
    while (devam)
    {
        Console.WriteLine("\n--- Şiir İşlemleri ---");
        Console.WriteLine("1 - Şiir Ekle");
        Console.WriteLine("2 - Şiir Listele");
        Console.WriteLine("3 - Şiir Güncelle");
        Console.WriteLine("4 - Şiir Sil");
        Console.WriteLine("5 - Çıkış");
        Console.Write("Seçim: ");
        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                var yeniSiir = new Siir();
                Console.Write("Yazar: ");
                yeniSiir.Yazar = Console.ReadLine();
                Console.Write("Başlık: ");
                yeniSiir.Baslik = Console.ReadLine();
                Console.Write("Sayfa Sayısı: ");
                yeniSiir.SayfaSayisi = int.Parse(Console.ReadLine());
                Console.Write("Türü: ");
                yeniSiir.Tur = Console.ReadLine();
                siirRepo.Create(yeniSiir);
                break;

            case "2":
                foreach (var s in siirRepo.GetAll())
                {
                    Console.WriteLine($"{s.Id} - {s.Baslik} ({s.Yazar}) [{s.SayfaSayisi} syf]");
                    Console.WriteLine($"Tür: {s.Tur}");
                    Console.WriteLine("------------------------");
                }
                break;

            case "3":
                Console.Write("Güncellenecek ID: ");
                int gId = int.Parse(Console.ReadLine());
                var gSiir = siirRepo.GetById(gId);
                if (gSiir != null)
                {
                    Console.Write("Yeni Başlık: ");
                    gSiir.Baslik = Console.ReadLine();
                    siirRepo.Update(gSiir);
                }
                else Console.WriteLine("Şiir bulunamadı.");
                break;

            case "4":
                Console.Write("Silinecek ID: ");
                int sId = int.Parse(Console.ReadLine());
                siirRepo.Delete(sId);
                break;

            case "5":
                devam = false;
                break;
        }
    }
}
