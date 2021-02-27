using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Car Messages
        public static string CarAdded = "Araba başarı Eklendi.";
        public static string CarNameInvalid = "Araba ismi en az 2 karakterden oluşmalıdır ve günlük fiyat 0 dan düşük olamaz. ";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string CarsListed = "Arabalar listelendi.";
        public static string CarUpdated = "Araba başarı ile güncellendi.";
        public static string CarDeleted = "Araba başarı ile silindi.";
        //Brand Messages
        public static string BrandDeleted = "Marka başarı ile silindi.";
        public static string BrandUpdated = "Marka başarı ile güncellendi.";
        public static string BrandAdded = "Marka başarı ile eklendi.";
        public static string BrandNameInvalid = "Marka ismi en az 2 karakterden oluşmalıdır";
        //Color Messages
        public static string ColorDeleted = "Renk başarı ile silindi.";
        public static string ColorUpdated = "Renk başarı ile güncellendi.";
        public static string ColorAdded = "Renk başarı ile eklendi.";
        public static string ColorNameInvalid = "Renk ismi en az 2 karakterden oluşmalıdır";
        //Rental Messages
        public static string RentalAdded = "Kiralama başarı ile oluşturuldu";
        public static string RentalDeleted = "Kiralama başarı ile silindi.";
        public static string RentalUpdated = "Kiralama başarı ile güncellendi.";
        public static string RentalError = "Kiralama işlemi başarısız.";
        //User Messages
        public static string UserAdded = "Kullanıcı başarı ile eklendi";
        public static string UserDeleted = "Kullanıcı başarı ile silindi.";
        public static string UserUpdated = "Kullanıcı başarı ile güncellendi.";
        //Customer Messages
        public static string CustomerAdded = "Müşteri başarı ile eklendi";
        public static string CustomerDeleted = "Müşteri başarı ile silindi.";
        public static string CustomerUpdated = "Müşteri başarı ile güncellendi.";
        //Image Messages
        public static string ImageUpdate = "Resim güncellendi.";
        public static string ImageDeleted = "Resim silindi.";
        public static string ImageAdded = "Resim eklendi.";
        public static string ErrorImageLimit = "Bir arabanın 5'den fazla resmi olamaz!";

        public static string CarCountOfBrandError = "10'dan fazla kategori yazılamaz!";
    }
}
