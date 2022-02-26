## 🧐ÜNLÜ & Co .Net Bootcamp Bitirme Projesi
<hr>

Bitirme projesi iki ana projeyi ve bir background wroker servisini içermektedir. Üç projenin çalıştırılabilmesi için çoklu başlangıç seçeneğinden üç projenin seçilmiş olması gerekmektedir. Generic Repository ve UnitOfWork  patternleri kullanılmıştır.
Yapılan işlemler sırasıyla aşağıda açıklanmıştır. En son kısımda ise tüm görevler bir liste halinde bulunmaktadır.


#### Yetkilendirme 
Üye olma ve kayıt olabilme fonksiyonu eklendi. İki farklı şekilde kayıt işlemi gerçekleştirilmektedir. BlazorUI projesinden sadece normal kullanıcı kayıt işlemi gerçekleştirilmektedir. Üyelik kayır işlemleri için kullanıcı adı, e-posta ve bir parola gerekmektedir. Bir kullanıcı e-posta adresini üç defadan fazla girdiği takdirde hesabı kilitlenir ve kayıtlı  e-posta adresine bilgilendirme  e-postası gönderilir. Bu işlem için **Rabittmq**'den yararlanıldı. E-postalar bir kuyruk tablosunda toplanarak daha sonra arkaplan işçisi tarfından dinlenildikten sonra ilgili hesaplara mail gönderme işlemi gerçekleştirilir. **Background Worker** ve diğer servisleri kullanabilmek için aşağıdaki bilgilerin  **"appsettings.json"** dosyasına eklenmesi gerekmektedir. Kullanıcı bilgilerini doğru girdiği takdirde cevap olarak **token** gönderilmektedir ve bu token **localstorage** ta tutulmaktadır. 


###### Rabbitmq Bağlantı Adresi
```json
  "RabbitMqSettings": {
    "URL": "Rabbitmq'den aldığınız url adresinin girilmesi gereken alan"
  }
```


###### E-posta Ayarları
```json
  "MailSettings": {
    "Mail": "E-posta adresiniz",
    "DisplayName": "Görüntülenmesini istediğiniz ad",
    "Password": "Çok güvenli parola",
    "Host": "smtp.gmail.com",
    "Port": 587
  }
```
Son olarak ise **Worker.cs** dosyasında belirtilen kısımları doldurulması gerekmektedir.


###### Veri Tabanı Baglantı Ayarları
```json
"AllowedHosts": "*",
  "ConnectionStrings": {
    "ConnStr": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FinalProject;Integrated Security=True;Trusted_Connection=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
```
###### JWT Ayarları
```json
"JWT": {
    "ValidAudience": "http://localhost:5000/",
    "ValidIssuer": "http://localhost:5000/",
    "Secret": "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"
  }
```

#### Kategori
Ürünler kategorilere göre filtrelenerek BlazorUI projesindeki Categories sayfasına eklendi. API kullanılarak kategori ekleme silme güncelleme işlemleri eklendi. Blazor arayüze ise sadece kategorileri görüntüleme seçeneği eklendi.


#### Ürün Detayları
Yüzde değer olarak ve tam sayı değeri olarak teklif sunma seçeneği sunulmuştur. Servis kısmında dönüş işlemi gerçekleştirilerek veri tabanına kayıt edilmektedir. Bir ürüne teklif verildikten sonra teklifi iptel edebilme olanağı sunulmuştur. Verilen tekliflerden biri kullanıcı tarafından kabul edilirse diğer teklifler otomatikmen iptal edilip silinmektedir. Ürün satıldıktan sonra yeniden satışa kapalı durumu gelmektedir.


#### Hesabım Detayları
User sayfasından tüm kullanıcılara ait offerlar ürünler listelenmektedir. Alınan tekliflere onayla ve reddet ile cevap verilebilmektedir.


#### Ürün Ekleme Detayları
Ürün eklenirken istenilen bilgiler şunlardır: ürün adı, açıklama, kategori, renk, marka, kullanım durumu, ürün görseli, fiyat ve teklif opsiyonu.



#### Kullanılar Teknolojiler
* Automapper
* Entity Framework
* Rabittmq
* Fluent Validation
* Identity
* JWT Bearer
* Blazor
* Background Worker


<hr>


#### Ürün Katalog Projesi
#### İki ana proje olmalı
* web api
* blazor ui
#### Üye Ol Detayları
* Kullanıcılar sisteme üye olabilmeli. Kayıt işleminde alınan bilgiler eksiksiz olmali ve
validate edilmeli. Email bilgisi gecerli olmali.
* Kayıt sırasında kullanici sifresi şifrelenmiş şekilde databasede saklanmali.
* Ayni şifreye sahip kullanıcıların hashelenmis şifreleri mutlaka farkli olmali. (Tuzlama)
* Şifreler geri çözülemeyecek şekilde şifrelenip saklanmali.
* Email valid olmalı
* En az 8 ve en fazla 20 karakter uzunluğunda bir password girilmeli
* İşlem başarısız ise kullanıcıya tasarıma göre hata mesajı gösterilmeli
* İşlem başarılı ise API'den basarili mesaji gönderilmeli ve Hosgeldiniz Email i gönderilmeli.
#### Üye Girişi Detayları
* Kullanıcılar burden üye girişi yapabilmeli
* Email ve Password alanları zorunlu alanlar olmali. Boş ya da geçersiz gönderilirse uyari
verilmeli.
* Email ve Password alanlarının validasyonu yapılmalı
* Email valid olmalı ve en az 8 ve en fazla 20 karakter uzunluğunda bir password girilmeli
* İşlem başarısız ise kullanıcıya hata mesajı gösterilmeli
* İşlem başarılı ise API'de JWT token üretilmeli ve tüm authentication gerektiren
requestlerde header'a Bearer token olarak eklenmeli.
* 3 kez parolanın yanlış girilmesi durumunda hesabi bloke ediniz ve kullanıcıya
bilgilendirme maili gönderiniz.
Email Servisi
* Email gonderme islemlerini Sync olarak gonderecek bir tasarim yapmayiniz.
* Email ler bir kuyruk tablosunda toplanmali ve bir process ordan email gönderimi
yapmali.
* Database,kafka, rabbitmq vs üzerinde kuyruklama işlemi yapabilirsiniz.
* Hangfire gibi servisler kullanarak da yapabilirsiniz.
* Kuyruga gelen her email in en gec 2 sn icerisinde process edilmeli.
* Gönderilen email ler in status durumunu güncelleyiniz.
* Try count ile basarisiz olmasi durumunda tekrar göndermesini saglayiniz.
* 5 kez deneyip basarisiz olan kayitlari Farkli bir statüye cekerek güncelleyiniz
* Smtp entegrasyonu yaparak mail gönderimini saglayiniz.
* Smtp hizmetinin calisir sekilde olduğundan emin olunuz.
#### Kategori Detayları
* Tüm kategoriler listelenmeli
* Kullanıcı kategori id ile api call yaptiginda kategori altındaki ürünler kategoriye göre
filtrelenmeli, default olarak tüm ürünler çekilmeli.
* Yeni kategori eklenebilmeli veya mevcut olan güncellenebilmeli.
#### Ürün Detayları
* Teklif Ver apisi üründen gelen data içerisindeki isOfferable alanına göre control edilmeli.
* isOfferable durumunun sağlanmadığı takdirde teklif verilememeli.
* Teklif Ver apisi ile kullanıcı kendisi teklif girebilmeli. Teklif girme alanı number olmalı ve
buraya validasyon eklenmeli
* ayrica Teklif değeri yüzdelik olarak api tarafına yollanabilmeli (offeredPrice), mesela,
100₺ olan ürün için %40 değeri seçilirse, 40₺ teklif yapılabilmeli
* Eğer bir kullanıcı bir ürüne teklif verdiyse, o ürünün icin teklifini geri çekebilmeli. Verdigi
teklif yoksa kullanicilar bilgilendirilmeli.
* Kullanıcı teklif yapmadan bir ürünü direk satın alabilir. Kullanıcı ürünü satın alınca, ilgili
ürün datası içerisindeki isSold alanının değeri güncellenmeli.
#### Hesabım Detayları
* Kullanıcının yaptığı offer lar listelenmeli.
* Kullanicinin urunleri icin aldigi offer lar listelenmeli.
* Alınan tekliflere Onayla ve Reddet ile cevap verilebilmeli
* Verilen teklif onaylandığında satin alma icin uygun duruma getirilmeli. 
* Ürün detaydaki gibi Satın Al tetiklenince statu güncellenmeli. Satın Al'a tetiklenince Teklif Verdiklerim listesindeki ürünün durumu güncellenmeli
#### Ürün Ekleme Detayları
* İlgili validasyonlar eklenmeli:
* Ürün Adı alanı maksimum 100 karakter uzunluğunda olmalı ve zorunlu bir alan olmalı
* Açıklama alanı maksimum 500 karakter uzunluğunda olmalı ve zorunlu bir alan olmalı
* Kategori alanı ilgili endpointten çekilen kategorileri listelemeli ve en fazla bir kategori
seçebilmeli. Bu alan zorunlu bir alan olmalı
* Renk alanı ilgili endpointten çekilen renkleri listelemeli ve en fazla bir renk seçebilmeli. Bu
alan zorunlu bir alan olmamalı
* Marka alanı ilgili endpointten çekilen markaları listelemeli ve en fazla bir marka
seçilebilmeli. Bu alan zorunlu bir alan olmamalı
* Kullanım Durumu alanı ilgili endpointten çekilen kullanım durumlarını listelemeli ve en
fazla bir kullanım durumu seçebilmeli. Bu alan zorunlu bir alan olmalı
* Ürün Görseli alanından en fazla bir ürün görseli eklenmeli. Eklenen ürün görseli
istenildiği zaman silinebilmeli. Bu alan zorunlu bir alan olmalı. Sadece png/jpg/jpeg
formatında görseller eklenmeli. Maksimum 400kb değerinde görseller eklenilebilmeli
* Fiyat alanı number olmalı ve zorunlu bir alan olmalı
* Teklif Opsiyonu alanı boolean bir değer olmalı ve default olarak false olmalı

#### Ek Proje Gereksinimleri:
* Yazılan projenin nasıl ayağa kalktığı ve benzeri detayların paylaşıldığı bir README.md
file'ı projlere eklenmeli
* Clean kod , SOLID prensiplerine uymaya önem gösterilmeli.
* proje kapsamında enaz bir trigger ve stored procedure kullanmalısınız
* Repository , UnitOfWork gibi patternleri kullanarak gelistirme yapiniz.
ÖNEMLİ: Projenin detayları ve tasarımı herhangi bir yerde paylaşılmamalı!
Repositoryler private olmalı!