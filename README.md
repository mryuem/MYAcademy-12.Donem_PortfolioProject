# Dinamik Kişisel Portfolyo ve Yönetim Paneli

ASP.NET Core MVC ile geliştirilmiş, içerikleri SQL Server veritabanından yönetilen kişisel portfolyo uygulaması. Ziyaretçiler portfolyo içeriklerini görüntüleyebilir ve iletişim formunu kullanabilir; içerikler ve mesajlar yönetim alanından takip edilir.

## Özellikler

- Veritabanından yönetilen karşılama alanı ve aktif unvanlar
- Kategori ve teknoloji ilişkileriyle listelenen projeler
- Hakkımda, eğitim, deneyim, yetenek, sosyal medya ve iletişim içerikleri için yönetim ekranları
- Hakkımda alanı için görsel ve CV PDF yükleme desteği
- İletişim formundan gelen mesajların veritabanında saklanması, okunma durumunun ve mesaj ayrıntılarının yönetimi
- Yönetim alanında toplam/okunmamış mesajlar, okuma oranı, son mesajlar ve son yedi güne ait mesaj istatistikleri
- ASP.NET Core MVC Areas ile ayrılmış Admin alanı
- ViewComponent tabanlı, tekrar kullanılabilir arayüz bileşenleri
- Entity Framework Core Code First migration'ları

## Teknolojiler

- .NET 9 ve ASP.NET Core MVC
- Entity Framework Core 9, SQL Server ve LINQ
- Razor, ViewComponent ve Areas
- Bootstrap 5 ve JavaScript

## Gereksinimler

- .NET 9 SDK
- SQL Server (LocalDB, SQL Server Express veya tam SQL Server kurulumu)
- Veritabanı migration'larını çalıştırmak için `dotnet-ef` aracı

## Kurulum ve çalıştırma

1. Depoyu klonlayın:

   ```bash
   git clone https://github.com/mryuem/MYAcademy-12.Donem_PortfolioProject.git
   cd MYAcademy-12.Donem_PortfolioProject
   ```

2. Proje için veritabanı bağlantısını User Secrets içinde tanımlayın. Aşağıdaki örnekte sunucu adını kendi SQL Server kurulumunuza göre değiştirin:

   ```bash
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=(localdb)\MSSQLLocalDB;Database=PortfolioDayDb;Trusted_Connection=True;TrustServerCertificate=True" --project MYAcademy_PortfolioProject/MYAcademy_PortfolioProject.csproj
   ```

   SQL Server kullanıcı adı/parolası gerekiyorsa bağlantı bilgisini kaynak dosyalara yazmak yerine User Secrets veya ortam değişkeni kullanın. Ortam değişkeni adı `ConnectionStrings__DefaultConnection` şeklindedir.

3. Migration'ları uygulayın ve uygulamayı başlatın:

   ```bash
   dotnet tool install --global dotnet-ef --version 9.0.20
   dotnet ef database update --project MYAcademy_PortfolioProject/MYAcademy_PortfolioProject.csproj --startup-project MYAcademy_PortfolioProject/MYAcademy_PortfolioProject.csproj
   dotnet run --project MYAcademy_PortfolioProject/MYAcademy_PortfolioProject.csproj
   ```

   `dotnet-ef` zaten kuruluysa yeniden yüklemek yerine `dotnet tool update --global dotnet-ef --version 9.0.20` komutunu kullanabilirsiniz. Uygulama başladıktan sonra terminalde gösterilen yerel adresi açın. Yönetim alanının başlangıç adresi `/Admin/Dashboard/Index` şeklindedir.

> Bağlantı dizesi projeye dahil edilmez. `ConnectionStrings:DefaultConnection` ayarı tanımlı değilse uygulama eksik ayarı belirten açık bir hata verir.
>
> CV PDF dosyaları kişisel bilgi içerebileceğinden depoya eklenmez; uygulama çalışırken yönetim panelinden yüklenebilir.
