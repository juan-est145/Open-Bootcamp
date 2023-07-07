Console.WriteLine("Introduzca un número entero positivo para el ancho del rectángulo");
int ancho = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Introduzca un número entero positivo para el largo del rectángulo");
int largo = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Escriba si quiere el rectángulo relleno o vacío");
string relleno = Console.ReadLine().ToLower();

if (relleno == "relleno")
    {
    for (int i = 1; i <= largo; i++)
    {
        for (int j = 1; j <= ancho; j++)
        {
            Console.Write('*');
        }
        Console.WriteLine();
    }
}
else if (relleno == "vacío" || relleno == "vacio")
{
    for (int i = 1; i <= largo; i++)
    {
        for (int j = 1; j <= ancho; j++)
        {
            if ((i == 1) || (i == largo) || (j== 1) || (j == ancho))
            {
                Console.Write('*');
            }
            else { Console.Write(" "); }
            
        }
        Console.WriteLine();
    }
}
