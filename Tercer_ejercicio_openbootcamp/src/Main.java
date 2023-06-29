public class Main {
    public static void main(String[] args) {
        Persona persona = new Persona();

        persona.SetEdad(24);
        System.out.println(persona.GetEdad());

        persona.SetNombre("Miguel");
        System.out.println(persona.GetNombre());

        persona.SetTeléfono(589621478);
        System.out.println(persona.GetTeléfono());
    }
}

class Persona{
    private int edad;
    private String nombre;
    private int teléfono;

    public void SetEdad(int edad)
    {
        this.edad=edad;
    }
    public String GetEdad()
    {
        return "La edad de persona es " + this.edad;
    }

    public void SetNombre(String nombre)
    {
        this.nombre= nombre;
    }

    public String GetNombre()
    {
        return "El nombre de persona es " + this.nombre;
    }

    public void SetTeléfono(int teléfono)
    {
        this.teléfono=teléfono;
    }

    public String GetTeléfono()
    {
        return "El teléfono de persona es " + this.teléfono;
    }
}