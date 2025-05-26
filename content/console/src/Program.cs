using System.IO.Abstractions;
using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Meixner.consolename_template;

public record Options
{
    [Option('v', "verbose", Required = false, HelpText = "Set log level to verbose.")]
    public string? Verbose { get; set; } = null;

}
public class Program
{
    public static async Task Main(string[] args)
    {
        await Parser.Default.ParseArguments<Options>(args)
                   .WithParsedAsync(RunAsync);
        Console.WriteLine($"Exit code= {Environment.ExitCode}");
    }

    //async method
    static async Task RunAsync(Options options)
    {

        Console.WriteLine("Hello, World!");
        await Task.Delay(20); //simulate async method 


        var serviceCollection = new ServiceCollection();

        SetupLogging(serviceCollection, options);
        SetupConfiguration(serviceCollection, options);

        serviceCollection.AddTransient<IFileSystem,FileSystem>();

        serviceCollection.AddTransient<IService, Service>();
        serviceCollection.AddTransient<App>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        ConfigureConsole(serviceProvider.GetService<ApplicationSettings>()!);

        serviceProvider.GetService<App>()!.Run();
    }

    private static void SetupConfiguration(IServiceCollection serviceCollection, Options options)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("ApplicationSettings.json", false)
            .Build();

        serviceCollection.AddOptions();
        serviceCollection.Configure<ApplicationSettings>(configuration.GetSection("Configuration"));
        serviceCollection.AddSingleton(sp => sp.GetRequiredService<IOptions<ApplicationSettings>>().Value);
    }

    private static void SetupLogging(IServiceCollection serviceCollection, Options options)
    {
        var logLevel = options.Verbose switch
        {

            null => LogLevel.Warning,
            "" or " " => LogLevel.Information,
            "v" => LogLevel.Debug,
            "vv" => LogLevel.Trace,
            _ => LogLevel.Trace // default log level
        };

        serviceCollection.AddLogging(build => build.AddConsole().SetMinimumLevel(logLevel));
    }

    private static void ConfigureConsole(ApplicationSettings settings)
    {
        System.Console.Title = settings.ConsoleTitle;
    }
}
