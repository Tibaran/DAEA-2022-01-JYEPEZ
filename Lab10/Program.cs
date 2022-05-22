using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        private static NorthwndDataContext context = new NorthwndDataContext();

        public static void Main()
        {
            var query = from p in context.Products
                        where p.QuantityPerUnit.Contains("pkg") || p.QuantityPerUnit.Contains("pkgs")
                        select p;

            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Name={1} \t QuantityPerUnit={2}", prod.ProductID, prod.ProductName, prod.QuantityPerUnit);
            }
            Console.ReadKey();
        }

    }
}
