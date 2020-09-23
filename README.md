Proje .Net Core 3.1.8 versiyonu ile geliştirilmiştir. Local PC dotnet --version: 3.1.402

Proje UseInMemory formatında çalışabiliyor fakat sql üzerinde çalıştırmak isterseniz. WebApi içerisinde appsetting.json'daki bağlantı ayarlarını değiştirmeniz gerekiyor. UseInMemoryDatabase= false olacak.

## Stage 1
Bölüm gereksinimlerinde olmasa da kullanıcı login işlemlerini ekledim fakat registration işlemlerini eklemedim.
Bu haliyle eğer örnek bilgiler ile login olduğunuzda aldığınız JWT token bilgisini swagger üzerinden ekleyerek testlerinizi yapabilirsiniz.
Projenin bu halinde kullanıcı kontrolü bulunmuyor. Yani bir kullanıcı diğer bütün kullanıcılar için işlem yapabilir. Proje gereksinimlerinde olmadığı için bu kontrolü eklemedim.
Stage 2 projesine uyması için başlangıç olarak 200 adet şehir bilgisi eklenmiştir. Örnek Şehir isimleri City_1, City_200

##### Projede 3 adet search endpoint  bulunuyor. 
> Searchfromto: City bilgileri Cities endpoint bilgisinden getirilerek sadece ID bilgileri kullanılarak yapılıyor. Sadece yayında olan seferler içerisinde arama yapar.

> Searchfrom : Başlangıç şehrinin ismini arayarak sefer planlarını getiriyor.

> Searchto: Varış şehrinin ismini arayarak sefer planlarını getiriyor.

## Stage 2
Kullanıcı durmaksızın 2 şehir arasında gidecekse sadece başlangıç ve bitiş şehirleri içerisinde arama yapıyoruz. Kullanıcı 2 şehir arasına başka şehirleri durak olarak eklemiş ise rotaya bu şehirler dahil oluyor ve arama yapılabiliyor.

#### Örnek Kurgu
* POST /api/VoyagePlan => endpoint ile yeni bir sefer oluşturulur.
* POST /api/VoyagePlan/publish => bir önceki adımda oluşturulmuş olan sefer yayınlanır.
* POST /api/VoyagePlan/stop => daha önceden oluşturulmuş olan sefere ara duraklar eklenir.
* GET /api/VoyagePlan/searchfromto => Başlangıç ve Varış şehirleri bilgisi ile sefer araması yapılır. Başlangıç şehri olarak ara duraklarda kontrol ediliyor.
* POST /api/VoyagePlan/enroll  => var olan seferlere boştaki koltuk miktarına göre kayıt işlemi yapılır.

#### Projenin eksikleri
Projeyi oluştururken VoyagePlan ile Route oluşturup. Bu Route tablosuna sıralama ile durakları eklemem gerekiyordu. Böylelikle ara duraklar arasında indi bindi işlemi yapılabilirdi. Örnek senaryo A->B->C->D şehirleri bizim rotamızı oluşturmuş olsun. Kullanıcı B şehrinden binip C şehrinde inebilir. Projedeki şuan ki senaryoda kullanıcı B şehrinden binebiliyor fakat aramalarda C şehrini bulamıyor sadece D şehri gözüküyor bitiş için. Rotaya sıralama işlemi eklemediğim için kurgu şimdilik bu şekilde çalışıyor.

