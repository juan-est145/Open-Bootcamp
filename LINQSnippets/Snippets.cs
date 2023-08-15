using System.Runtime.CompilerServices;
using System.Text;
namespace LINQSnippets
{
    public class Snippets
    {
        static public void BasicLinq()
        {
            string[] cars = { "VW Golf", "VW California", "Audi A3", "Audi A5", "FIAT Punto", "SEAT Ibiza", "SEAT León"};

            //1. Select * of cars

                    //Mi propio método
                    string[] listaDeCoches = cars.Select(x => x).ToArray();

                    //El método del tutorial
                    var carList = from car in cars select car;

            //2. Select Where con Audis
            
                    //Mi propio método
                    string [] audi = cars.Select(x => x).Where(x => x.Contains("Audi")).ToArray();
            
                    //El método del tutorial
                    var audilist = from car in cars where car.Contains("Audi") select car;

            
        }
        
        static public void LinqNumbers()
        {
            //3. Ejemplos con números. Multiplicar cada número por 3 y obtener todos los números menos el 9 y ordenarlos de manera ascendiente.
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                    //Mi propio método (casi idéntico al del tutorial)
                    List<int> operación = numbers.Select(x => x * 3).Where(x => x != 9).OrderBy(x => x).ToList();
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string> {"a", "bx", "c", "d", "e", "cj", "f", "c" };

            //4. Encontrar el primero de los elementos

                    //Mi propio método
                    List <string> resultado = textList.Take(1).ToList();

                    //El método del tutorial
                    var first = textList.First();

            //5. Encontrar el primer elemento que sea "C"

                    //Mi propio método (Este método es erróneo, lo que hará es verificar si el primer elemento de la lista es ese caracter
                    var text = textList.First().StartsWith('c');

                    //Método del tutorial
                    var CText = textList.First(text => text.Equals('C'));
        }
    }
}