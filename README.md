# Dinamik Kişisel Portfolyo ve Yönetim Paneli

ASP.NET Core MVC ile geliştirilen, içerikleri SQL Server veritabanından yönetilen kişisel portfolyo uygulaması. Ziyaretçiler portfolyo içeriklerini görüntüleyebilir ve iletişim formunu kullanabilir; içerikler ve mesajlar yönetim alanından takip edilir.

## Özellikler

- Veritabanından yönetilen karşılama alanı ve aktif unvanlar
- Kategori ve teknoloji ilişkileriyle listelenen projeler
- Hakkımda, eğitim, deneyim, yetenek, sosyal medya ve iletişim içerikleri için yönetim ekranları
- Hakkımda alanı için görsel ve CV PDF yükleme desteği
- İletişim mesajlarını kaydetme, mesaj ayrıntılarını ve okundu durumunu yönetme
- Toplam/okunmamış mesajlar, okuma oranı, son mesajlar ve son yedi güne ait mesaj istatistikleri
- ASP.NET Core MVC Areas ile ayrılmış Admin alanı
- ViewComponent tabanlı, tekrar kullanılabilir arayüz bileşenleri
- Entity Framework Core Code First migration'ları

## Kullanılan Teknolojiler

- .NET 9 ve ASP.NET Core MVC
- Entity Framework Core 9, SQL Server ve LINQ
- Razor, ViewComponent ve Areas
- Bootstrap 5 ve JavaScript

## Ekran Görüntüleri

<p align="center">
  <img src="docs/screenshots/anasayfa.png" alt="Portfolyo ana sayfası" width="800">
</p>

<p align="center">
  <img src="docs/screenshots/yetenekler.png" alt="Yetenekler ve teknoloji alanları" width="800">
</p>

<p align="center">
  <img src="docs/screenshots/deneyimler.png" alt="Deneyim ve kariyer bölümü" width="800">
</p>

<p align="center">
  <img src="docs/screenshots/projeler.png" alt="Kategori filtreli proje portfolyosu" width="800">
</p>

<p align="center">
  <img src="docs/screenshots/egitim.png" alt="Eğitim ve alıntı bölümü" width="800">
</p>

## Admin Paneli Ekran Görüntüleri

<details>
  <summary>Dashboard ve istatistikler</summary>
  <p align="center">
    <img src="docs/screenshots/admin-dashboard.png" alt="Admin dashboard ve genel istatistikler" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-dashboard-mesaj-istatistikleri.png" alt="Admin dashboard proje kategorileri ve son mesajlar bölümü" width="760">
  </p>
</details>

<details>
  <summary>Ana sayfa bannerı ve hakkımda</summary>
  <p align="center">
    <img src="docs/screenshots/admin-anasayfa-banner.png" alt="Ana sayfa bannerı yönetimi" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-hakkimda.png" alt="Hakkımda, fotoğraf ve özgeçmiş yönetimi" width="760">
  </p>
</details>

<details>
  <summary>Yetenekler</summary>
  <p align="center">
    <img src="docs/screenshots/admin-yetenekler.png" alt="Yetenek ve teknoloji listesi" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-yetenek-ekle.png" alt="Yeni yetenek ekleme formu" width="760">
  </p>
</details>

<details>
  <summary>Projeler</summary>
  <p align="center">
    <img src="docs/screenshots/admin-projeler.png" alt="Admin proje listesi" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-proje-duzenle.png" alt="Proje düzenleme formu" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-proje-ekle.png" alt="Yeni proje ekleme formu" width="760">
  </p>
</details>

<details>
  <summary>Deneyimler</summary>
  <p align="center">
    <img src="docs/screenshots/admin-deneyimler.png" alt="Deneyim listesi ve aktiflik durumları" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-deneyim-ekle.png" alt="Hızlı deneyim ekleme formu" width="760">
  </p>
</details>

<details>
  <summary>Eğitim</summary>
  <p align="center">
    <img src="docs/screenshots/admin-egitim.png" alt="Eğitim ve kurs kayıtları yönetimi" width="760">
  </p>
</details>

<details>
  <summary>İletişim bilgileri</summary>
  <p align="center">
    <img src="docs/screenshots/admin-iletisim-bilgileri.png" alt="İletişim bilgileri yönetimi; e-posta ve telefon gizlenmiştir" width="760">
  </p>
</details>

<details>
  <summary>Gelen mesajlar</summary>
  <p align="center">
    <img src="docs/screenshots/admin-mesajlar.png" alt="Gelen mesajlar listesi; gönderen ve mesaj bilgileri gizlenmiştir" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-mesaj-detayi.png" alt="Mesaj detayı; gönderen ve mesaj içeriği gizlenmiştir" width="760">
  </p>
</details>

<details>
  <summary>Sosyal medya hesapları</summary>
  <p align="center">
    <img src="docs/screenshots/admin-sosyal-medya.png" alt="Sosyal medya hesapları listesi" width="760">
  </p>
  <p align="center">
    <img src="docs/screenshots/admin-sosyal-medya-duzenle.png" alt="Sosyal medya hesabı düzenleme; profil bağlantısı gizlenmiştir" width="760">
  </p>
</details>

> Ekran görüntüleri sunum amacıyla eklenmiştir. Kişisel CV PDF dosyaları depoya dahil edilmez.
> Admin ekran görüntülerinde e-posta, telefon, kişisel profil bağlantısı ve ziyaretçi mesajı gibi özel bilgiler gizlenmiştir.
