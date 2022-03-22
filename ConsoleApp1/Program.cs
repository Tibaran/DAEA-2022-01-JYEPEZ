﻿using System;
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
