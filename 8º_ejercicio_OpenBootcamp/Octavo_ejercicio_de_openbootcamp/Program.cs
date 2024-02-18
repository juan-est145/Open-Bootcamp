Console.WriteLine("Introduzca un número del 1 al 10");
int multiplicando = Convert.ToInt32(Console.ReadLine());
int multiplicador = 1;
while (multiplicador <= 10)
{
    Console.WriteLine($"{multiplicando} x {multiplicador} = {multiplicando*multiplicador}");
    multiplicador++; 
}