Cliente primerCliente = new Cliente("Arturo Romero Calderón", 569213547, "Calle del peral nº 98", "arturoromero@gmail.com", true);
Metodo.DatosDeClientes(primerCliente);

public struct Cliente
{
    public Cliente(string nombre, int telefono, string direccion, string email, bool clienteNuevo)
    {
        Nombre = nombre;
        Telefono = telefono;
        Direccion = direccion;
        Email = email;
        ClienteNuevo = clienteNuevo;
    }

    public string Nombre { get; set; }
    public int Telefono { get; set; }
    public string Direccion { get; set; }
    public string Email { get; set; }
    public bool ClienteNuevo { get; set; }
}
class Metodo
{
    public static void DatosDeClientes(Cliente cliente)
    {
        Console.WriteLine(cliente.Nombre);
        Console.WriteLine(cliente.Telefono);
        Console.WriteLine(cliente.Direccion);
        Console.WriteLine(cliente.Email);
        Console.WriteLine(cliente.ClienteNuevo);
    }
}