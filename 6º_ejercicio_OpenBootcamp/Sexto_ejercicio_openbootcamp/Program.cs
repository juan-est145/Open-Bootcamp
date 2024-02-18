using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sexto_ejercicio_openbootcamp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca su nombre y apellidos");
            string nombreCompleto = Console.ReadLine();
            Console.WriteLine("Introduzca su edad");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Si sabe programar escriba true, de lo contrario, escriba false");
            string programa = Console.ReadLine();
            string resultado = programa.ToLower();
            if (resultado == "true")
            {
                resultado = "sabe programar";
            }
            else
            {
                resultado = "no sabe programar";
            }

            Console.WriteLine($"Su nombre es {nombreCompleto}, tiene {edad} años y {resultado}");
            Console.ReadKey();
        }
    }

    class Coche
    {
        int nPuertas = 5;
        bool ruedasInfladas = true;
        string marca = "SEAT";
        bool iTVVigente = true;
    }

    class Mesa
    {
        float peso = 20.5f;
        float largo = 5.12f;
        string material = "Plástico";
        string color = "Blanco";
    }
}
