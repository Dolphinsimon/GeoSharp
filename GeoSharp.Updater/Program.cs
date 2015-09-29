using System;
using System.Diagnostics.CodeAnalysis;
using static System.Threading.Thread;
using static System.Console;

namespace GeoSharp.Updater
{
    class Program
    {
        private static void processISO3166_1_NUMERIC()
        {
            WriteLine("Now we will update the ISO 3166-1 numeric.");
            WriteLine("Please input the path of a data file.");
            var path = ReadLine();
            var s = path?.Replace("\"", "");
            var start = DateTime.Now;
            var updater = new GeoSharpUpdater();
            try
            {
                updater.StartISO3166_1_NUMERIC(s);
                var end = DateTime.Now;
                WriteLine($"Process successful!Total time consuming {end - start}");
            }
            catch (Exception e)
            {
                WriteLine($"Some error occurred! Error message is {e.Message}");
            }
        }

        private static void processISO3166_1_ALPHA_3()
        {
            WriteLine("Now we will update the ISO 3166-1 alpha 3.");
            WriteLine("Please input the path of a data file.");
            var path = ReadLine();
            var s = path?.Replace("\"", "");
            var start = DateTime.Now;
            var updater = new GeoSharpUpdater();
            try
            {
                updater.StaartISO3166_1_ALPHA_3(s);
                var end = DateTime.Now;
                WriteLine($"Process successful!Total time consuming {end - start}");
            }
            catch (Exception e)
            {
                WriteLine($"Some error occurred! Error message is {e.Message}");
            }
        }
        [SuppressMessage("ReSharper", "FunctionNeverReturns")]
        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("This application can handle these data updating request:");
                WriteLine("1.ISO 3166-1 numeric 2.ISO 3166-1 alpha 3 ");
                WriteLine("Please input the number you need.");
                var choice = ReadLine();
                WriteLine($"Your choice is {choice}. Input y to confirm or n to cancel.");
                var confirm = ReadLine();
                if(confirm==null||confirm.Equals("n",StringComparison.OrdinalIgnoreCase)) continue;
                if (confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    switch (choice)
                    {
                        case "1":
                            processISO3166_1_NUMERIC();
                            break;
                        case "2":
                            processISO3166_1_ALPHA_3();
                            break;
                        default:
                            WriteLine("Unsupported input string!process terminated,application will start over after 3 seconds.");
                            Sleep(1000);
                            WriteLine("3");
                            Sleep(1000);
                            WriteLine("2");
                            Sleep(1000);
                            WriteLine("1");
                            break;
                    }
                }
                else
                {
                    WriteLine("Your input commands are not Y or N,process terminated,application will start over after 3 seconds.");
                    Sleep(1000);
                    WriteLine("3");
                    Sleep(1000);
                    WriteLine("2");
                    Sleep(1000);
                    WriteLine("1");
                }
            }

        }
    }
}
