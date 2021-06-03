using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // Araba sınıfıyla ilgili mesajlar...
        public static string CarAdded = "Araba eklendi.";
        public static string CarNotAdded = "Araba eklenemedi.";
        public static string CarNameInvalid = "Araba ismi geçersizdir.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarNotUpdated = "Araba güncellenemedi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarNotDeleted = "Araba silinemedi.";
        public static string CarAllListed = "Tüm Arabalar listelendi.";
        public static string CarAllNotListed = "Arabalar listelenemedi.";
        public static string CarDailyPrice = "Girilen aralık hatalı olabilir.";
        public static string CarGeted = "Araba getirildi.";
        public static string CarNotGeted = "Araba getirilemedi.";


        // Marka sınıfıyla ilgili mesajlar...
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandNotAdded = "Marka eklenemedi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandNotUpdated = "Marka güncellenemedi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandNotDeleted = "Marka silinemedi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandNotListed = "Markalar listelenemedi.";
        public static string BrandGeted = "Marka getirildi.";
        public static string BrandNotGeted = "Marka getirilemedi.";



        // Renk sınıfıyla ilgili mesajlar...
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorNotAdded = "Renk eklenemedi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorNotUpdated = "Renk güncellenemedi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorNotDeleted = "Renk silinemedi.";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorNotListed = "Renkler listelenemedi.";
        public static string ColorGeted = "Renk getirildi.";
        public static string ColorNotGeted = "Renk getirilemedi.";



        // Kullanıcı sınıfıyla ilgili mesajlar...
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserNotAdded = "Kullanıcı eklenemedi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserNotUpdated = "Kullanıcı güncellenemedi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserNotDeleted = "Kullanıcı silinemedi.";
        public static string UserListed = "Kullanıcılar listelendi.";
        public static string UserNotListed = "Kullanıcılar listelenemedi.";
        public static string UserGeted = "Kullanıcı getirildi.";
        public static string UserNotGeted = "Kullanıcı getirilemedi.";



        // Müşteri sınıfıyla ilgili mesajlar...
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerNotAdded = "Müşteri eklenemedi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerNotUpdated = "Müşteri güncellenemedi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerNotDeleted = "Müşteri silinemedi.";
        public static string CustomerListed = "Müşteriler listelendi.";
        public static string CustomerNotListed = "Müşteriler listelenemedi.";
        public static string CustomerGeted = "Müşteri getirildi.";
        public static string CustomerNotGeted = "Müşteri getirilemedi.";



        // Kİralama sınıfıyla ilgili mesajlar...
        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalNotAdded = "Kiralama eklenemedi.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string RentalNotUpdated = "Kiralama güncellenemedi.";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalNotDeleted = "Kiralama silinemedi.";
        public static string RentalListed = "Kiralama işlemleri listelendi.";
        public static string RentalNotListed = "Kiralama işlemleri listelenemedi.";
        public static string RentalGeted = "Kiralama getirildi.";
        public static string RentalNotGeted = "Kiralama getirilemedi.";
        public static string ValueblesInvalid = "Araba teslim tarihi girilmemiş veya aranılan bir araç bulunamamıştır.";
        public static string ReturnDateAdded = "Araba teslim tarihi eklenmiştir.";
        public static string ReturnDateNotAdded = "Araba teslim tarihi eklenememiştir.";



        //Genel uyarı mesajları...
        public static string NotFound = "Erişilmek istenen öge bulunmamaktadır.";

        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string ImageLimitExpiredForCar = "Bir arabaya maximum 5 fotoğraf eklenebilir";
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);
        public static string CarImageMustBeExists = "Böyle bi resim bulunamadı";
        public static string CarHaveNoImage = "Arabaya ait bi resim yok";
    }
}
