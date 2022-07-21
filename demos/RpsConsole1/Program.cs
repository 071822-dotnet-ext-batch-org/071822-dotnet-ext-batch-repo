using System;
using System.Collections.Generic;

namespace RpsConsole1
{
    class Program
    {
        static void Main(string[] args)
        {
            // a sentence is called a string.
            Console.WriteLine("Hello World!");

            // when there are two methods with the same name (method signature)...
            // but different set of parameters, it is called "method overloading".
            Console.WriteLine(43);

            // variables are used to hold data.
            // each variable is declared and given a data type.
            // this type cannot be changed without certain qualifications being met.
            // conventionally, variables are 'writtenInCamelCase'.
            /** Camel Case - 1)no spaces, 2)starts with a lower case letter, 3)all other words are capitalized. EX. 'writtenInCamelCase'.
                Pascal Case - 1)no spaces, 2)starts with a upper case letter, 3)all other words are capitalized. EX. 'WrittenInPascalCase'.
            **/
            // strings in C# must be written with "sdfkjbg" (double quotes)
            string myString = "Mark is super kewl...";//"" is called an "empty string"
            int myInt = 44;


            string myString2;
            myString2 = "this is a value";// strings are immutable...
            myString2 = "this is a very big value";

            Console.WriteLine(myString2.GetType());
            Console.WriteLine(myInt.GetType());

            myInt = 2147483647;

            // myInt = 2147483648;
            long myLong = 2147483648;

            int myInt1 = 1 + 2;
            Console.WriteLine(myInt1);

            Console.WriteLine(myInt1 - myLong);
            Console.WriteLine(100 / 10);
            Console.WriteLine(Math.Pow(100, 2));
            Console.WriteLine(100 * 2);

            //string interpolation
            Console.WriteLine($"The division is => {101 / 10}");//101/10 = 10 remainder 1 10.1

            Console.WriteLine($"The modulus is => {100 % 6}");

            int myInt2 = 10;
            Console.WriteLine(myInt2++);// ++ is an 'incrementor'. it will increment the integer 
            Console.WriteLine(myInt2);// ++ is an 'incrementor'. it will increment the integer 
            Console.WriteLine(++myInt2);// ++ is an 'incrementor'. it will increment the integer 

            Console.WriteLine(myInt2--);// -- is an 'decrementor'. it will decrement the integer 
            Console.WriteLine(myInt2);// -- is an 'decrementor'. it will decrement the integer 
            Console.WriteLine(--myInt2);// -- is an 'decrementor'. it will decrement the integer 

            int a, b, c;// you can declare multiple variables at once
            a = 7;
            b = a;
            c = b++;
            b = a + b * c;// you can combine operators in one expression. Evaluate this expression using PEMDAS/BIDMAS
            a = (int)Math.Sqrt(b * b + c * c);
            a = (int)Math.Sqrt(b * b + c * c);

            /** Flow Control*/
            //this is like a if statement
            int x, y, z;
            x = 5;
            y = 5;
            z = 7;

            if (x > y)// if this camparison is true, do the below
            {
                Console.WriteLine("x is greater than y");
            }
            else if (y > x)
            {// otherwise do this
                Console.WriteLine("y is greater than x");
            }
            else
            {
                Console.WriteLine("y and x are equal");
            }

            a = 5;
            b = 10;
            c = 15;
            double c1 = 0;
            if (a >= 100)
            {// is a greater-than or equal-to 100, if YES, do the below
                c = b;
            }
            else
            {
                c1 = (Convert.ToDouble(c) / 10);// evaluate c/10 then assign the result to c.
            }
            Console.WriteLine($"c1 is {c1}");

            c = a >= 100 ? b : c / 10;// this is a ternary operator
            Console.WriteLine($"c is {c}");


            // arrays
            // in a computer, a string is actually a consecutive group of char (charactor) memory locations
            char[] myCharArr = new char[] { 'M'/**element 0*/, 'a'/**element 1*/, 'r'/**element 2*/, 'k'/**element 3*/, 'y'/**element 4*/ };
            Console.WriteLine($"The element 1 value is => {myCharArr[1]}, the 4th element is {myCharArr[3]} ");// zero-indexing causes 'One-Off' errors

            try
            {
                Console.WriteLine($"The element 1 value is => {myCharArr[7]}");
                Console.WriteLine($"c is {c}. THIS WILL NOT RUN.");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"The out of range exception was thrown. The dealio is {ex.Message}");
            }
            catch (SystemException ex)
            {
                Console.WriteLine($"The SystemException was thrown. The dealio is {ex.Message}");
            }
            catch (Exception tim)
            {
                Console.WriteLine($"The (general) Exception was thrown and caught in the Exception. The dealio is {tim.Message}");
            }
            Console.WriteLine($"THE EXCEPTION WAS CAUGHT.");

            //a for-loop wil iterate over each element of an array. you can do somethin at each element.
            for (int i = 0; i < myCharArr.Length; i++)
            {
                // Console.WriteLine($"The element value is {myCharArr[i]}");// the line terminator is '\n'
                Console.Write($"{myCharArr[i]}");
            }
            Console.WriteLine();

            string myString3 = "Marky";
            // the foreach loop will automatically break out of the loop at the end of the array.
            foreach (char x1 in myCharArr)
            {
                //Console.Write($"{myCharArr[x]}");
                Console.Write($"{x1}.");
            }

            //a while loop will keep iterating untill the comparison is false
            int w = 113;
            while (w > 100)
            {
                Console.Write($"Mark.");
                w--;
            }
            Console.WriteLine();

            //a do-while loop will keep iterating until the comparison is false. I will iterate AT LEAST once.
            do
            {
                Console.Write($"Mark in a do-while.\n");
                w++;
            } while (w < 113);
            Console.WriteLine();




            string s = "String literals";
            char l = s[s.Length - 1];
            Console.WriteLine($"The final char of the string is {l}");

            // collections
            var numbers1 = new List<int>(new[] { 1, 2, 3 });
            b = numbers1.FindLast(n => n > 1);
        }
    }
}
