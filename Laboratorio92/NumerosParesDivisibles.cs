using System;

class NumerosParesDivisibles
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 100; i++)
        {   //Si el número cumple ambos criterios
            if (i % 2 == 0 && i % 3 == 0)
            {
                Console.WriteLine(i + " es par y divisible entre 3");
            }
            else if (i % 2 == 0)
            {//Si el número cumple el criterio de Par
                Console.WriteLine(i + " es par");
            }
            else if (i % 3 == 0)
            {//Si el número no cumple con ninguna de las anteriores
                Console.WriteLine(i + " es divisible entre 3");
            }
        }
    }
}


