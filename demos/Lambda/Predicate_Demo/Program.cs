using System;
using System.Linq;

namespace Predicate_demo
{
    public class Program
    {
        public static void Main()
        {
            //this is a Lambda expression to create a invokable delegate of 'Func<List<string>, int, List<string>>'
            // this 'Func' Delegate is invoked with  =>   'List<string>? c = b(strList, 6);'
            Func<List<string>, int, List<string>>? b = (List<string> z, int zz) =>
            {
                List<string> strList = new List<string>();
                foreach (string x in z)
                {
                    if (x.Length == zz)
                    {
                        strList.Add(x);
                    }
                }
                return strList;
            };

            List<string> strList = new List<string>();
            strList.Add("SGumbo");
            strList.Add("tastes");
            strList.Add("candy");
            strList.Add("after");
            strList.Add("eating,");
            strList.Add("but");
            strList.Add("exercise");
            strList.Add("doesn't.");

            // use LINQ to folter a List<string>
            List<string> res = strList.Where(x => x.Length == 6).ToList();

            var res3 = strList.Where(x => x.Contains("es")).FirstOrDefault();// TOP 1
            Console.WriteLine($"The return from substring 'es' is {res3}");

            List<string> res1 = Program.GetLength5Str(strList, 6);

            foreach (string i in res)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            foreach (string i in res1)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            List<string> res2 = b(strList, 6);
            foreach (string i in res2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            b += Program.GetLength5Str;

            // invoke b
            List<string>? c = b(strList, 6);

            foreach (string i in c)
            {
                Console.WriteLine(i);
            }

        }

        //x => x.Length == 5 is equivalent to this method
        public static List<string> GetLength5Str(List<string> str, int y)
        {
            List<string> strList = new List<string>();
            foreach (string x in str)
            {
                if (x.Length == y)
                {
                    strList.Add(x);
                }
            }
            return strList;
        }


    }
}
