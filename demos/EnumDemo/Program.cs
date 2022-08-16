namespace EnumDemo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Hello, {(int)TxSeasons.Spri}");
        Console.WriteLine($"Hello, {(int)TxSeasons.LateSpring}");
        Console.WriteLine($"Hello, {(int)TxSeasons.EarlySummer}");
        Console.WriteLine($"Hello, {(int)TxSeasons.Summer}");
        Console.WriteLine($"Hello, {(int)TxSeasons.MiddleLateSummer}");
        Console.WriteLine($"Hello, {(int)TxSeasons.Winter}");

        var y = TxSeasons.EarlySummer;
        Console.WriteLine($"Y is {y}");

        int x = Convert.ToInt32(TxSeasons.LateSpring);
        Console.WriteLine($"x is {x}");

        int t = new int();// 
        Console.WriteLine(t);

        double z = (double)TxSeasons.ReallyLateSummer + .01;
        Console.WriteLine($"Z is {z}");//format the string version of the Enum to have 2 decimal pts after it.

        var z1 = TxSeasons.ReallyLateSummer.ToString();
        Console.WriteLine($"Z is {z1}");

        int myValInt = 15;
        int retInt = Program.IncrementMyValueTypeInt(myValInt);
        Console.WriteLine($"myValInt is {myValInt} and {retInt}");

        int myValInt1 = 15;// int is a value type 
        int retInt1 = Program.IncrementMyReferenceTypeInt(ref myValInt1);//when calling a method that take a 'ref'
        Console.WriteLine($"myValInt1 is {myValInt1} and {retInt1}");


        string s = "Mark";
        string ss = Program.ChangeString(s);
        Console.WriteLine($"s is {s} and ss is {ss}");

        Person s1 = new Person();
        Person ss1 = Program.ChangePersonAge(s1);
        Console.WriteLine($"s1 is {s1.age} and ss1 is {ss1.age}");

        //boxing and unboxing
        int a1 = 1;

        object a2 = a1; //you can IMPLICITLY convert a sub type to a super type (go UP the tree)
        Console.WriteLine($"The object is {a2}");

        int a3 = (int)a2; //you have to EXPLICITLY convert to a sub type (go down the tree)

        int a4 = 5;// these demonstrate the same concept but are more about memory and losing data, than specific characteristics.
        double a5 = a4;
        int a6 = (int)a5;

        List<string> strList = new List<string>();
        strList.Add("Mark ");
        strList.Add("is ");
        strList.Add("a ");
        strList.Add("very ");
        strList.Add("kewl ");
        strList.Add("guy ");

        foreach (string str in strList)
        {
            Console.Write($"{str}");
        }
        Console.WriteLine();


        GenericList<Person> p1 = new GenericList<Person>();
        p1.AddT(s1);
        p1.AddT(ss1);
        p1.PrintList();

    }

    public enum TxSeasons
    {
        Spri = 11,
        LateSpring = 12,
        EarlySummer = 15,
        Summer = 20,
        MiddleLateSummer = 23,
        ReallyLateSummer,//24
        Fal,//25
        Winter//26
    }

    public static int IncrementMyValueTypeInt(int x)
    {
        return ++x;
    }

    public static int IncrementMyReferenceTypeInt(ref int x)
    {
        ++x;
        return x;
    }

    public static string ChangeString(string s)
    {
        return s + " Moore";
    }

    public static Person ChangePersonAge(Person s)
    {
        s.age++;
        return s;
    }




}






