Console.WriteLine("Introduzca su nombre");
string nombre = Console.ReadLine().ToLower();
Console.WriteLine("Introduzca su email");
string email = Console.ReadLine();
Console.WriteLine("Si tiene un cupón, pulse 1, en caso contrario, pulse 0");
int aplicaDescuento = Convert.ToInt32(Console.ReadLine());

int precio = 20;
float descuento = 0.25f; 

if  (aplicaDescuento == 1)
{
    Console.WriteLine($"Muy buenas {nombre}, tiene un descuento del {descuento * 100}%, por lo que el precio del producto se queda en {(precio * (descuento * 100) /100)} euros");
}
else if (aplicaDescuento == 0)
{
    Console.WriteLine($"Muy buenas {nombre}, el precio del producto es {precio} euros");
}