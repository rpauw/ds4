using System;

class TipoTriangulo
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese el primer lado del triángulo: ");
        double lado1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el segundo lado del triángulo: ");
        double lado2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el tercer lado del triángulo: ");
        double lado3 = Convert.ToDouble(Console.ReadLine());

        if (EsTrianguloValido(lado1, lado2, lado3))
        {
            if (lado1 == lado2 && lado2 == lado3)
            {//Si los 3 lados cumplen con ser iguales
                Console.WriteLine("El triángulo es equilátero.");
            }
            else if (lado1 == lado2 || lado2 == lado3 || lado1 == lado3)
            {//Si 2 lados son iguales y uno diferente
                Console.WriteLine("El triángulo es isósceles.");
            }
            else
            {// Si no cumplen con niguno de los anteriores
                Console.WriteLine("El triángulo es escaleno.");
            }
        }
        else
        {   //Si no se puede formar la figura del triangulo
            Console.WriteLine("Los lados ingresados no forman o completan un triángulo.");
        }
    }

    static bool EsTrianguloValido(double a, double b, double c)
    {
        return (a + b > c) && (a + c > b) && (b + c > a);
    }
}
