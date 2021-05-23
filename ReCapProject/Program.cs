using Business.Concrete;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ReCapProject
{
    class Program
    {
        private static CarManager carManager = new CarManager(new EfCarDal());
        private static BrandManager brandManager = new BrandManager(new EfBrandDal());
        private static ColorManager colorManager = new ColorManager(new EfColorDal());
        private static UserManager userManager = new UserManager(new EfUserDal());
        private static CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        private static RentalManager rentalManager = new RentalManager(new EfRentalDal());

        public static void Main(string[] args)
        {
            TabloSec();
        }

        public static void TabloSec()
        {
            Console.WriteLine("Hangi tablo ile işlem yapmak istediğinizi seçiniz:");
            Console.WriteLine("1- Araba tablosu");
            Console.WriteLine("2- Marka tablosu");
            Console.WriteLine("3- Renk tablosu");
            Console.WriteLine("4- Kullanıcı tablosu");
            Console.WriteLine("5- Müşteri tablosu");
            Console.WriteLine("6- Araç Kiralama tablosu");

            int tablo = int.Parse(Console.ReadLine());

            switch (tablo)
            {
                case 1:
                    CarProcess(carManager.GetAll().Data);
                    break;
                case 2:
                    BrandProcess(brandManager.GetAll().Data);
                    break;
                case 3:
                    ColorProcess(colorManager.GetAll().Data);
                    break;
                case 4:
                    UserProcess(userManager.GetAll().Data);
                    break;
                case 5:
                    CustomerProcess(customerManager.GetAll().Data);
                    break;
                case 6:
                    RentalProcess(rentalManager.GetAll().Data);
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            SelectProcess();
        }

        public static int SelectProcess()
        {
            Console.WriteLine("Hangi işlem yapmak istediğinizi seçiniz:");
            Console.WriteLine("1- Ekleme");
            Console.WriteLine("2- Güncelleme");
            Console.WriteLine("3- Silme");
            Console.WriteLine("4- Tümünü listele");
            Console.WriteLine("5- Birini getir");

            int islem = int.Parse(Console.ReadLine());

            return islem;
        }

        public static void CarProcess(List<Car> cars)
        {
            int deger = SelectProcess();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("\nAraba ekleme işlemi yapılıyor...\n");

                    Car addedCar = new Car();

                    Console.Write("Marka id : ");
                    addedCar.BrandId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Renk id : ");
                    addedCar.ColorId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Araba İsmi : ");
                    addedCar.CarName = Console.ReadLine();

                    Console.Write("Model Yılı : ");
                    addedCar.ModelYear = Console.ReadLine();

                    Console.Write("Günlük Ücreti : ");
                    addedCar.DailyPrice = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Açıklaması : ");
                    addedCar.Description = Console.ReadLine();

                    if (!carManager.Add(addedCar).Success)
                    {
                        Console.WriteLine("\nAraba ekleme işlemi tamamlanamadı...\n");
                    }
                    
                    Console.WriteLine("\nAraba ekleme işlemi tamamlandı...\n");

                    break;
                case 2:
                    Console.WriteLine("Araba güncelleme işlemi yapılıyor...\n");

                    Console.Write("Güncellemek istenilen araba id giriniz : ");

                    int updatedId = Convert.ToInt32(Console.ReadLine());
                    Car updatedCar = carManager.Get(c => c.Id == updatedId) as Car;
                    Console.WriteLine("Güncellenmek istenen Araba Bilgileri : \n" +
                                    $"id: {updatedCar.Id}\n" +
                                    $"Marka id: {updatedCar.BrandId}\n" +
                                    $"Renk id: {updatedCar.ColorId}\n" +
                                    $"Araba İsmi: {updatedCar.CarName}\n" +
                                    $"Model Yılı: {updatedCar.ModelYear}\n" +
                                    $"Günlük Ücreti: {updatedCar.DailyPrice}\n" +
                                    $"Açıklaması: {updatedCar.Description}\n");

                    Console.Write("Marka id : ");
                    updatedCar.BrandId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Renk id : ");
                    updatedCar.ColorId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Araba İsmi : ");
                    updatedCar.CarName = Console.ReadLine();

                    Console.Write("Model Yılı : ");
                    updatedCar.ModelYear = Console.ReadLine();

                    Console.Write("Günlük Ücreti : ");
                    updatedCar.DailyPrice = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Açıklaması : ");
                    updatedCar.Description = Console.ReadLine();

                    if (!carManager.Update(updatedCar).Success)
                    {
                        Console.WriteLine("\nAraba güncelleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Araba güncelleme işlemi tamamlandı...\n");
                    break;
                case 3:
                    Console.WriteLine("Araba silme işlemi yapılıyor...\n");
                    Console.WriteLine("Silmek istenilen araba id giriniz : ");

                    int deletedId = Convert.ToInt32(Console.ReadLine());
                    Car deletedCar = carManager.Get(c => c.Id == deletedId).Data;
                    Console.WriteLine("Silinmek istenen Araba Bilgileri : \n" +
                                    $"id: {deletedCar.Id}\n" +
                                    $"Marka id: {deletedCar.BrandId}\n" +
                                    $"Renk id: {deletedCar.ColorId}\n" +
                                    $"Araba İsmi: {deletedCar.CarName}\n" +
                                    $"Model Yılı: {deletedCar.ModelYear}\n" +
                                    $"Günlük Ücreti: {deletedCar.DailyPrice}\n" +
                                    $"Açıklaması: {deletedCar.Description}\n");

                    if (!carManager.Delete(deletedCar).Success)
                    {
                        Console.WriteLine("\nAraba silme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Araba silme işlemi tamamlandı...\n");
                    break;
                case 4:
                    Console.WriteLine("Tüm arabalar listeleniyor...\n");

                    foreach (var car in carManager.GetCarsDetails().Data)
                    {
                        Console.WriteLine($"{car.Id} - {car.BrandName} - {car.ColorName} - {car.ModelYear} - {car.DailyPrice}");
                    }
                    
                    Console.WriteLine("Tüm arabalar listelendi...\n");
                    break;
                case 5:
                    Console.WriteLine("Bir araba getirme işlemi yapılıyor...\n");
                    Console.WriteLine("Görüntülenmek istenilen araba id giriniz : ");

                    int getId = Convert.ToInt32(Console.ReadLine());
                    CarDetailsDto getCar = carManager.GetCarDetails(getId) as CarDetailsDto;

                    Console.WriteLine($"{getCar.Id} - {getCar.BrandName} - {getCar.ColorName} - {getCar.ModelYear} - {getCar.DailyPrice} - {getCar.Description}");

                    Console.WriteLine("Araba görüntüleme işlemi tamamlandı...\n");
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            Console.WriteLine("Arabalar ile işlem yapmak isterseniz (e)\n" +
                "Tablo seçmek isterseniz (h)\n" +
                "Çıkış yapmak için herhangi bir tuşa basabilirsiniz.");

            string devam = Console.ReadLine();

            if (devam == "e")
            {
                CarProcess(cars);
            }
            else if (devam == "h")
            {
                TabloSec();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static void BrandProcess(List<Brand> brands)
        {
            int deger = SelectProcess();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Marka ekleme işlemi yapılıyor...\n");
                    Brand addedBrand = new Brand();

                    Console.WriteLine("Marka Adı : ");
                    addedBrand.BrandName = Console.ReadLine();

                    if (!brandManager.Add(addedBrand).Success)
                    {
                        Console.WriteLine("\nMarka ekleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Marka ekleme işlemi tamamlandı...\n");
                    break;
                case 2:
                    Console.WriteLine("Marka güncelleme işlemi yapılıyor...\n");
                    Console.WriteLine("Güncellemek istenilen marka id giriniz : ");

                    int updatedId = Convert.ToInt32(Console.ReadLine());
                    Brand updatedBrand = brandManager.Get(b => b.Id == updatedId).Data;
                    Console.WriteLine("Güncellemek istenen Marka Bilgileri : \n" +
                                    $"id: {updatedBrand.Id}\n" +
                                    $"Marka Adı: {updatedBrand.BrandName}\n");

                    Console.WriteLine("Marka Adı : ");
                    updatedBrand.BrandName = Console.ReadLine();

                    if (!brandManager.Update(updatedBrand).Success)
                    {
                        Console.WriteLine("\nMarka güncelleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Marka güncelleme işlemi tamamlandı...\n");
                    break;
                case 3:
                    Console.WriteLine("Marka silme işlemi yapılıyor...\n");
                    Console.WriteLine("Silmek istenilen marka id giriniz : ");

                    int deletedId = Convert.ToInt32(Console.ReadLine());
                    Brand deletedBrand = brandManager.Get(b => b.Id == deletedId).Data;
                    Console.WriteLine("Silinmek istenen Marka Bilgileri : \n" +
                                    $"id: {deletedBrand.Id}\n" +
                                    $"Marka Adı: {deletedBrand.BrandName}\n");

                    if (!brandManager.Get(b => b.Id == deletedId).Success)
                    {
                        Console.WriteLine("\nMarka silme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Marka silme işlemi tamamlandı...\n");
                    break;
                case 4:
                    Console.WriteLine("Tüm markalar listeleniyor...\n");

                    foreach (var brand in brandManager.GetAll().Data)
                    {
                        Console.WriteLine($"{brand.Id} - {brand.BrandName}");
                    }
                    Console.WriteLine("Tüm markalar listelendi...\n");
                    break;
                case 5:
                    Console.WriteLine("Bir marka getirme işlemi yapılıyor...\n");
                    Console.WriteLine("Görüntülenmek istenilen marka id giriniz : ");

                    int getId = Convert.ToInt32(Console.ReadLine());
                    Brand getBrand = brandManager.Get(b => b.Id == getId).Data;

                    if (getBrand != null)
                    {
                        Console.WriteLine($"{getBrand.Id} - {getBrand.BrandName}");
                    }
                    Console.WriteLine("Bir marka getirme işlemi tamamlandı...\n");
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            Console.WriteLine("Markalar ile işlem yapmak isterseniz (e)\n" +
                "Tablo seçmek isterseniz (h)\n" +
                "Çıkış yapmak için herhangi bir tuşa basabilirsiniz.");

            string devam = Console.ReadLine();

            if (devam == "e")
            {
                BrandProcess(brands);
            }
            else if (devam == "h")
            {
                TabloSec();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static void ColorProcess(List<Color> customers)
        {
            int deger = SelectProcess();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Renk ekleme işlemi yapılıyor...\n");
                    Color addedColor = new Color();

                    Console.WriteLine("Renk Adı : ");
                    addedColor.ColorName = Console.ReadLine();

                    if (!colorManager.Add(addedColor).Success)
                    {
                        Console.WriteLine("\nRenk ekleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Renk ekleme işlemi tamamlandı...\n");
                    break;
                case 2:
                    Console.WriteLine("Renk güncelleme işlemi yapılıyor...\n");
                    Console.WriteLine("Güncellemek istenilen renk id giriniz : ");

                    int updatedId = Convert.ToInt32(Console.ReadLine());
                    Color updatedColor = colorManager.Get(co => co.Id == updatedId).Data;
                    Console.WriteLine("Güncellenmek istenen Renk Bilgileri : \n" +
                                    $"id: {updatedColor.Id}\n" +
                                    $"Renk Adı: {updatedColor.ColorName}\n");

                    Console.WriteLine("Renk Adı : ");
                    updatedColor.ColorName = Console.ReadLine();

                    if (!colorManager.Update(updatedColor).Success)
                    {
                        Console.WriteLine("\nRenk güncelleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Renk güncelleme işlemi tamamlandı...\n");
                    break;
                case 3:
                    Console.WriteLine("Renk silme işlemi yapılıyor...\n");
                    Console.WriteLine("Silmek istenilen renk id giriniz : ");

                    int deletedId = Convert.ToInt32(Console.ReadLine());
                    Color deletedColor = colorManager.Get(co => co.Id == deletedId).Data;
                    Console.WriteLine("Silinmek istenen Renk Bilgileri : \n" +
                                    $"id: {deletedColor.Id}\n" +
                                    $"Marka Adı: {deletedColor.ColorName}\n");

                    if (!colorManager.Delete(deletedColor).Success)
                    {
                        Console.WriteLine("\nRenk silme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Renk silme işlemi tamamlandı...\n");
                    break;
                case 4:
                    Console.WriteLine("Tüm renkler listeleniyor...\n");

                    foreach (var color in colorManager.GetAll().Data)
                    {
                        Console.WriteLine($"{color.Id} - {color.ColorName}");
                    }
                    Console.WriteLine("Tüm renkler listelendi...\n");
                    break;
                case 5:
                    Console.WriteLine("Bir renk getirme işlemi yapılıyor...\n");
                    Console.WriteLine("Görüntülenmek istenilen renk id giriniz : ");

                    int getId = Convert.ToInt32(Console.ReadLine());
                    Color getColor = colorManager.Get(co => co.Id == getId).Data;

                    if (getColor != null)
                    {
                        Console.WriteLine($"{getColor.Id} - {getColor.ColorName}");
                    }
                    Console.WriteLine("Bir renk getirme işlemi tamamlandı...\n");
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            Console.WriteLine("Renkler ile işlem yapmak isterseniz (e)\n" +
                "Tablo seçmek isterseniz (h)\n" +
                "Çıkış yapmak için herhangi bir tuşa basabilirsiniz.");

            string devam = Console.ReadLine();

            if (devam == "e")
            {
                ColorProcess(customers);
            }
            else if (devam == "h")
            {
                TabloSec();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void UserProcess(List<User> users)
        {
            int deger = SelectProcess();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Kullanıcı ekleme işlemi yapılıyor...\n");
                    User addedUser = new User();

                    Console.WriteLine("Ad : ");
                    addedUser.FirstName = Console.ReadLine();

                    Console.WriteLine("Soyad : ");
                    addedUser.LastName = Console.ReadLine();

                    Console.WriteLine("Email : ");
                    addedUser.Email = Console.ReadLine();

                    Console.WriteLine("Şifre : ");
                    addedUser.Password = Console.ReadLine();

                    if (!userManager.Add(addedUser).Success)
                    {
                        Console.WriteLine("\nRenk ekleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Kullanıcı ekleme işlemi tamamlandı...\n");
                    break;
                case 2:
                    Console.WriteLine("Kullanıcı güncelleme işlemi yapılıyor...\n");
                    Console.WriteLine("Güncellemek istenilen kullanıcı id giriniz : ");

                    int updatedId = Convert.ToInt32(Console.ReadLine());
                    User updatedUser = userManager.Get(u => u.Id == updatedId).Data;
                    Console.WriteLine("Güncellenmek istenen Kullanıcı Bilgileri : \n" +
                                    $"id: {updatedUser.Id}\n" +
                                    $"Adı: {updatedUser.FirstName}\n" +
                                    $"Soyadı: {updatedUser.LastName}\n" +
                                    $"Email: {updatedUser.Email}\n");

                    Console.WriteLine("Adı : ");
                    updatedUser.FirstName = Console.ReadLine();

                    Console.WriteLine("Soyadı : ");
                    updatedUser.LastName = Console.ReadLine();

                    Console.WriteLine("Email : ");
                    updatedUser.Email = Console.ReadLine();

                    Console.WriteLine("Şifre : ");
                    updatedUser.Password = Console.ReadLine();

                    if (!userManager.Update(updatedUser).Success)
                    {
                        Console.WriteLine("\nKullanıcı güncelleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Kullanıcı güncelleme işlemi tamamlandı...\n");
                    break;
                case 3:
                    Console.WriteLine("Kullanıcı silme işlemi yapılıyor...\n");
                    Console.WriteLine("Silmek istenilen kullanıcı id giriniz : ");

                    int deletedId = Convert.ToInt32(Console.ReadLine());
                    User deletedUser = userManager.Get(u => u.Id == deletedId).Data;
                    Console.WriteLine("Silinmek istenen Kullanıcı Bilgileri : \n" +
                                    $"id: {deletedUser.Id}\n" +
                                    $"Adı: {deletedUser.FirstName}\n" +
                                    $"Soyadı: {deletedUser.LastName}\n" +
                                    $"Email: {deletedUser.Email}\n");

                    if (!userManager.Delete(deletedUser).Success)
                    {
                        Console.WriteLine("\nKullanıcı silme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Kullanıcı silme işlemi tamamlandı...\n");
                    break;
                case 4:
                    Console.WriteLine("Tüm kullanıcılar listeleniyor...\n");

                    foreach (var user in userManager.GetAll().Data)
                    {
                        Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName} - {user.Email}");
                    }
                    Console.WriteLine("Tüm kullanıcılar listelendi...\n");
                    break;
                case 5:
                    Console.WriteLine("Bir renk getirme işlemi yapılıyor...\n");
                    Console.WriteLine("Görüntülenmek istenilen renk id giriniz : ");

                    int getId = Convert.ToInt32(Console.ReadLine());
                    User getUser = userManager.Get(u => u.Id == getId).Data;

                    if (getUser != null)
                    {
                        Console.WriteLine($"{getUser.Id} - {getUser.FirstName} {getUser.LastName} - {getUser.Email}");
                    }
                    Console.WriteLine("Bir kullanıcı getirme işlemi tamamlandı...\n");
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            Console.WriteLine("Kullanıcılar ile işlem yapmak isterseniz (e)\n" +
                "Tablo seçmek isterseniz (h)\n" +
                "Çıkış yapmak için herhangi bir tuşa basabilirsiniz.");

            string devam = Console.ReadLine();

            if (devam == "e")
            {
                UserProcess(users);
            }
            else if (devam == "h")
            {
                TabloSec();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void CustomerProcess(List<Customer> customers)
        {
            int deger = SelectProcess();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Müşteri ekleme işlemi yapılıyor...\n");
                    Customer addedCustomer = new Customer();

                    Console.WriteLine("Kullanıcı Id : ");
                    addedCustomer.UserId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Müşteri Adı : ");
                    addedCustomer.CompanyName = Console.ReadLine();

                    if (!customerManager.Add(addedCustomer).Success)
                    {
                        Console.WriteLine("\nMüşteri ekleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Müşteri ekleme işlemi tamamlandı...\n");
                    break;
                case 2:
                    Console.WriteLine("Müşteri güncelleme işlemi yapılıyor...\n");
                    Console.WriteLine("Güncellemek istenilen müşteri id giriniz : ");

                    int updatedId = Convert.ToInt32(Console.ReadLine());
                    Customer updatedCustomer = customerManager.Get(cu => cu.Id == updatedId).Data;
                    Console.WriteLine("Güncellenmek istenen Müşteri Bilgileri : \n" +
                                    $"id: {updatedCustomer.Id}\n" +
                                    $"Kullanıcı Id: {updatedCustomer.UserId}\n" +
                                    $"Müşteri Adı: {updatedCustomer.CompanyName}\n");

                    Console.WriteLine("Kullanıcı Id : ");
                    updatedCustomer.UserId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Müşteri Adı : ");
                    updatedCustomer.CompanyName = Console.ReadLine();

                    if (!customerManager.Update(updatedCustomer).Success)
                    {
                        Console.WriteLine("\nMüşteri güncelleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Müşteri güncelleme işlemi tamamlandı...\n");
                    break;
                case 3:
                    Console.WriteLine("Müşteri silme işlemi yapılıyor...\n");
                    Console.WriteLine("Silmek istenilen müşteri id giriniz : ");

                    int deletedId = Convert.ToInt32(Console.ReadLine());
                    Customer deletedCustomer = customerManager.Get(co => co.Id == deletedId).Data;
                    Console.WriteLine("Silinmek istenen Müşteri Bilgileri : \n" +
                                    $"id: {deletedCustomer.Id}\n" +
                                    $"Kullanıcı Id: {deletedCustomer.UserId}\n" +
                                    $"Müşteri Adı: {deletedCustomer.CompanyName}\n");

                    if (!customerManager.Delete(deletedCustomer).Success)
                    {
                        Console.WriteLine("\nMüşteri silme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Müşteri silme işlemi tamamlandı...\n");
                    break;
                case 4:
                    Console.WriteLine("Tüm müşteriler listeleniyor...\n");

                    foreach (var customer in customerManager.GetAll().Data)
                    {
                        User user = userManager.Get(u => u.Id == customer.UserId).Data;
                        Console.WriteLine($"{customer.Id} - {user.FirstName} {user.FirstName}{customer.CompanyName}");
                    }
                    Console.WriteLine("Tüm müşteriler listelendi...\n");
                    break;
                case 5:
                    Console.WriteLine("Bir müşteri getirme işlemi yapılıyor...\n");
                    Console.WriteLine("Görüntülenmek istenilen müşteri id giriniz : ");

                    int getId = Convert.ToInt32(Console.ReadLine());
                    Customer getCustomer = customerManager.Get(co => co.Id == getId).Data;

                    if (getCustomer != null)
                    {
                        Console.WriteLine($"{getCustomer.Id} - {getCustomer.CompanyName}");
                    }
                    Console.WriteLine("Bir müşteri getirme işlemi tamamlandı...\n");
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            Console.WriteLine("Müşteriler ile işlem yapmak isterseniz (e)\n" +
                "Tablo seçmek isterseniz (h)\n" +
                "Çıkış yapmak için herhangi bir tuşa basabilirsiniz.");

            string devam = Console.ReadLine();

            if (devam == "e")
            {
                CustomerProcess(customers);
            }
            else if (devam == "h")
            {
                TabloSec();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void RentalProcess(List<Rental> rentals)
        {
            int deger = SelectProcess();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Araç Kiralama ekleme işlemi yapılıyor...\n");
                    Rental addedRental = new Rental();

                    Console.WriteLine("Araç Kiralama Müşteri Id: ");
                    addedRental.CustomerId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Araç Kiralama Tarihi: ");
                    addedRental.RentDate = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Araç Teslim Tarihi: ");
                    addedRental.ReturnDate = Convert.ToDateTime(Console.ReadLine());

                    if (!rentalManager.Add(addedRental).Success)
                    {
                        Console.WriteLine("\nAraç Kiralama ekleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Araç Kiralama ekleme işlemi tamamlandı...\n");
                    break;
                case 2:
                    Console.WriteLine("Araç Kiralama güncelleme işlemi yapılıyor...\n");
                    Console.WriteLine("Güncellemek istenilen araç kiralama id giriniz : ");

                    int updatedId = Convert.ToInt32(Console.ReadLine());
                    Rental updatedRental = rentalManager.Get(co => co.Id == updatedId).Data;
                    Console.WriteLine("Güncellenmek istenen Araç Kiralama Bilgileri : \n" +
                                    $"id: {updatedRental.Id}\n" +
                                    $"Müşteri Id: {updatedRental.CustomerId}\n" +
                                    $"Araç Kiralama Tarihi: {updatedRental.RentDate}\n" +
                                    $"Araç Teslim Tarihi: {updatedRental.ReturnDate}\n");

                    Console.WriteLine("Araç Kiralama Müşteri Id: ");
                    updatedRental.CustomerId = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Araç Kiralama Tarihi: ");
                    updatedRental.RentDate = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine("Araç Teslim Tarihi: ");
                    updatedRental.ReturnDate = Convert.ToDateTime(Console.ReadLine());


                    if (!rentalManager.Update(updatedRental).Success)
                    {
                        Console.WriteLine("\nAraç Kiralama güncelleme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Araç Kiralama güncelleme işlemi tamamlandı...\n");
                    break;
                case 3:
                    Console.WriteLine("Araç Kiralama silme işlemi yapılıyor...\n");
                    Console.WriteLine("Silmek istenilen araç kiralama id giriniz : ");

                    int deletedId = Convert.ToInt32(Console.ReadLine());
                    Rental deletedRental = rentalManager.Get(co => co.Id == deletedId).Data;
                    Console.WriteLine("Silinmek istenen Araç Kiralama Bilgileri : \n" +
                                    $"id: {deletedRental.Id}\n" +
                                    $"Müşteri Id: {deletedRental.CustomerId}\n" +
                                    $"Araç Kiralama Tarihi: {deletedRental.RentDate}\n" +
                                    $"Araç Teslim Tarihi: {deletedRental.ReturnDate}\n");

                    if (!rentalManager.Delete(deletedRental).Success)
                    {
                        Console.WriteLine("\nAraç Kiralama silme işlemi tamamlanamadı...\n");
                    }

                    Console.WriteLine("Araç Kiralama silme işlemi tamamlandı...\n");
                    break;
                case 4:
                    Console.WriteLine("Tüm araç kiralama listeleniyor...\n");

                    foreach (var rental in rentalManager.GetAll().Data)
                    {
                        Customer customer = customerManager.Get(c => c.Id == rental.CustomerId).Data;
                        Console.WriteLine($"{rental.Id} - {customer.CompanyName} - {rental.RentDate} - {rental.ReturnDate}");
                    }
                    Console.WriteLine("Tüm araç kiralamalar listelendi...\n");
                    break;
                case 5:
                    Console.WriteLine("Bir araç kiralama getirme işlemi yapılıyor...\n");
                    Console.WriteLine("Görüntülenmek istenilen araç kiralama id giriniz : ");

                    int getId = Convert.ToInt32(Console.ReadLine());
                    Rental getRental = rentalManager.Get(co => co.Id == getId).Data;

                    if (getRental != null)
                    {
                        Customer customer = customerManager.Get(c => c.Id == getRental.CustomerId).Data;
                        Console.WriteLine($"{getRental.Id} - {customer.CompanyName} - {getRental.RentDate} - {getRental.ReturnDate}");
                    }
                    Console.WriteLine("Bir araç kiralama getirme işlemi tamamlandı...\n");
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            Console.WriteLine("Araç Kiralamalar ile işlem yapmak isterseniz (e)\n" +
                "Tablo seçmek isterseniz (h)\n" +
                "Çıkış yapmak için herhangi bir tuşa basabilirsiniz.");

            string devam = Console.ReadLine();

            if (devam == "e")
            {
                RentalProcess(rentals);
            }
            else if (devam == "h")
            {
                TabloSec();
            }
            else
            {
                Environment.Exit(0);
            }
        }

    }
}
