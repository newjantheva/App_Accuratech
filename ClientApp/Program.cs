﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        public static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:44333/");


            ListAllMenus();
            //ListAllProducts();
            //ListProduct(1);
            //ListProducts("toys");

            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }

        static void ListAllMenus()
        {
            HttpResponseMessage resp = client.GetAsync("api/menus").Result;
            resp.EnsureSuccessStatusCode();

            var menus = resp.Content.ReadAsAsync<IEnumerable<MenuItemEntity>>().Result;
            foreach (var m in menus)
            {
                Console.WriteLine("{0} {1} {2}", m.ID, m.Title, m.Description);
            }
        }

        static void ListAllProducts()
        {
            HttpResponseMessage resp = client.GetAsync("api/products").Result;
            resp.EnsureSuccessStatusCode();

            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            foreach (var p in products)
            {
                Console.WriteLine("{0} {1} {2} ({3})", p.Id, p.Name, p.Price, p.Category);
            }
        }

        static void ListProduct(int id)
        {
            var resp = client.GetAsync(string.Format("api/products/{0}", id)).Result;
            resp.EnsureSuccessStatusCode();

            var product = resp.Content.ReadAsAsync<Product>().Result;
            Console.WriteLine("ID {0}: {1}", id, product.Name);
        }

        static void ListProducts(string category)
        {
            Console.WriteLine("Products in '{0}':", category);

            string query = string.Format("api/products?category={0}", category);

            var resp = client.GetAsync(query).Result;
            resp.EnsureSuccessStatusCode();

            var products = resp.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}
