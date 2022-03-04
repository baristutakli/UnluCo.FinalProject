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
<image src="https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/UnluCo.FinalProject/blob/master/Screenshots/ProductsPageScreenshot.png?raw=true" alt="Products" style="height:100%;width:100%">

<image src="https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/UnluCo.FinalProject/blob/master/Screenshots/CategoriesPageScreenshot.png?raw=true" alt="Categories" style="height:100%;width:100%">

<image src="https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/UnluCo.FinalProject/blob/master/Screenshots/UsersPageScreenshot.png?raw=true" alt="UsersPage" style="height:100%;width:100%">

<image src="https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/UnluCo.FinalProject/blob/master/Screenshots/LoginPageScreenshot.png?raw=true" alt="LoginPage" style="height:100%;width:100%">
<image src="https://github.com/Patika-dev-Unlu-Co-Net-Bootcamp/UnluCo.FinalProject/blob/master/Screenshots/SignUpPageScreenshot.png?raw=true" alt="SignUp" style="height:100%;width:100%">
