using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meixner.consolename_template;

public class Program
{
    public static int Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // create service collection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);


        var serviceProvider = serviceCollection.BuildServiceProvider();

        ConfigureConsole(serviceProvider.GetService<ApplicationSettings>()!);

        serviceProvider.GetService<App>()!.Run();



        return 0;
    }

    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        //TODO add logging
        // serviceCollection.AddSingleton(new LoggerFactory()
        //     .AddConsole()
        //     .AddDebug());
        // serviceCollection.AddLogging(); 


        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("ApplicationSettings.json", false)
            .Build();

        serviceCollection.AddOptions();
        serviceCollection.Configure<ApplicationSettings>(configuration.GetSection("Configuration"));

        // add services
        serviceCollection.AddTransient<IService, Service>();

        // add app
        serviceCollection.AddTransient<App>();
    }

    private static void ConfigureConsole(ApplicationSettings settings)
    {
        System.Console.Title = settings.ConsoleTitle;
    }
}
