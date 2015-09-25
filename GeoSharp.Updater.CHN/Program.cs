using System;
using static System.Console;

namespace GeoSharp.CHN
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Please input the path of data file.");
            var path=ReadLine();
            var start = DateTime.Now;
            var s=path?.Replace("\"","");
            var updater=new GeoSharpUpdater();
            try
            {
                updater.Start(s);
                var end = DateTime.Now;
                WriteLine($"Process successful!Total time consuming {end-start}");
            }
            catch (Exception e)
            {
                WriteLine($"Some error occurred! Error message is {e.Message}");
            }
            ReadLine();
        }
    }
}
