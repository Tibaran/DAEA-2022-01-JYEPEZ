using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;


namespace Lab11_A
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Products;

                IQueryable<string> productNames = from p in products
                                                  select p.Name;
                Console.WriteLine("Productos:");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadKey();
            }
            */

            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Products;

                IQueryable<string> productNames = products.Select(p => p.Name);
                Console.WriteLine("Productos:");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Products;

                IQueryable<Product> productsQuery = from p in products
                                                  select p;
                IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");

                Console.WriteLine("Productos de tamaño 'L':");
                foreach (var product in largeProducts)
                {
                    Console.WriteLine(product.Name);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<Product> productsQuery = from product in context.Products
                                                    select product;
                Console.WriteLine("(4)Productos:");
                foreach (var product in productsQuery)
                {
                    Console.WriteLine(product.Name);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var query = from product in context.Products
                            select new
                            {
                                ProductId = product.ProductID,
                                ProductName = product.Name
                            };
                Console.WriteLine("Informacion de productos:");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product ID: {0} Product name: {1}", productInfo.ProductId, productInfo.ProductName);
                }
                Console.ReadKey();
            }
            */

            /*
            decimal totalDue = 500.00M;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var contacts = context.People;
                var orders = context.SalesOrderHeaders;

                var query = from contact in contacts
                            from order in orders
                            where contact.BusinessEntityID == order.CustomerID && order.TotalDue < totalDue
                            select new
                            {
                                ContactID = contact.BusinessEntityID,
                                LastName = contact.LastName,
                                FirstName = contact.FirstName,
                                OrderId = order.SalesOrderID,
                                Total = order.TotalDue
                            };
                foreach (var smallOrder in query)
                {
                    Console.WriteLine("Contact ID: {0} \t Name: {1}, {2} \t Order ID: {3} " +
                        "\tTotal Due: ${4}", smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName, smallOrder.OrderId, smallOrder.Total);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var contacts = context.People;
                var orders = context.SalesOrderHeaders;

                var query = from contact in contacts
                            from order in orders
                            where contact.BusinessEntityID == order.CustomerID && order.OrderDate >= new DateTime(2002, 10, 1)
                            select new
                            {
                                ContactID = contact.BusinessEntityID,
                                LastName = contact.LastName,
                                FirstName = contact.FirstName,
                                OrderId = order.SalesOrderID,
                                OrderDate = order.OrderDate
                            };
                foreach (var smallOrder in query)
                {
                    Console.WriteLine("Contact ID: {0} \t Order ID: {3} " +
                        "\tTotal Due: ${4}",
                        smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName, smallOrder.OrderId, smallOrder.OrderDate);
                }
                Console.ReadKey();
            }
            */
            /*
            int orderQtyMin = 2;
            int orderQtyMax = 6;
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var query = from order in context.SalesOrderDetails
                            where order.OrderQty > orderQtyMin
                            && order.OrderQty < orderQtyMax
                            select new
                            {
                                SalesOrderID = order.SalesOrderID,
                                OrderQty = order.OrderQty
                            };
                foreach (var order in query)
                {
                    Console.WriteLine("Order ID: {0} Order quantity: {1}", order.SalesOrderID, order.OrderQty);
                }
                Console.ReadKey();
            }
            */
            /*
            String color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var query = from product in context.Products
                            where product.Color == color
                            select new
                            {
                                Name = product.Name,
                                ProductNumber = product.ProductNumber,
                                ListPrice = product.ListPrice
                            };
                foreach (var product in query)
                {
                    Console.WriteLine("Name: {0}", product.Name);
                    Console.WriteLine("Product number: {0}", product.ProductNumber);
                    Console.WriteLine("List Price: {0}", product.ListPrice);
                    Console.WriteLine("");
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int?[] productModelIds = { 19, 26, 118};
                var products = from p in AWEntities.Products
                               where productModelIds.Contains(p.ProductModelID)
                               select p;
                foreach(var product in products)
                {
                    Console.WriteLine("{0}: {1}", product.ProductModelID, product.ProductID);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<Person> sortedNames = from n in context.People
                                                 orderby n.LastName
                                                 select n;
                Console.WriteLine("Lista ordenada por apellido:");
                foreach (Person n in sortedNames)
                {
                    Console.WriteLine(n.LastName);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<Decimal> sortedPrices = from p in context.Products
                                                   orderby p.ListPrice descending
                                                   select p.ListPrice;

                Console.WriteLine("Lista de precios desde el mas alto al mas bajo:");
                foreach (Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                IQueryable<Person> sortedContacts = from contact in context.People
                                                    orderby contact.LastName, contact.FirstName
                                                    select contact;
                Console.WriteLine("Contactos ordenados por apellido luego por nombre:");
                foreach(Person sortedContact in sortedContacts)
                {
                    Console.WriteLine(sortedContact.LastName + ", " +
                        sortedContact.FirstName);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var products = context.Products;
                var query = from product in products
                            group product by product.Style into g
                            select new
                            {
                                Style = g.Key,
                                AverageListPrice = g.Average(product => product.ListPrice)
                            };
                foreach(var product in query)
                {
                    Console.WriteLine("Estilo: {0} Precio promedio: {1}",
                        product.Style, product.AverageListPrice);
                }
                Console.ReadKey();
            }
            */
            /*
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var products = context.Products;
                var query = from product in products
                            group product by product.Color into g
                            select new
                            {
                                Color = g.Key,
                                ProductCount = g.Count()
                            };
                foreach (var product in query)
                {
                    Console.WriteLine("Color: {0} Cantidad: {1}",
                        product.Color, product.ProductCount);
                }
                Console.ReadKey();
            }
            */
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {

                var orders = context.SalesOrderHeaders;
                var query = from order in orders
                            group order by order.Customer.CustomerID into g
                            select new
                            {
                                Category = g.Key,
                                maxTotalDue = g.Max(order => order.TotalDue)
                            };
                foreach (var order in query)
                {
                    Console.WriteLine("ContactID = {0} \t TotalDue maximo = {1}",
                        order.Category, order.maxTotalDue);
                }
                Console.ReadKey();
            }
        }
    }
}
