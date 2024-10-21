using System;

namespace Laboratorio31
{
    public class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
         public double CalculoArea(double radio)
    {
        return Math.PI * Math.Pow(radio, 2);
    }
        public int CalcularPerimetroRectangulo(int lado1, int lado2)
        {
            return 2 * (lado1 + lado2);
        }

    }

   

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce el primer número: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduce el segundo número: ");
            int b = Convert.ToInt32(Console.ReadLine());

            CalculosMatematicos calculos = new CalculosMatematicos();
            int resultado = calculos.Calcular(a, b);

            Console.WriteLine($"El resultado de (a+b)*(a-b) es {0}: ",resultado);
        }
    }
}


