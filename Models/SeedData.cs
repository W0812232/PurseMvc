using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PurseMvc.Data;
using System;
using System.Linq;

namespace PurseMvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PurseMvcContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PurseMvcContext>>()))
            {
                // Look for any movies.
                if (context.Purse.Any())
                {
                    return;   // DB has been seeded
                }

                context.Purse.AddRange(
                    new Purse
                    {
                        Product = "Squire Bag",
                        Style = "Shoulder Bag",
                        Price = 3700.00M,
                        Color = "Bruciato",
                        Material = "Calf suede/Calf leather",
                        ReleaseDate = DateTime.Parse("2023-3-30"),
                        CustomerReview = 5
                    },
                    

                    new Purse
                    {
                        Product = "Moon Kissed Bag",
                        Style = "Backpack",
                        Price = 3250.00M,
                        Color = "Black",
                        Material = "Fabric/Leather",
                        ReleaseDate = DateTime.Parse("2020-12-25"),
                        CustomerReview = 5
                    },
                    new Purse
                    {
                        Product = "Serpents Fourtune",
                        Style = "Mini-bag",
                        Price = 3300.00M,
                        Color = "Platinum",
                        Material = "Lambskin/Calf Leather/Cotton",
                        ReleaseDate = DateTime.Parse("2021-04-15"),
                        CustomerReview = 2
                    },
                    new Purse
                    {
                        Product = "Alaric 1555",
                        Style = "Shoulder Bag",
                        Price = 7090.00M,
                        Color = "White and Black",
                        Material = "Soft leather",
                        ReleaseDate = DateTime.Parse("2023-01-18"),
                        CustomerReview = 4
                    },
                    new Purse
                    {
                        Product = "Gracies Goblet with Crystals",
                        Style = "Pouch",
                        Price = 3855.00M,
                        Color = "Black",
                        Material = "Black leather",
                        ReleaseDate = DateTime.Parse("2021-11-17"),
                        CustomerReview = 4
                    },
                    new Purse
                    {
                        Product = "Pola's Decadent Mini Bag",
                        Style = "Mini-bag",
                        Price = 6500.00M,
                        Color = "Pale pink",
                        Material = "Bio-based materials/Calf Leather",
                        ReleaseDate = DateTime.Parse("2022-08-10"),
                        CustomerReview = 3
                    },
                    new Purse
                    {
                        Product = "Witch Walking Pouch",
                        Style = "Pouch",
                        Price = 2380.00M,
                        Color = "White and Brown",
                        Material = "Calf skin",
                        ReleaseDate = DateTime.Parse("2019-12-31"),
                        CustomerReview = 4
                    },
                    new Purse
                    {
                        Product = "Sir Bartholomew's trusty Shoulder Bag",
                        Style = "Shoulder Bag",
                        Price = 1750.00M,
                        Color = "Blue/Gold/Red",
                        Material = "Lambskin/Calf Leather/Cotton",
                        ReleaseDate = DateTime.Parse("2019-11-03"),
                        CustomerReview = 5
                    },
                    new Purse
                    {
                        Product = "A+ Frame Turbo",
                        Style = "Bucket Bag",
                        Price = 5600.00M,
                        Color = "Black/Brown",
                        Material = "Faux fur/ Calf leather",
                        ReleaseDate = DateTime.Parse("2020-09-10"),
                        CustomerReview = 1
                    } 
                );
                context.SaveChanges();
            }
        }
    }
}