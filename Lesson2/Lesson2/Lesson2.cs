using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lesson2;

class Program
{
    static void Main(string[] args)
    {
        // First Task
        int[] numbers = new int[100];
        int count = 0;
        Random random = new Random();
 
        for (int number = 0; number < numbers.Length; number ++)
        {
            
            numbers[number] = random.Next(-200, 200);

            if (numbers[number] >= -100 && numbers[number] <= 100)
            {
                count += 1;
            }

        }
        Console.Write($"Number of elements whose values are in the range -100 to +100 are: {count}");
        Console.WriteLine();

        // Second Task
        int[] array = new int[20];
        int[] array1;
        int count1 = 0;


        Console.WriteLine("Array A:");
        for (int element = 0; element < array.Length; element++)
        {

            array[element] = random.Next(-1000, 1000);
            Console.Write($"{array[element]} ");
            if (array[element] <= 888)
            {
                // Save the number of values that less than or equal to 888
                // into a variable count1
                count1 += 1;

            }

        }

        // count1 variable contains the number of elements that the array will hold
        array1 = new int[count1];
        int index = 0;

        for (int element = 0; element < array.Length; element++)
        {
            if (array[element] <= 888)
            {
                // For each element in array check if it is less than
                // or equal to 888, and if it so, than that element will be
                // included in array1. After this, the array index is increased by 1 
                array1[index] = array[element];
                index++;

            }
        }


        Console.WriteLine();

        Array.Sort(array1);
        Array.Reverse(array1);
        

        Console.WriteLine("Array B:");
        foreach (int element in array1)
        {
            Console.Write($"{element} ");
        }

    }
}

