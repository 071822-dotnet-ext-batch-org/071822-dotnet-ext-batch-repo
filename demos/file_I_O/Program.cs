using System;
using System.IO;

namespace file_I_O
{
    class Program
    {
        static void Main(string[] args)
        {
            // to write to a file use the 'StreamWriter' object
            //loop it!
            /**
            string marksString = "This is a string of chars";

            for (int i = 0; i < marksString.Length; i++)
            {
                writer.Write(marksString[i]);
            }
            writer.Close();

            int interator = 1;
            foreach (char c in marksString)
            {
                StreamWriter writer = new StreamWriter("file.txt", true);
                writer.WriteLine($"{interator++} {marksString}");
                writer.Close();
                // interator++;
            }
            */

            StreamReader reader = new StreamReader("file.txt");

            /**
                        int i = 0;
                        while (!reader.EndOfStream)
                        {
                            string str = reader.ReadLine();
                            Console.WriteLine($"{i++} - {str}");
                        }
            **/
            int i = 0;
            string str = "";
            while (!reader.EndOfStream)
            {
                str += reader.ReadLine() + " ";
            }
            Console.WriteLine(str);



        }
    }
}
