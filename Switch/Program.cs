Console.WriteLine("Si su lenguaje de programación favorito es C#, pulse 1, si prefiere Java, pulse 2, si prefiere Python, pulse 3, si prefiere C++ pulse 4, si prefiere otro pulse 5.");
int lenguajeDeProgramación = Convert.ToInt32(Console.ReadLine());

switch (lenguajeDeProgramación)
{
    case 1:
        Console.WriteLine("Su lenguaje favorito es C#.");
        break;
    case 2:
        Console.WriteLine("Su lenguaje favorito es Java.");
        break;
    case 3:
        Console.WriteLine("Su lenguaje favorito es Python.");
        break;
    case 4:
        Console.WriteLine("Su lenguaje favorito es C++.");
        break;
    default:
        Console.WriteLine("Su lenguaje favorito es otro.");
        break;
}
