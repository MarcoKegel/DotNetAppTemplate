using System.IO.Abstractions.TestingHelpers;
using Microsoft.Extensions.Logging;
using Moq;

namespace Meixner.consolename_template.test;

public class ServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Foo_FileSystemMockWasCalled()
    {
        // Arrange
        var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"c:\myfile.txt", new MockFileData("Testing is meh.") },
            { @"c:\demo\jQuery.js", new MockFileData("some js") },
            { @"c:\demo\image.gif", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
        });

        var sut = new Service(new Mock<ILogger<Service>>().Object, fileSystem);

        // Act
        sut.Foo();

        // Assert
        Assert.That(fileSystem.File.Exists(@"test.txt"), Is.True, "File should exist.");
        Assert.That(fileSystem.File.ReadAllText(@"test.txt"), Is.EqualTo("Hello, World!"), "File content should match.");
    }

    [Test]
    public async Task FooAsync_FileSystemMockWasCalled()
    {
        // Arrange
        var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"c:\myfile.txt", new MockFileData("Testing is meh.") },
            { @"c:\demo\jQuery.js", new MockFileData("some js") },
            { @"c:\demo\image.gif", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
        });

        var sut = new Service(new Mock<ILogger<Service>>().Object, fileSystem);

        // Act
        await sut.FooAsync();

        // Assert
        Assert.That(fileSystem.File.Exists(@"test.txt"), Is.True, "File should exist.");
        Assert.That(fileSystem.File.ReadAllText(@"test.txt"), Is.EqualTo("Hello, World async!"), "File content should match.");
    }
}