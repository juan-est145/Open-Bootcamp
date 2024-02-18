using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operadores_lógicos
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero = 19;
            char caracter= 'w';

            Console.WriteLine($"¿Es {numero} mayor o igual a 18? {numero >= 18}");
            Console.WriteLine($"¿Es el caracter igual a 'a'? {caracter == 'a'}");
            Console.WriteLine($"¿Se cumplen las dos condiciones anteriores a la vez? {numero >= 18 && caracter == 'a'}");
            Console.WriteLine($"¿Se cumple al menos una de las dos condiciones anteriores? {numero >= 18 || caracter == 'a'}");
            Console.ReadKey();
        }
    }
}
