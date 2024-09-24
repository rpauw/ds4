using System;
using Laboratorio31; // Importa el namespace del proyecto Laboratorio31

namespace Laboratorio33
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce el primer lado del rectángulo: ");
            int lado1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce el segundo lado del rectángulo: ");
            int lado2 = Convert.ToInt32(Console.ReadLine());

            CalculosMatematicos calculos = new CalculosMatematicos();
            int perimetro = calculos.CalcularPerimetroRectangulo(lado1, lado2);

            Console.WriteLine($"El perímetro del rectángulo es: {perimetro}");
        }
    }
}