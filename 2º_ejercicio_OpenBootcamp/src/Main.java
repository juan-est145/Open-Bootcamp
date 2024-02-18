public class Main {
    public static void main(String[] args)
    {
        NumeroIf(6);
        NumeroWhile(0);
        NumeroDoWhile(3);
        NumeroFor(2);
        Estación("Verano");
    }
     protected static void NumeroIf(int numeroIf)
    {
        if (numeroIf > 0)
        {
            System.out.println("El númeroif " + numeroIf + " es positivo");
        }
        else if (numeroIf == 0)
        {
            System.out.println("El númeroif " + numeroIf + " es cero");
        }
        else
        {
            System.out.println("El númeroif " + numeroIf + " es negativo");
        }
    }
    protected static void NumeroWhile(int numeroWhile)
    {
       while (numeroWhile < 3)
       {
           numeroWhile++;
           System.out.println("El númeroWhile es " + numeroWhile);

       }
    }
    protected  static void NumeroDoWhile(int numeroDoWhile)
    {
        do
        {
            numeroDoWhile++;
            System.out.println("El númeroDoWhile es " + numeroDoWhile);
        }
        while(numeroDoWhile < 3);
    }
    protected static void NumeroFor(int numeroFor)
    {
        for(; numeroFor <= 3; numeroFor++)
        {
            System.out.println("El númeroFor es " + numeroFor);
        }
    }
    protected static void Estación(String tipoDeEstación)
    {
        switch (tipoDeEstación)
        {
            case "Verano":
                    System.out.println("Es verano,bebe mucha agua");
                    break;
            case "Invierno":
                    System.out.println("Es invierno,toma chocolate caliente");
                    break;
            case "Otoño":
                    System.out.println("Es otoño, quédate en casa con una serie");
                    break;
            case "Primavera":
                System.out.println("Es primavera, cuidado con la alergia");
                    break;
            default:
                System.out.println(tipoDeEstación + " no es una estación");
                    break;

        }
    }
}