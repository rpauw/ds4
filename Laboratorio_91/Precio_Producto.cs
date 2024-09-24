using System;

class PagoProducto
{
    static void Main(string[] args)
    {
        double precio;
        string formaPago;

        do
        {
            Console.Write("Ingrese el precio del producto (valor positivo): ");
            precio = Convert.ToDouble(Console.ReadLine());
        } while (precio <= 0);

        do
        {
            Console.Write("Ingrese la forma de pago (efectivo o tarjeta): ");
            formaPago = Console.ReadLine().ToLower();
        } while (formaPago != "efectivo" && formaPago != "tarjeta");

        if (formaPago == "tarjeta")
        {
            string numeroCuenta;
            do
            {
                Console.Write("Ingrese el número de cuenta (16 dígitos): ");
                numeroCuenta = Console.ReadLine();
            } while (numeroCuenta.Length != 16 || !long.TryParse(numeroCuenta, out _));

            Console.WriteLine($"El pago se hará con tarjeta, número de cuenta: {numeroCuenta}");
        }
        else
        {
            Console.WriteLine("El pago se hará en efectivo.");
        }
    }
}

