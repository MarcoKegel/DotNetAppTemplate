namespace Meixner.consolename_template;

internal class App
{
    private readonly IService _service;

    public App(IService service)
    {
        _service = service;
    }
    public void Run()
    {
        _service.Foo();
    }
}