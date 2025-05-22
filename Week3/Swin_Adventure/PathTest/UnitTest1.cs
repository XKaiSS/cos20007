namespace PathTest;
using NUnit.Framework;
using Swin_Adventure;

public class Tests
{
    private Location _source;
    private Location _destination;
    private Path _path;

    [SetUp]
    public void Setup()
    {
        _source = new Location(new string[] { "room1" }, "Room 1", "First room");
        _destination = new Location(new string[] { "room2" }, "Room 2", "Second room");
        _path = new Path(new string[] { "north" }, "North Path", "A path leading north", _source, _destination);
    }

    [Test]
    public void TestPathCreation()
    {
        Assert.That(_path.Name, Is.EqualTo("North Path"));
        Assert.That(_path.ShortDescription, Is.EqualTo("North Path (north)"));
        Assert.That(_path.FullDescription, Is.EqualTo("A path leading north"));
    }

    [Test]
    public void TestPathIdentifiers()
    {
        Assert.That(_path.AreYou("north"), Is.True);
        Assert.That(_path.AreYou("south"), Is.False);
    }

    [Test]
    public void TestPathSourceAndDestination()
    {
        Assert.That(_path.Source, Is.EqualTo(_source));
        Assert.That(_path.Destination, Is.EqualTo(_destination));
    }

    [Test]
    public void TestPathMove()
    {
        Player player = new Player("John", "A player");
        player.Location = _source;

        _path.Move(player);
        Assert.That(player.Location, Is.EqualTo(_destination));
    }

    [Test]
    public void TestPathMoveFromWrongLocation()
    {
        Player player = new Player("John", "A player");
        player.Location = _destination; // Player starts at destination

        _path.Move(player);
        Assert.That(player.Location, Is.EqualTo(_destination)); // Should not move
    }
} 