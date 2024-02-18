public class Main {
    public static void main(String[] args)
    {
        int result = Suma(1,8,5);
        System.out.println("El resultado es" + result);

        Coche objetoCoche = new Coche();
        objetoCoche.AumentarPuertas();
        System.out.println("Mi coche tiene" + objetoCoche.puertas + "puertas");
    }
    public static int Suma (int a, int b, int c)
    {
        return a+b+c;
    }
}

class Coche{
    int puertas = 5;
    void AumentarPuertas(){
        puertas++;
    }
}