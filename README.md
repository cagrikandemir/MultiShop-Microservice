# 🛒 MultiShop (.NET CORE 8.0 MICROSERVICE ARCHITECTURE)

Bu repository, Murat Yücedağ’ın Udemy üzerindeki [.Net Core MultiShop Mikroservis E-Ticaret](https://www.udemy.com/course/aspnet-core-multishop-mikroservis-e-ticaret-kursu/) kursu kapsamında, eğitim sürecim boyunca geliştirdiğim MultiShop projesini içermektedir. Bu proje, kursta edinilen teorik bilgilerin uygulamaya dökülmesini sağlamak amacıyla yapılandırılmış, gerçek dünya senaryolarına uygun şekilde, mikroservis mimarisi temel alınarak geliştirilmiştir.

## 🎯Proje Hakkında
MultiShop projesi, modern yazılım mimarilerine uygun olarak geliştirilmiş, mikroservis mimarisi ile çalışan ölçeklenebilir bir e-ticaret platformudur. Kullanıcılar sisteme ziyaretçi ya da kayıtlı kullanıcı olarak giriş yapabilir, ürünleri inceleyebilir, sepetine ekleyebilir, sipariş verebilir ve bu siparişleri takip edebilir.

Proje, hem frontend hem de backend tarafında farklı teknolojileri ve veritabanlarını entegre ederek yüksek erişilebilirlik, modülerlik, bağımsız geliştirme ve kolay ölçeklenebilirlik gibi mikroservislerin temel avantajlarını sunar.

## Proje Görselleri
<img width="1904" height="912" alt="Ekran görüntüsü 2026-08-20 141145" src="https://github.com/user-attachments/assets/8d50aecc-6fdc-46ae-881b-44318a0e7902" />
<img width="1899" height="910" alt="Ekran görüntüsü 2026-08-20 140909" src="https://github.com/user-attachments/assets/00f13dd4-8bb5-4fd9-a354-d56b3039290d" />
<img width="1899" height="901" alt="Ekran görüntüsü 2026-08-20 140839" src="https://github.com/user-attachments/assets/7292ba65-79fa-40fe-b34f-d085ea17d61a" />
<img width="1904" height="907" alt="Ekran görüntüsü 2026-08-20 140412" src="https://github.com/user-attachments/assets/1b1f5c4b-9622-49ce-b423-6033ecd827a6" />




## 🛠 Kullanılan Teknolojiler ve Araçlar
### 🧠 Backend & API Teknolojileri
+ 🤖 ASP.NET Core 8.0 Web Application
+ 🌐 ASP.NET Core Web API
+ 💾 Entity Framework Core
+ 💾 Dapper
+ 🚀 RapidAPI

### 🏗️ Mimari & Tasarım Desenleri
+ 🏛️ Onion Architecture
+ 🏛️ N-Tier Architecture
+ 📜 CQRS Design Pattern
+ 📜 Mediator Design Pattern
+ 📜 Repository Design Pattern

### 🔐 Kimlik Doğrulama & Güvenlik
+ 🔒 IdentityServer4
+ 🪙 Json Web Token (JWT)
+ 📧 MailKit

### 🚪 API Yönlendirme ve Gateway
+ 🌀 Ocelot API Gateway
+ 🔍 Discovery
 
### 💾 Veritabanları & Veri Yönetimi
+ 🗃️ MSSQL
+ 🐘 PostgreSQL
+ 🍃 MongoDB
+ 🚀 Redis
+ ☁️ Google Cloud Storage
+ 🐇 RabbitMQ

### 📡 Gerçek Zamanlı İletişim
+ 🔄 SignalR

### ⚙️ Geliştirme ve Test Araçları
+ 🐳 Docker
+ 🛠️ Postman
+ 🛠️ Swagger
+ 🖥️ DBeaver

### 🎨 Frontend Teknolojileri
+ 📝 HTML
+ 🖌️ CSS
+ ⚡ JavaScript
+ 📐 Bootstrap

### 🌍 Uluslararasılaştırma
+ 🌐 Localization

## 🧱 Mimari Yapı
Proje aşağıdaki gibi katmanlı bir mimariye sahiptir:

```
ApiGateway
   ├── MultiShop.OcelotGateway
Frontends
   ├── MultiShop.DtoLayer
   └── MultiShop.WebUI
IdentityServer
   └── MultiShop.IdentityServer
RapidApi
   └── MultiShop.RapidApiWebUI
Services
   ├── Basket
   ├── Cargo
   ├── Catalog
   ├── Comment
   ├── Discount
   ├── Image
   ├── Message
   ├── Order
   ├── Payment
   ├── RabbitMQMessage
   └── SignalRRealTimeApi
```
