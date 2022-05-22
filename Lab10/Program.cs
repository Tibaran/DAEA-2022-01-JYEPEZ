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
                        where p.ProductName.StartsWith("A")
                        select p;

            foreach (var prod in query)
            {
                Console.WriteLine("Name={0} \t Price={1}", prod.ProductName, prod.UnitPrice);
            }
            Console.ReadKey();
        }

    }
}
