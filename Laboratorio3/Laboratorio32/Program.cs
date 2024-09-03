using System;
using Laboratorio31; // Importa el namespace del proyecto Laboratorio31

namespace Laboratorio32
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce el radio del círculo: ");
            double radio = Convert.ToDouble(Console.ReadLine());

            CalculosMatematicos calculos = new CalculosMatematicos();
            double area = calculos.CalculoArea(radio);

            Console.WriteLine($"El área del círculo es: {area}");
        }
    }
}

