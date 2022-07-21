using System;

namespace consoleapps1
{
    class Program
    {
        // multiline comment below!
        /**'static' is an modifier that means that the method (or member) that can me called 
        without creating an instance of the class that the method is in. */

        // 'void' means that the method for now return anything. no int. no string. no char. no nothin'

        //'Main' is imprtant here because the runtime looks for a 'static void Main()' method be default
        // to begin execution of the program.
        static void Main(string[] args) // this method is the ENTRYPOINT to your dotnet application.
        {
            Console.WriteLine("Hello World from the .net 5.0 app!");
        }
    }
}
