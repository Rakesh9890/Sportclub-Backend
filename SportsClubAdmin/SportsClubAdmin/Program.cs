using Serilog;
using SportsClubAdmin;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Logging is working!");
        CreateHostBuilder(args).Build().Run();

    }


    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).UseSerilog();
         /*.ConfigureLogging(logging =>
               {
                 logging.ClearProviders();
                  logging.AddConsole(); // Add this line to enable logging in the console
              });*/

}