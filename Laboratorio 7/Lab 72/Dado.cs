using System;

class Dado
{
    private int valor;
    private static Random aleatorio = new Random();  // Se inicializa una sola vez para evitar valores repetidos

    public void Tirar()
    {
        valor = aleatorio.Next(1, 7);  // Genera un número aleatorio entre 1 y 6
    }

    public void Imprimir()
    {
        Console.WriteLine("El valor del dado es: " + valor);
    }

    public int RetornarValor()
    {
        return valor;
    }
}
