using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int[] mynumber = { 1, 2, 3 };
            Console.WriteLine(mynumber[10]); //no existe el indice 10
        }
        catch (Exception e)
        {
            Console.WriteLine("Algo salio mal. Valide el indice del arreglo");
        }
        finally
        {
            Console.WriteLine("Continuación de la aplicacion, luego del bloque try/catch");
        }
}
}