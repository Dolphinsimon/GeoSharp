using System;

namespace GeoSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please in put the path of data file.");
            var path=Console.ReadLine();
            var start = DateTime.Now;
            var s=path?.Replace("\"","");
            var updater=new GeoSharpUpdater();
            try
            {
                updater.Start(s);
                var end = DateTime.Now;
                Console.WriteLine($"Process successful!Total time consuming {end-start}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Some error occurred! Error message is {e.Message}");
            }
            Console.ReadLine();
        }
    }
}
