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

            int tablo = int.Parse(Console.ReadLine());

            switch (tablo)
            {
                case 1:
                    ArabaIslem(carManager.GetAll().Data);
                    break;
                case 2:
                    MarkaIslem(brandManager.GetAll().Data);
                    break;
                case 3:
                    RenkIslem(colorManager.GetAll().Data);
                    break;
                default:
                    Console.WriteLine("Bir işlem seçmediniz!!!");
                    break;
            }

            IslemSec();
        }
        public static int IslemSec()
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

        public static void ArabaIslem(List<Car> cars)
        {
            int deger = IslemSec();

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

                    if (!carManager.Insert(addedCar).Success)
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
                ArabaIslem(cars);
            }
            else if (devam == "h")
            {
                TabloSec();
                ArabaIslem(cars);
            }
            else
            {
                Environment.Exit(0);
            }
        }


        public static void MarkaIslem(List<Brand> brands)
        {
            int deger = IslemSec();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Marka ekleme işlemi yapılıyor...\n");
                    Brand addedBrand = new Brand();

                    Console.WriteLine("Marka Adı : ");
                    addedBrand.BrandName = Console.ReadLine();

                    if (!brandManager.Insert(addedBrand).Success)
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
                MarkaIslem(brands);
            }
            else if (devam == "h")
            {
                TabloSec();
                MarkaIslem(brands);
            }
            else
            {
                Environment.Exit(0);
            }
        }


        public static void RenkIslem(List<Color> colors)
        {
            int deger = IslemSec();

            switch (deger)
            {
                case 1:
                    Console.WriteLine("Renk ekleme işlemi yapılıyor...\n");
                    Color addedColor = new Color();

                    Console.WriteLine("Renk Adı : ");
                    addedColor.ColorName = Console.ReadLine();

                    if (!colorManager.Insert(addedColor).Success)
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
                                    $"Marka Adı: {updatedColor.ColorName}\n");

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
                RenkIslem(colors);
            }
            else if (devam == "h")
            {
                TabloSec();
                RenkIslem(colors);
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
