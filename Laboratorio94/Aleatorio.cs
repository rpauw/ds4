using System;


public class Aleatorios
{
    // Atributo Random
    private Random random;

    //Constrictor
    public Aleatorios()
    {
        random = new Random();
    }

    // A. Generar un número aleatorio entre 1 y 100 (por ejemplo)
    public int GenerarNumero()
    {
        // Devuelve un número aleatorio entre 1-100, defino los valores del 1-100
        return random.Next(1, 101);
    }

    // B. Generar un arreglo de números aleatorios entre 1 y 100
    public int[] GenerarArreglo(int tamaño)
    {
        // Creamos el arreglo del tamaño solicitado
        int[] arreglo = new int[tamaño];

        for (int i = 0; i < tamaño; i++)
        {
            // Se Genera un número aleatorio para cada posición del arreglo, defino los valores del 1-100
            arreglo[i] = random.Next(1, 101);
        }

        return arreglo;
    }

    // C. Generar un arreglo de números no repetidos entre 1 y 100
    public int[] GenerarArregloSinRepetidos(int tamaño)
    {
        // HashSet para evitar duplicados
        HashSet<int> numerosNoRepetidos = new HashSet<int>();

        // Evalua que el HashSet alcance el tamaño solicitado
        while (numerosNoRepetidos.Count < tamaño)
        {
            // Genera un número aleatorio entre 1-100
            int numeroAleatorio = random.Next(1, 101);
            // El HashSet solo añade el número si no está anteriormente
            numerosNoRepetidos.Add(numeroAleatorio);
        }

        // Convertir el HashSet a un arreglo y hacer return
        return new List<int>(numerosNoRepetidos).ToArray();
    }
}
