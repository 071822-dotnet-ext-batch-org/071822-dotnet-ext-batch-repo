using System.Reflection;

namespace ReflectionDemoProj;
class Program
{
    public static string MyMood { get; set; } = "cheery";// properties count as members.
    public static int MyPopsicleSticks { get; set; } = 4;
    public static int a = 5, b = 10, c = 20;// does (int) not count as a member

    static void Main(string[] args)
    {
        #region Access the properties and fields in a class... even the class you are currently in!
        //first we are going to use reflection to get the data from some local vars.
        Type programType = typeof(Program);

        // The Type object representing Program give you more internal 
        // metadata than a Program object created programmatically
        //Program p = new Program();

        // basic integers do not count as memebrs for purposes of Reflection as shown here.
        MemberInfo[] memberInfoArr = programType.GetMember("a");
        foreach (MemberInfo mi in memberInfoArr)
        {
            Console.WriteLine($"{mi.DeclaringType} declared {mi.Name} with a type of {mi.GetType()}....");
        }

        // because a is a field, not a property, we must get it with '.GetField()'
        FieldInfo? fi = programType.GetField("a", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
        if (fi != null)
        {
            Console.WriteLine($"{fi?.Name} is a/an {fi?.GetType()} and it's value is {fi?.GetValue(null)}");
            fi?.SetValue(null, 10);
            Console.WriteLine($"{fi?.Name} is a/an {fi?.GetType()} and it's new value is {fi?.GetValue(null)}");
        }
        else Console.WriteLine($"fi was null");

        //here we get members by not all metadata is available... so we get mor specific below....
        MemberInfo[] gms = programType.GetMembers();
        foreach (var i in gms)
        {
            Console.WriteLine($"{i.Name} is a {i.GetType()} and it's value is unavailable?");
        }

        // get the property info (bc properties have backing info, etc...)
        PropertyInfo[] gps = programType.GetProperties();
        foreach (var i in gps)
        {
            //yes, you still have to send in the containing class Type obj when getting the property value.
            Console.WriteLine($"{i.Name} is a {i.GetType()} and it's value is {i.GetValue(null)}");
        }

        PropertyInfo? x = programType.GetProperty("MyMood");
        Console.WriteLine($"The value of {x?.Name} is {x?.GetValue(programType)}");

        #endregion

        #region Let's explore the assembly!
        Assembly assemblyType = typeof(Program).Assembly;
        Console.WriteLine($"{assemblyType.Location}");
        Console.WriteLine($"{assemblyType.EntryPoint}");
        Console.WriteLine($"{assemblyType.FullName}");
        Console.WriteLine($"{assemblyType.ToString()}");
        Console.WriteLine($"{assemblyType.GetHashCode()}");
        Console.WriteLine($"{assemblyType.GetName()}");
        Console.WriteLine($"{assemblyType.SecurityRuleSet}");
        //Console.WriteLine($"{assemblyType.LoadModule().ToString()}");
        Console.WriteLine($"{assemblyType.IsFullyTrusted}");

        Type[] assemblyMembers = assemblyType.GetTypes();// get all the Types of the Assembly

        foreach (Type i in assemblyMembers)// iterate ov er the types
        {
            // print out the data abotu each type
            Console.WriteLine($"\t{i.Name} is a '{i.GetType()}', \n\tIt's namespace is '{i.Namespace}'. \n\tIt's a '{i.MemberType}' type of member. \n");
            // if the type have members
            if (i.GetMembers() != null)
            {
                //get all the types members
                MethodInfo[] members = i.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
                // iterate over the member and , if it has the method we're looking for, and that method is parameterless, Invoke it.
                foreach (MethodInfo ii in members)
                {
                    if (ii.Name == "GetMyNameAndAge" && ii.GetParameters().Length > 0)
                    {
                        var classInstance = Activator.CreateInstance(typeof(First1));//
                        // object? age = ii.Invoke(new First1(), null);//if your method has 0 parameters
                        object? age = ii.Invoke(classInstance, new object[] { 45, "arg2" });// you can run methods with 1+ parameters using reflection.
                        Console.WriteLine($"\tThe return from GetMyAge() is {(string)age}\n");
                    }
                }
            }
        }


        #endregion



        First1 f1 = new First1();
        f1.GetMyAge();
    }
}
