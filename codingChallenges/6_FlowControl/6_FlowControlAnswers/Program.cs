using System;

namespace _6_FlowControl
{
    public class Program
    {
        //create global variables to hold users login data.
        public static string username { get; set; }
        public static string password { get; set; }

        static void Main(string[] args)
        {
            //Challenge 1. Temperature Advice
            int temp = GetValidTemperature();
            GiveActivityAdvice(temp);

            //Challenge 2. Login system.
            Register();
            if (Login())
            {
                Console.WriteLine("Congratulations, You successfully logged in.");
            }

            //Challenge 3. Ternary Operators
            temp = GetValidTemperature();
            GetTemperatureTernary(temp);
        }

        /// <summary>
        /// This method gets a valid temperature between -40 asnd 135 inclusive from the user
        /// and returns the valid int. 
        /// </summary>
        /// <returns></returns>
        public static int GetValidTemperature()
        {
            int temp = 136;
            do
            {
                Console.WriteLine("What is the temperature today?\nPlease enter a number between -40 and 135");
                string input = Console.ReadLine();

                while (!int.TryParse(input, out temp) || temp > 135 || temp < -40)
                {
                    System.Console.WriteLine("That's not correct. Please enter a number between -40 and 135");
                    input = Console.ReadLine();
                }
            } while (temp < -40 || temp > 135);

            return temp;
        }

        /// <summary>
        /// This method has one int parameter
        /// It prints outdoor activity advice and temperature opinion to the console 
        /// based on 20 degree increments starting at -20 and ending at 135 
        /// n < -20, Console.Write("hella cold");
        /// -20 <= n < 0, Console.Write("pretty cold");
        ///  0 <= n < 20, Console.Write("cold");
        /// 20 <= n < 40, Console.Write("thawed out");
        /// 40 <= n < 60, Console.Write("feels like Autumn");
        /// 60 <= n < 80, Console.Write("perfect outdoor workout temperature");
        /// 80 <= n < 90, Console.Write("niiice");
        /// 90 <= n < 100, Console.Write("hella hot");
        /// 100 <= n < 135, Console.Write("hottest");
        /// </summary>
        /// <param name="temp"></param>
        public static void GiveActivityAdvice(int temp)
        {
            switch (temp)
            {
                case < -20://test a range of values.
                    System.Console.WriteLine($"{temp}?! That's hella cold. Stay in!");
                    break;
                case < 0:
                    System.Console.WriteLine($"{temp}. That's pretty cold. Go skiing!");
                    break;
                case < 20:
                    System.Console.WriteLine($"{temp}. That's cold. Keep skiing!");
                    break;
                case < 40:
                    System.Console.WriteLine($"{temp}. Things are thawed out. Bundle up and take a walk!");
                    break;
                case < 60:
                    System.Console.WriteLine($"{temp}. No snow yet. It feels like Autumn!");
                    break;
                case < 80:
                    System.Console.WriteLine($"{temp}. That's perfect outdoor workout temperature. Go run a marathon!");
                    break;
                case < 90:
                    System.Console.WriteLine($"{temp}. That's niiice. Go to the beach!!");
                    break;
                case < 100:
                    System.Console.WriteLine($"{temp}. That's hella hot. Bring the pets in!");
                    break;
                case < 135:
                    System.Console.WriteLine($"{temp}. That's The hottest temperature ever recorded. Time to bathe in ice!!");
                    break;
                default:
                    System.Console.WriteLine("This is the Switch Statement default");
                    break;
            }
        }

        /// <summary>
        /// This method gets a username and password from the user
        /// and stores that data in the global variables of the 
        /// names in the method.
        /// </summary>
        public static void Register()
        {
            Console.WriteLine("Please enter a username");
            username = Console.ReadLine();
            Console.WriteLine("username saved.");

            Console.WriteLine("Please enter a password");
            password = Console.ReadLine();
            Console.WriteLine("password saved.");
        }

        /// <summary>
        /// This method gets username and password from the user and
        /// compares them with the username and password names provided in Register().
        /// If the password and username match, the method returns true. 
        /// If they do not match, the user is reprompted for the username and password
        /// until the exact matches are inputted.
        /// </summary>
        /// <returns></returns>
        public static bool Login()
        {
            string inputUsername;
            string inputPassword;
            System.Console.WriteLine("To log in, please enter a username and Password that exactly match your username and password");

            do
            {
                Console.WriteLine("Please enter your username");
                inputUsername = Console.ReadLine();

                Console.WriteLine("Please enter a password");
                inputPassword = Console.ReadLine();
            }
            while (!Equals(inputUsername, username) || !Equals(inputPassword, password));
            return true;
        }

        /// <summary>
        /// This method has one int parameter.
        /// It checks if the int is <=42, Console.WriteLine($"{temp} is too cold!");
        /// between 43 and 78 inclusive, Console.WriteLine($"{temp} is an ok temperature");
        /// or > 78, Console.WriteLine($"{temp} is too hot!");
        /// For each temperature range, a different advice is given. 
        /// </summary>
        /// <param name="temp"></param>
        public static void GetTemperatureTernary(int temp)
        {
            //that's one BIG ternary operator!
            string result = temp <= 42 ? $"{temp} is too cold!" : temp >= 43 && temp <= 78 ? $"{temp} is an ok temperature" : temp > 78 ? $"{temp} is too hot!" : "This is the default catch-all";
            System.Console.WriteLine(result);
        }
    }//EoP
}//EoN
