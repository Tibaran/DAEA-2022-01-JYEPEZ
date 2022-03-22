using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int Suma(int a, int b)
        {
            return a + b;
        }
        static void Raiz()
        {
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine("La raiz cuadrada de {0} es :{1}", i, Math.Sqrt(i));
            }
        }
        static int Resta(int a, int b)
        {
            return a - b;
        }
        static double Multiplicacion(int a, int b)
        {
            return a * b;
        }
        static double Division(int a , int b)
        {
            return a / b;
        }
        //Imprime lso 10 primeros numeros primos
        static void Primos()
        {
            // cont es un contador para que el bucle se detenga cuando encuentre los 10 primeros
            for(int numero = 0,cont = 0; cont < 10; numero++)
            {
                if (esPrimo(numero))
                {
                     Console.WriteLine("El numero {0} es Primo", numero);
                     cont++;
                }
            }
        }
        //Funcion que verifica si el numero es primo o no
        static Boolean esPrimo(int numero)
        {
            if (numero == 0 || numero == 1 || numero == 4)
            {
                return false;
            }

            for(int x = 2; x < numero / 2; x++)
            {
                if (numero % x == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static void FahToCel(double f)
        {
            double convertido = (5 * (f - 32))/9;
            Console.WriteLine("{0} grados Fahrenheit equivale a {1} grados celcius", f, convertido);
        }
        static void CelToFal(double c)
        {
            double convertido = ((9*c)/5) + 32;
            Console.WriteLine("{0} grados celcius equivale a {1} grados Fahrenheit", c, convertido);
        }

        static void Main(string[] args)
        {
            Console.Title = "Procedimientos y funciones";
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Suma de dos numeros");
                Console.WriteLine("[2] Imprimir la raiz cuadrada de los 10 primeros numeros");
                Console.WriteLine("[3] Resta de dos numeros");
                Console.WriteLine("[4] Multiplicacion de dos numeros");
                Console.WriteLine("[5] Division de dos numeros");
                Console.WriteLine("[6] Imprimir los 10 primeros numeros primos");
                Console.WriteLine("[7] Convertir de Celsius a Farhenheit");
                Console.WriteLine("[8] Convertir de Farhenheit a Celsius");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("Ingrese una opcion y presione ENTER");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    
                    case "1":
                        Console.WriteLine("Ingrese el primer numero");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La suma de {0} y {1} es {2}", a, b, Suma(a, b));

                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("Calculando...");
                        Raiz();
                        Console.ReadKey();

                        break;
                    case "3":
                        Console.WriteLine("Ingrese el primer numero");
                        int c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int d = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La resta de {0} y {1} es {2}", c, d, Resta(c,d));

                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el primer numero");
                        int e = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int f = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("La multiplicacion de {0} y {1} es {2}", e, f, Multiplicacion(e, f));

                        Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine("Ingrese el primer numero");
                        int g = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el segundo numero");
                        int h = Convert.ToInt32(Console.ReadLine());
                        if(h == 0)
                        {
                            Console.WriteLine("Error, no se puede dividir por 0");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("La division de {0} y {1} es {2}", g, h, Division(g, h));

                        Console.ReadKey();
                        break;
                    case "6":
                        Console.WriteLine("Calculando...");
                        Primos();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.WriteLine("Ingrese los grados celsius");
                        double cel = Convert.ToDouble(Console.ReadLine());
                        CelToFal(cel);

                        Console.ReadKey();
                        break;
                    case "8":
                        Console.WriteLine("Ingrese los grados Farhenheit");
                        double far = Convert.ToDouble(Console.ReadLine());
                        FahToCel(far);

                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            } while (!opcion.Equals("0"));
            /*Console.WriteLine("PROGRAMA LAB01");
            Raiz();
            Console.ReadKey();*/
        }
    }
}
