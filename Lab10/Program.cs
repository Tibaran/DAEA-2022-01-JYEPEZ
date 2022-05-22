using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.DrawingCore;
using System.Data;

namespace Lab10
{
    class Program
    {
        private static NorthwndDataContext context = new NorthwndDataContext();

        public static void Main()
        {

            String path_file_name = "F:/proyectosNET/Pictures/sandia.jpg";
            String ext = Path.GetExtension(path_file_name).Replace(".","");
            String file_name = Path.GetFileNameWithoutExtension(path_file_name);
            String file_title = "Sandia";
            Console.WriteLine("ext={0} \t fileName={1} \t path={2}", ext, file_name, path_file_name);
            
            try
            {
                Image ds = Image.FromFile(path_file_name);
                byte[] file_byte = converterDemo(ds);
                System.Data.Linq.Binary binari = new System.Data.Linq.Binary(file_byte);
                //Console.WriteLine(binari.ToString());
                //System.Linq.Binary file_binary = new Linq.Binary(file_byte);
                Categories cte = new Categories();
                cte.CategoryName = "Sandia";
                cte.Description = "Categoria sandia";
                cte.Picture = binari;

                context.Categories.InsertOnSubmit(cte);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                context.SubmitChanges();
            }
            


            Console.ReadKey();
            /*
            Products p = new Products();
            p.ProductName = "Peruvian Coffe";
            p.SupplierID = 20;
            p.CategoryID = 1;
            p.QuantityPerUnit = "10 pkgs";
            p.UnitPrice = 25;

            context.Products.InsertOnSubmit(p);
            context.SubmitChanges();*/
        }
        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public void Consulta()
        {
            var query = from p in context.Products
                        where p.Discontinued == true
                        select p;

            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Name={1}", prod.ProductID, prod.ProductName);
            }
            Console.ReadKey();
        }

    }
}
