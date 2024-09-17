using System;

class Program
{
    static void Main(string[] args) 
    {
        int num;

        Console.WriteLine("Digite el número deseado");

        try
        {
            num = Int16.Parse(Console.ReadLine());
        }
        catch (FormatException ex)
        {
            Console.WriteLine("No ha introducido un dígito válido");
            num = -1;
        }

        Console.WriteLine(num);
    }
}
