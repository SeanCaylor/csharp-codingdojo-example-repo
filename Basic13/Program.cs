using System;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] oddNums = OddArray();
            Console.WriteLine(String.Join(", ", oddNums));

            object[] numsAndWords = NumToString(new int[5] { 1, -10, 5, 6, -2 });
            Console.WriteLine(String.Join(", ", numsAndWords));
        }

        public static int[] OddArray()
        {
            // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
            // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].

            // dividing two ints will never give you a decimal, so we need to cast
            // one int at least into a double or decimal to keep the decimal so we
            // can then ceiling it.
            double halfLen = 255 / (double)2;
            int len = (int)Math.Ceiling(halfLen);
            int[] oddNums = new int[len];

            int i = 0;
            for (int oddNum = 1; oddNum <= 255; oddNum += 2)
            {
                oddNums[i] = oddNum;
                i++;
            }

            return oddNums;
        }

        public static object[] NumToString(int[] numbers)
        {
            // Write a function that takes an integer array and returns an object array 
            // that replaces any negative number with the string 'Dojo'.
            // For example, if array "numbers" is initially [-1, -3, 2] 
            // your function should return an array with values ['Dojo', 'Dojo', 2].

            object[] numsAndWords = new object[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numsAndWords[i] = numbers[i];

                if (numbers[i] < 0)
                {
                    numsAndWords[i] = "Dojo";
                }
            }
            return numsAndWords;
        }
    }
}
