using System;

class Program
{
    static void Main()
    {
        char[] array = new char[4];
        int count = 0;

        array[count++] = 'A';
        array[count++] = 'B';
        array[count++] = 'C';
        array[count++] = 'D';

        Console.WriteLine("1. Despues de insertar A, B, C, D:");
        PrintArray(array, count);

        if (count == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }
        array[count++] = 'E';

        Console.WriteLine("\n2. Despues de insertar E:");
        PrintArray(array, count);

        for (int i = 1; i < count - 1; i++)
        {
            array[i] = array[i + 1];
        }
        count--;

        Console.WriteLine("\n3. Despues de remover B:");
        PrintArray(array, count);

        if (count == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }
        array[count++] = 'B';

        Console.WriteLine("\n4. Despues de agregar B al final:");
        PrintArray(array, count);
    }

    static void PrintArray(char[] array, int count)
    {
        Console.Write("[");
        for (int i = 0; i < count; i++)
        {
            Console.Write(array[i]);
            if (i < count - 1) Console.Write(", ");
        }
        Console.WriteLine($"] (count: {count}, capacity: {array.Length})");
    }
}