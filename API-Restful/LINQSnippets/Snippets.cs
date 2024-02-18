using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks.Dataflow;

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
            
            //6. Encontrar el primer elemento que contenga una "J"

                    //Mi propio método (Muy parecido al del vídeo)
                    string textoJ = textList.First(x => x.Contains('j'));

            //7. Encontrar primer elemento que contenga la Z o default

                    //Mi propio método (en este caso, cuando no encuentre el valor que se desea, devolvera una cadena vacía)
                    string? textoZ = textList.First(x => x.Contains('z')).DefaultIfEmpty().ToString();
                    
                    //Método del tutorial (en este caso, cuando no se encuentre el valor que se desea, devolvera un valor null. Este método representa mejores prácticas)
                    var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            //8. Encontrar último elemento que contenga la z o default

                    //Mi propio método
                    string? ultimoZ = textList.LastOrDefault(x => x.Contains('z'));
                    
                    //Método del tutorial
                    var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            //9. Definir un valor único

                    //Mi propio método
                    List <string> textosÚnicos = textList.Distinct().ToList();

                    //Método del tutorial (implementa un método erróneo, este sirve únicamente para obtener el único elemento de una colección genérica. Si se usa en una colección con más de un elemento, genera una excepción.
                    var uniqueTexts = textList.Single();
                    var uniqueOrDefaultTexts = textList.SingleOrDefault();

            //10. Quitar elementos de una matriz

                    //Método del tutorial
                    int[] evenNumbers = { 0, 2, 4, 6, 8 };
                    int[] otherEvenNumbers = { 0, 2, 6, };
                    int[] myEvenNumbers = evenNumbers.Except(otherEvenNumbers).ToArray();
        }

        static public void MultipleSelects()
        {
            string[] opiniones = { "Opinión 1, text1", "Opinión 2, text2", "Opinión 3, text3", "Opinión 4, text4"};

            //11. Select Many

                    //Mi método (casi idéntico al del tutorial)
                    var selectMany = opiniones.SelectMany(x => x.Split(','));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Martín",
                            Email = "martin@gmail.com",
                            Salary = 3000
                        },

                        new Employee
                        {
                            Id = 2,
                            Name = "Miguel",
                            Email = "miguel@gmail.com",
                            Salary = 2500
                        },

                        new Employee
                        {
                            Id = 3,
                            Name = "Marina",
                            Email = "marina@gmail.com",
                            Salary = 6000
                        },
                    }
                },

                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new []
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana@gmail.com",
                            Salary = 5000
                        },

                        new Employee
                        {
                            Id = 5,
                            Name = "Francisco",
                            Email = "francisco@gmail.com",
                            Salary = 1000
                        },

                        new Employee
                        {
                            Id = 6,
                            Name = "Arturo",
                            Email = "Arturo@gmail.com",
                            Salary = 1500
                        },
                    }
                }
            };

            //12. Obtener todos los empleados de todas las empresas

                    //Mi propio método (casi idéntico al del tutorial)
                    var employeeList = enterprises.SelectMany(x => x.Employees);

            //13. Saber si hay una lista vacía

                    //Método del tutorial
                    bool hasEnterprises = enterprises.Any(); //Ver si la lista de empresas está vacía
                    bool hasEmployees = enterprises.Any(enterprises => enterprises.Employees.Any()); //Ver si las empresas tienen empleados

            //14. Saber si al menos todas las empresas tienen un empleado con más de 1.000 euros de salario.

                    //Método del tutorial
                    bool hasEmployeeWithSalaryMoreThan1000 = enterprises.Any(enterprises => enterprises.Employees.Any(employee => employee.Salary > 1000)); //Saldrá false al haber empleados que cobran menos de 1.000
        }

        static public void linqCollections()
        {
            List<string> firstList = new List<string>() { "a", "b", "c" };
            List<string> secondList = new List<string>() { "a", "c", "d" };

            //15. Realizar un Inner Join.

                    //Método del tutorial
                    var commonResult = from element in firstList join secondElement in secondList on element equals secondElement select new { element, secondElement };
                    var commonResult2 = firstList.Join(secondList, x => x, y => y, (x, y) => new { x, y });

            //16. Realizar un Outer Join-Left.

                    //Método del tutorial
                    var leftOuterJoin = from element in firstList
                                        join secondElement in secondList on element equals secondElement into temporalList
                                        from temporalElement
                                        in temporalList.DefaultIfEmpty()
                                        where element != temporalElement
                                        select new { Element = element };
                    
                    var secondLeftOuterJoin = from element in firstList
                                                  from secondElement in secondList.Where(x => x == element).DefaultIfEmpty()
                                                  select new { x = element, y = secondElement };

            //17. Realizar un Outer Join-Right.

                    //Método del tutorial
                    var rightOuterJoin = from secondElement in secondList join firstElement in firstList on secondElement equals firstElement 
                                         into temporalList from temporalElement in temporalList.DefaultIfEmpty() 
                                         where secondElement != temporalElement select new { Element = secondElement };

                    var secondRightOuterJoin = from secondElement in secondList
                                               from element in firstList.Where(x => x == secondElement).DefaultIfEmpty()
                                               select new { x = secondElement, y = element };

            //18. Union
            
                    //Método del tutorial
                    var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {
            List<int> lista = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Skip

                    //Método del tutorial
                    var skipTwoFirstValues = lista.Skip(2); //Se saltará los dos primeros números.

                    //Método del tutorial
                    var skipTwoLasttValues = lista.SkipLast(2); //Se saltará los dos últimos números.

                    //Método del tutorial
                    var skipWhile = lista.SkipWhile(x => x < 4); //Se saltará todos los números menores a 4.

            //Take

                    //Método del tutorial
                    var TakeTwoFirstValue = lista.Take(2); //Tomará solo los dos primeros valores

                    //Método del tutorial
                    var takeTwoLasttValues = lista.TakeLast(2); //Tomará solo los dos últimos números.

                    //Método del tutorial
                    var takeWhile = lista.TakeWhile(x => x < 4); //Tomará solo los números menores a 4.
        }

            //19. Paging  con Skip y Take
        public IEnumerable<T> Getpage<T>(IEnumerable<T> collection, int pageNumber, int resultsPerPage)
        {
            int startIndex = (pageNumber - 1) * resultsPerPage;
            return collection.Skip(startIndex).Take(resultsPerPage);
        }

            //20. Variables
        static public void LinqVariables()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var aboveAverage = from number in numbers let average = numbers.Average() let nSquared = Math.Pow(number, 2) where nSquared > average select number;
        }

            //21. Zip
        static public void ZipLinq()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            string[] stringNumbers = { "One", "Two", "Three", "Four", "Five" };

            IEnumerable<string> zipNumbers = numbers.Zip(stringNumbers, (number, word) => $"{number} = {word}"); //Resultado = 1 = one, 2 = two, 3 = three, etc.
        }

            //22. Repeat and Range
        static public void RepeatRangeLinq()
        {
            //Generar colección de valores del 1 al 1.000
            var first1000 = Enumerable.Range(1, 1000);

            //Repite un valor concreto x número de veces.
            var fiveAs = Enumerable.Repeat("A", 5);
        }

        static public void StudentsLinq()
        {
            var classRoom = new[]
            {
                new Student_Snippets_
                {
                    Id = 1,
                    Name = "Martín",
                    Grade = 90,
                    Certified = true,
                },
                new Student_Snippets_
                {
                    Id = 2,
                    Name = "Juan",
                    Grade = 50,
                    Certified = false,
                },
                new Student_Snippets_
                {
                    Id = 3,
                    Name = "Ana",
                    Grade = 96,
                    Certified = true,
                },
                new Student_Snippets_
                {
                    Id = 4,
                    Name = "Álvaro",
                    Grade = 10,
                    Certified = false,
                },
                new Student_Snippets_
                {
                    Id = 5,
                    Name = "Pedro",
                    Grade = 50,
                    Certified = true,
                },
            };

            var certifiedStudents = from student in classRoom where student.Certified == true select student;
            var notCertiedStudents = from student in classRoom where student.Certified != true select student;
            var approvedStudents = from student in classRoom where student.Grade >= 50 && student.Certified == true select student.Name;

            var certifiedQuery = classRoom.GroupBy(x => x.Certified); //Para agrupar por alumnos certificados o no, obteniendo así dos grupos
        }

            //23. All
        static public void AllLinq()
        {
            var numbers = new List<int>() {1,2,3,4,5};
            bool allAreSmallerThan10 = numbers.All(x => x < 10); //Dará true, porque no hay ningún valor mayor que diez.
            bool allAreBiggerOrEqualThan2 = numbers.All(x => x >= 2); //Dará false, porque está el número 1, que es menor que 2.

            var emptyList = new List<int>();
            bool allNumbersAreGreaterThan0 = numbers.All(x => x >= 0); //Dará true.
        }

            //24. Aggregate
        static public void AggregateQueries()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = numbers.Aggregate((x,y) => x + y);

            string[] words = { "Hello,", "my", "name", "is", "Juan" };
            string greeting = words.Aggregate((x, y) => x + y);
        }

            //25. Distinct values
        static public void Distinct()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };

            int [] DistinctValues = numbers.Distinct().ToArray();
        }

            //26. Group by
        static public void GroupByExamples()
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var grouped = numbers.GroupBy(x => x % 2 == 0);

            //Para iterar por los dos grupos y ver los resultados se haría así
            foreach(var group in grouped)
            {
                foreach(var value in group)
                {
                    Console.WriteLine(value); //1,3,5,7,9,2,4,6,8
                }
            }
        }

        static public void RelationsLinq()
        {
            List<Post> posts = new List<Post>();
            new Post()
            {
                Id = 1,
                Title = "My first post",
                Content = "My first content",
                Created = DateTime.Now,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 1,
                        Created = DateTime.Now,
                        Title = "My first comment",
                        Content = "My content"
                    },
                    new Comment()
                    {
                        Id = 2,
                        Created = DateTime.Now,
                        Title = "My second comment",
                        Content = "My other content"
                    }
                }
            };

            new Post()
            {
                Id = 2,
                Title = "My second post",
                Content = "My second content",
                Created = DateTime.Now,
                Comments = new List<Comment>()
                {
                    new Comment()
                    {
                        Id = 3,
                        Created = DateTime.Now,
                        Title = "My other comment",
                        Content = "My content"
                    },
                    new Comment()
                    {
                        Id = 4,
                        Created = DateTime.Now,
                        Title = "My other new comment",
                        Content = "My other content"
                    }
                }
            };

            var commentsWithContent = posts.SelectMany(x => x.Comments, (x, y) => new {PostId = x.Id, CommentContent = y.Content});
        }
    }
}