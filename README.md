# Rehber

    ## <h1>Başlarken </h1>
    Bir Rehber dizayn ettim. Bu Rehber'e sonsuz sayıda kişi eklenip, güncellenip, silinebilir.
    Talep edildiği takdirde bu Rehber'de kişiler LINQ ile sorgulanıp arzu edilen listeler oluşturulabilir.
    Projede **EntityFramework, AspNetCore,NetCore, Redis**'den faydalanılmıştır. **Html5** ve **C#** dilleri kullanılmıştır.

    ## Kurulum
    Proje .net5.0 versiyonla oluşturulmuştur.
     ###Gerekli olan NuGet Packagelar:
      EntityFrameworkCore (SqlServer, Design, Tools)
      AspNetCore.Mvc
      Redis
      Projede yüklenmesi gereken kütüphaneler Requirements.txt dosyasında belirtilmiştir.

    ## Projenin işleyişi
    1-Bu projede Rehber'i oluşturmak için belirtilen özelliklere sahip class oluşturdum ve bu classa başka bilgiler içeren class yardımcı oldu. /Models/PersonModel.cs
    2-Bu modeli raporlama kısmında kullanmak üzere oluşturduğum interface **(/IPersonService)** ile implemente ettim ve rehber üzerinde talep edilen eylemleri gerçekleştirmek üzere özellikler kazandırdım. /Services/PersonService.cs
    3-Daha sonra oluşturduğum içerik bilgileri html üzerinde görüntülemek üzere gerekli .cshtml dosyaları yazdım, Form oluşturdum. /Views/Home/Create-Delete-Index-Search-Update.cshtml
    4-Gerekli dizaynı oluşturdum ve oluşturduğum her butonu işlevsel hale getirdim. /Controllers/HomeController.cs
    5-Raporlama için gerekli sınıfları olşturduktan sonra Form üzerine bu sorguları aktardım. /Models/PersonForLocationModels.cs
    6-Proje'yi Redis'e uygun olarak düzenleyip gerekli ayarlamaları ve bağlantıları yaptım. /Services/Redis/...
    7-Proje'ye migration uygulayıp yüklediğim database ile sürekli güncel tuttum.
