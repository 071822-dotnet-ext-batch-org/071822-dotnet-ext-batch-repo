using System;
using System.Collections.Generic;

namespace _8_LoopsChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Your code here */
            object[] array1 = new object[] { 10864.3086,27160.771605,-128,127,0,18107.1811,255,'h',13580.3858,'e','y',-2147483648,"hey",21474836470,4294967295,
            "hey",-9223372036854775808,9053.59053,9223372036854775807,"hey",18446744073709551615,"hey"
            };
            double myDouble = 54321.54321;

            //int result = UseDoWhile(array1, myDouble);
        }

        /// <summary>
        /// Return the number of elements in the List<int> that are odd.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseFor(List<int> x)
        {
            //throw new NotImplementedException("UseFor() is not implemented yet.");

            int totOdds = 0;
            foreach (int y in x)
            {
                if (y % 2 == 1)
                {
                    totOdds++;
                }
            }
            return totOdds;
        }

        /// <summary>
        /// This method counts the even entries from the provided List<object> 
        /// and returns the total number found.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForEach(List<object> x)
        {
            // throw new NotImplementedException("UseForEach() is not implemented yet.");
            int totEvens = 0;
            // check each object to see it it's an int.
            foreach (object y in x)
            {
                if (y is double || y is float || y is sbyte || y is byte || y is short ||
                y is ushort || y is long)
                {
                    if ((long)y % 2 == 0) totEvens++;
                }
                else if (y is int)
                {
                    if ((int)y % 2 == 0) totEvens++;
                }
                else if (y is uint)
                {
                    if ((uint)y % 2 == 0) totEvens++;
                }
                else if (y is ulong)
                {
                    if ((ulong)y % 2 == 0) totEvens++;
                }
            }
            return totEvens;
        }

        /// <summary>
        /// This method counts the factors of the provided object number 
        /// contained in the provided Object Array. 
        /// It returns the total number of factors found. 
        /// The object Array will always have at least 1 element.
        /// </summary>
        /// <param name="objArr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        // public static int UseDoWhile(object[] objArr, object num)
        // {
        //     //throw new NotImplementedException("UseDoWhile() is not implemented yet.");
        //     int totFactors = 0;
        //     int iterator = 0;
        //     do
        //     {
        //         if (num is double && objArr[iterator] is double)
        //         {
        //             System.Console.WriteLine($"IN DOUBLES => {(double)num % (double)(objArr[iterator])}");
        //             if ((double)num % (double)(objArr[iterator]) == 0)
        //             {
        //                 totFactors++;
        //             }
        //         }
        //         else if (num is float && objArr[iterator] is float)
        //         {
        //             if ((float)num % (float)objArr[iterator] == 0) totFactors++;
        //         }
        //         else if (num is sbyte && objArr[iterator] is sbyte)
        //         {
        //             if ((sbyte)num % (sbyte)objArr[iterator] == 0) totFactors++;
        //         }
        //         else if (num is byte && objArr[iterator] is byte)
        //         {
        //             if ((byte)num % (byte)objArr[iterator] == 0) totFactors++;
        //         }
        //         else if (num is short && objArr[iterator] is short)
        //         {
        //             if ((short)num % (short)objArr[iterator] == 0) totFactors++;
        //         }
        //         else if (num is ushort && objArr[iterator] is ushort)
        //         {
        //             if ((ushort)num % (ushort)objArr[iterator] == 0) totFactors++;
        //         }
        //         else if (num is uint && objArr[iterator] is uint)
        //         {
        //             if ((uint)num % (uint)objArr[iterator] == 0) totFactors++;
        //         }
        //         else if (num is int && objArr[iterator] is int)
        //         {
        //             if ((int)num % (int)objArr[iterator] == 0) totFactors++;
        //         }

        //         iterator++;
        //         System.Console.WriteLine($"Iterator is {iterator}");
        //     } while (iterator < objArr.Length);
        //     return totFactors;
        // }

        /// <summary>
        /// This method counts the multiples of 4 from the provided List<int>. 
        /// Exit the loop when the integer 1234 is found.
        /// Return the total number of multiples of 4.
        /// </summary>
        /// <param name="x"></param>
        public static int UseWhile(List<int> x)
        {
            //throw new NotImplementedException("UseFor() is not implemented yet.");

            int iterator = 0;
            int totMults = 0;

            while (x[iterator] != 1234)
            {
                if (x[iterator] % 4 == 0)
                {
                    totMults++;
                }
                iterator++;
            }
            return totMults;
        }

        /// <summary>
        /// This method will evaluate the Int Array provided and return how many of its 
        /// values are multiples of 3 and 4.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int UseForThreeFour(int[] x)
        {
            //throw new NotImplementedException("UseForThreeFour() is not implemented yet.");
            int totNums = 0;
            for (int y = 0; y < x.Length; y++)
            {
                if (y % 3 == 0 && y % 4 == 0)
                {
                    totNums++;
                }
            }
            return totNums;
        }

        /// <summary>
        /// This method takes an array of List<string>'s. 
        /// It concatenates all the strings, with a space between each, in the Lists and returns the resulting string.
        /// </summary>
        /// <param name="stringListArray"></param>
        /// <returns></returns>
        public static string LoopdyLoop(List<string>[] stringListArray)
        {
            //throw new NotImplementedException("LoopdyLoop() is not implemented yet.");
            string myString = "";
            for (int y = 0; y < stringListArray.Length; y++)
            {
                foreach (string x in stringListArray[y])
                {
                    myString += (x + " ");
                }
            }
            return myString;
        }
    }
}