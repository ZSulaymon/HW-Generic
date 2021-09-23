using System;
using System.Collections.Generic;

namespace HW_Generic
{
    class ArrayHelper
    {

        static void Main(string[] args)
        {
            string[] array = new string[5] { "one", "two", "three", "four", "five" };

            string pushElement = "twenty";

            string UnShiftElement = "null";


            Console.WriteLine();
            var loop = true;
            while (loop)
            {
                Console.WriteLine("Array: ");
                Console.WriteLine("\n");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]}  |  ");
                }
                Console.WriteLine("\n");
                Console.WriteLine($"Push element = {pushElement}");
                Console.WriteLine("\n");
                Console.WriteLine($"UnShift element = {UnShiftElement}");
                Console.WriteLine("\n");
                Console.Write("Select the desired method:\n" +
                    "\n1. Pop - deletes the last array element and returns it;" +
                    "\n2. Push - adds an array element from the end and returns the updated array size;" +
                    "\n3. Shift - deletes the first array element and returns it;" +
                    "\n4. Unshift - adds an array element from the beginning and returns the updated array size;" +
                    "\n5. Slice - returns a new array that contains a part of the previous array;" +
                    "\n6. Slice without begin index;" +
                    "\nChoice: ");
                int.TryParse(Console.ReadLine(), out var choice);
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        var lastElement = ArrayHelper.Pop(ref array);
                        Console.WriteLine($"Deleted last element = {lastElement}");
                        break;

                    case 2:
                        var pushArraySize = ArrayHelper.Push(ref array, pushElement);
                        Console.WriteLine($"New array size = {pushArraySize}");
                        break;

                    case 3:
                        var firstElement = ArrayHelper.Shift(ref array);
                        Console.WriteLine($"Deleted first element = {firstElement}");
                        break;

                    case 4:
                        var UnShiftArraySize = ArrayHelper.UnShift(ref array, UnShiftElement);
                        Console.WriteLine($"New array size = {UnShiftArraySize}");
                        break;

                    case 5:
                        Console.WriteLine("Enter a begin index: ");
                        var beginIndex = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter an end index: ");
                        var endIndex = int.Parse(Console.ReadLine());
                        var sliceArray = ArrayHelper.Slice(array, beginIndex, endIndex);
                        Console.WriteLine();
                        for (int i = 0; i < sliceArray.Length; i++)
                        {
                            Console.WriteLine(sliceArray[i]);
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter an end index: ");
                        var endIndex2 = int.Parse(Console.ReadLine());
                        var sliceArray2 = ArrayHelper.Slice(array, endIndex2);
                        Console.WriteLine();
                        for (int i = 0; i < sliceArray2.Length; i++)
                        {
                            Console.WriteLine(sliceArray2[i]);
                        }
                        break;

                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }

        }
        public static T Pop<T>(ref T[] array)
        {
            T lastElement = default(T);
            try
            {
                var lastElementEx = array[array.Length - 1];
                List<T> list = new List<T>(array);
                Array.Resize<T>(ref array, array.Length - 1);
                lastElement = lastElementEx;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return lastElement;



        }

        public static int Push<T>(ref T[] array, T elementFromTheEnd)
        {
            Array.Resize<T>(ref array, array.Length + 1);
            array[array.Length - 1] = elementFromTheEnd;
            return array.Length;

        }

        public static T Shift<T>(ref T[] array)
        {
            T firstElement = default(T);
            try
            {
                T firstElementEx = array[0];
                List<T> list = new List<T>(array);
                list.RemoveAt(0);
                array = list.ToArray();
                firstElement = firstElementEx;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return firstElement;
        }

        public static int UnShift<T>(ref T[] array, T elementFromTheBeginning)
        {
            List<T> list = new List<T>(array);
            list.Reverse();
            list.Add(elementFromTheBeginning);
            list.Reverse();
            array = list.ToArray();
            return array.Length;
        }

        public static T[] Slice<T>(T[] array, int beginArray, int endArray)
        {
            T[] tempArray = new T[0];
            if (beginArray >= (array.Length) - 1)
            {
                T[] newArray = new T[array.Length];
                for (int i = 0; i < newArray.Length; i++)
                {
                    newArray[i] = default(T);
                }
                tempArray = newArray;
            }

            if (endArray < 0 && beginArray < 0)
            {
                Console.WriteLine("At least one of the index must be >= 0");
                Console.ReadKey();
            }

            if (beginArray < (-1 * array.Length))
            {
                Console.WriteLine("Negative begin index must not be lower than (-)length of array");
                Console.ReadKey();
            }

            if (endArray > array.Length - 1)
            {
                Console.WriteLine("End index must not be greater than array length");
                Console.ReadKey();
            }
            if (beginArray < 0 && beginArray >= (-1 * array.Length) && endArray >= 0)
            {
                T[] newArray = new T[-1 * beginArray];
                Array.Copy(array, (array.Length + beginArray), newArray, 0, (-1 * beginArray));
                tempArray = newArray;
            }

            if (endArray < 0 && beginArray < array.Length - 1 && beginArray >= 0)
            {
                T[] newArray = new T[array.Length + (endArray - beginArray)];
                Array.Copy(array, beginArray, newArray, 0, newArray.Length);
                tempArray = newArray;
            }


            if (beginArray < (array.Length - 1) && beginArray >= 0 && endArray <= (array.Length - 1) && endArray >= 0)
            {
                T[] newArray = new T[(endArray + 1) - beginArray];
                Array.Copy(array, beginArray, newArray, 0, newArray.Length);
                tempArray = newArray;
            }
            return tempArray;
        }

        public static T[] Slice<T>(T[] array, int endArray)
        {
            T[] newArray = new T[endArray + 1];
            Array.Copy(array, 0, newArray, 0, endArray + 1);
            return newArray;
        }

        public static void ShowArray<T>(ref T[] array)
        {
            Console.WriteLine("Elements of the array: \n");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}  |  ");
            }
        }
    }
}
