# 🎯 EventPro — Etkinlik Yönetim ve Analiz Platformu

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat-square&logo=dotnet)
![Dapper](https://img.shields.io/badge/Dapper-ORM-0078D4?style=flat-square)
![MSSQL](https://img.shields.io/badge/Microsoft%20SQL%20Server-Veritaban%C4%B1-CC2927?style=flat-square&logo=microsoftsqlserver)
![Chart.js](https://img.shields.io/badge/Chart.js-G%C3%B6rselleştirme-FF6384?style=flat-square&logo=chartdotjs)
![Lisans](https://img.shields.io/badge/lisans-MIT-green?style=flat-square)

> Gerçek zamanlı analiz paneliyle tam kapsamlı bir etkinlik yönetim sistemi. Etkinlikler, organizasyonlar, şehirler, bütçeler ve katılımcı verilerini tek bir platformda takip edin.

---

## ✨ Özellikler

- 📊 **Analiz Paneli** — En iyi şehirler, organizasyonlar, yıllık trendler, bütçe sıralamaları
- 🏙️ **Şehir Bazlı Analiz** — Etkinlik sayısı ve katılımcı yoğunluğunu gösteren balon grafiği
- 💰 **Bütçe Takibi** — En yüksek bütçeli 5 etkinlik için yatay bar grafiği
- 📅 **Zaman Çizelgesi** — İlerleme çubukları ile yıllara göre etkinlik yoğunluğu
- 🍩 **Organizasyon Payı** — Organizasyon dağılımını gösteren halka grafiği
- 🔍 **Etkinlik Filtreleme** — Şehir, tür, organizasyon ve tarih aralığına göre filtreleme

---

## 🛠️ Teknoloji Yığını

| Katman | Teknoloji |
|--------|-----------|
| Backend | ASP.NET Core MVC (.NET 8) |
| ORM | Dapper |
| Veritabanı | Microsoft SQL Server |
| Frontend | Razor Views, Chart.js, Font Awesome |
| Stil | Özel CSS (Inter font) |

---

## 🚀 Kurulum

### Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) veya SQL Server Express
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ya da VS Code

### Adımlar

**1. Depoyu klonlayın**
```bash
git clone https://github.com/kullaniciadi/EventPro.git
cd EventPro
```

**2. Veritabanı bağlantısını yapılandırın**

`appsettings.json` dosyasını açıp bağlantı dizesini güncelleyin:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SUNUCU_ADI;Database=EtkinlikDb;Trusted_Connection=True;"
  }
}
```
## 📸 Ekran Görüntüleri

### 🖥️ Ana Dashboard
![Ana Dashboard](DapperActivityProject/dashboard.png)

### 🍩 Organizasyon Dağılımı
![Organizasyon](DapperActivityProject/organizasyon.png)

#### 🗓️ Etkinlik Listesi
![Etkinlik Listesi](DapperActivityProject/Activity.png)

### ➕ Yeni Etkinlik Ekleme
![Yeni Etkinlik Ekleme](DapperActivityProject/CreateActivity.png)
