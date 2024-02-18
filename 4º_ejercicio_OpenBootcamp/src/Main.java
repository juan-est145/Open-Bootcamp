import java.lang.invoke.VarHandle;

public class Main {
    public static void main(String[] args) {
        Cliente cliente = new Cliente();
        Trabajador trabajador = new Trabajador();

        cliente.edad = 45;
        cliente.telefono = 489623577;
        cliente.nombre = "María";
        cliente.credito = 12000.37f;

        System.out.println("El cliente tiene " + cliente.edad + " años, su número de teléfono es " + cliente.telefono + ", su nombre es " + cliente.nombre + " y su credito es " + cliente.credito);

        trabajador.edad = 30;
        trabajador.telefono = 459698238;
        trabajador.nombre = "Luisa";
        trabajador.salario = 1689;

        System.out.println("El trabajador tiene " + trabajador.edad + " años, su número de teléfono es " + trabajador.telefono + ", su nombre es " + trabajador.nombre + " y su salario es " + trabajador.salario);

    }
}

    class Persona {
        protected int edad;
        protected String nombre;
        protected int telefono;
    }
    class Cliente extends Persona
    {
        protected float credito;
    }

    class Trabajador extends Persona
    {
        protected float salario;
    }

