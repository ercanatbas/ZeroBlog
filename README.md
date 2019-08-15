# ZeroBlog

### Tasarım Desenleri

-  **Domain Driven Design:** Hızlı değişen gereksinimlere hızlı adaptasyon sağlayan, kolay ölçeklenebilir, esnek ve yüksek erişilebilir bir yaklaşımı olduğu için tercih edilmiştir.
-  **Repository Pattern  :** Veriye erişimin ve yönetimin tek noktaya indirilmesini sağlamak amacıyla kullanılmıştır.
-  **Unit Of Work Pattern:** İş katmanında yapılan her değişikliğin anlık olarak database e yansıması yerine, işlemlerin toplu halde tek bir kanaldan gerçekleşmesi sağlanmıştır.
-  **Abstract Factory Pattern:** İlişkisel olan birden fazla nesnenin oluşturulmasında tek bir arayüz tarafından değil her ürün ailesi için farklı bir arayüz tanımlayarak sağlanmaktadır.

- **SOLID** prensiplerine uygun olarak geliştirme yapılmıştır.
- **TDD** uygulanmıştır.

### Kütüphaneler
- **Automapper**
- **Dapper**
- **FluentValidation**
- **Castle Windsor :** Uygulama içerisinde kullanılan objelerin instance' larının yönetimi ve uygulama boyunca yaşam döngüsünün kontrolü içn kullanılmıştır. (Autofac'te kullanılabilirdi.)
- **Jwt :** Authentication

### Neler eklenebilir?
- Proje dockerize edilebilir.

### Kurulum

Veritabanı MySQL dir. Veritabanı script'i data klasörünün altındadır. Default kullanıcı girişi aşağıdaki gibir.

*Email:* admin@admin.com
*Password:* 123456

*İletişim:* ercanatbas@hotmail.com
