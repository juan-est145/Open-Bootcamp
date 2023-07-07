int numeroPositivo = 0;
int numeroNegativo = 0;
do
{
    Console.WriteLine("Introduzca un número entero positivo o negativo (no vale el 0)");
    int input = Convert.ToInt32(Console.ReadLine());

    if (input > 0)
    {
        numeroPositivo++;
    }
    else if (input < 0)
    {

        numeroNegativo++;
    }
    Console.WriteLine($"El total de números positivos introducidos es {numeroPositivo} y de números negativos es {numeroNegativo}");
}
while(numeroPositivo < 5 && numeroNegativo < 5);
