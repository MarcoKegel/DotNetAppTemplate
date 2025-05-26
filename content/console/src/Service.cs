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

public class Service(ILogger<Service> logger):IService
{
    /// <inheritdoc>
    public void Foo()
    {
        logger.LogDebug(nameof(Foo));
        throw new NotImplementedException(nameof(Foo));
    }
    
    /// <inheritdoc>
    public async Task FooAsync()
    {
          logger.LogDebug(nameof(FooAsync));
        await Task.Yield();
        throw new NotImplementedException(nameof(FooAsync));
    }
}
