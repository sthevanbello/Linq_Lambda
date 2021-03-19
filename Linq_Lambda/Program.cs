using System;
using System.Linq;
using Linq_Lambda.Entities;
using System.Collections.Generic;

namespace Linq_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {

            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 3 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };


            List<Product> products = new List<Product>()
            {
                new Product() {Id = 1, Name = "Computer",Price = 1100, Category = c2 },
                new Product() {Id = 2, Name = "Hammer",Price = 90, Category = c1 },
                new Product() {Id = 3, Name = "Television",Price = 1700, Category = c3 },
                new Product() {Id = 4, Name = "Notebook",Price = 1300, Category = c2 },
                new Product() {Id = 5, Name = "Ripper",Price = 80, Category = c1 },
                new Product() {Id = 6, Name = "Tablet",Price = 700, Category = c2 },
                new Product() {Id = 7, Name = "Camera",Price = 700, Category = c3 },
                new Product() {Id = 8, Name = "Printer",Price = 350, Category = c3 },
                new Product() {Id = 9, Name = "Macbook",Price = 1800, Category = c2 },
                new Product() {Id = 10, Name = "Sound Bar",Price = 700, Category = c3 },
                new Product() {Id = 11, Name = "Level",Price = 70.0, Category = c1 }

            };

            //var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);
            var r1 = from p in products where p.Category.Tier == 1 && p.Price < 900 select p;

            //var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            var r2 = from p in products where p.Category.Name == "Tools" select p.Name;

            //var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name }); ;
            var r3 = from p in products where p.Name[0] == 'C' select new { p.Name, p.Price, CategoryName = p.Category.Name };

            //var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            var r4 = from p in products where p.Category.Tier == 1 orderby p.Name orderby p.Price select p;

            //var r5 = r4.Skip(2).Take(4);
            var r5 = (from p in r4 select p).Skip(2).Take(4);

            //var r6 = products.First();
            var r6 = (from p in products select p).First();

            //var r7 = products.Where(p => p.Price > 3000).FirstOrDefault();
            var r7 = (from p in products where p.Price > 3000 select p).FirstOrDefault();

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();

            var r9 = products.Where(p => p.Id == 30).SingleOrDefault();

            var r10 = products.Max(p => p.Price);

            var r11 = products.Min(p => p.Price);

            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);

            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);

            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();

            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);

            //var r16 = products.GroupBy(p => p.Category);
            var r16 = from p in products group p by p.Category;


            Print("ALL PRODUCTS", products);
            Print("TIER 1 AND PRICE < 900", r1);
            Print("NAMES OF PRODUCTS - CATEGORY TOOLS", r2);
            Print("NAMES OF PRODUCTS - INITIALIZING WITH C", r3);
            Print("TIER 1 ORDER BY PRICE THEN NAME", r4);
            Print("TIER 1 ORDER BY PRICE THEN NAME Skip 2 Take 4", r5);
            Console.WriteLine("First test1: \n" + r6);
            Console.WriteLine("First test2 FirstOrDefault: \n" + r7 + " -\n");
            //Console.WriteLine($"Single or Default Test2: \n{r9}");
            //Console.WriteLine($"Max value per Price: \n{r10}");
            //Console.WriteLine($"Min value per Price: \n{r11}");
            //Console.WriteLine($"Sum of the prices of products of Category 1: {r12}");
            //Console.WriteLine($"Average of the prices of products of Category 1: {r13}");
            //Console.WriteLine($"Average of the prices of products of Category 5: {r14}");
            //Console.WriteLine($"Agregate Sum of products of category 1: {r15}");

            foreach (IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine($"\n{group.Key.Id}    \t{group.Key.Name}    \t{group.Key.Tier}\n");

                foreach (var product in group)
                {
                    Console.WriteLine($"{product}");
                }
            }


            Console.ReadKey();
        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine($"\t{message}\n");

            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
