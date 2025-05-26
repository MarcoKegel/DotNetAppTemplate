using System.IO.Abstractions;
using Microsoft.Extensions.Logging;

namespace Meixner.consolename_template;

/// <summary>
/// 
/// </summary>
public interface IService
{
    /// <summary>
    /// 
    /// </summary>
    public void Foo();

    /// <summary>
    /// Async implementation of <see cref="IService.Foo"
    /// </summary>
    public Task FooAsync();
}

public class Service(ILogger<Service> logger, IFileSystem fileSystem) : IService
{
    /// <inheritdoc>
    public void Foo()
    {
        logger.LogDebug(nameof(Foo));
        fileSystem.File.WriteAllText("test.txt", "Hello, World!");
    }

    /// <inheritdoc>
    public async Task FooAsync()
    {
        logger.LogDebug(nameof(FooAsync));
        await fileSystem.File.WriteAllTextAsync("test.txt", "Hello, World async!");
    }
}
