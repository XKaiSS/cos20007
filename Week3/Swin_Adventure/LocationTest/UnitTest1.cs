using Swin_Adventure;
using NUnit.Framework;

namespace LocationTest;

public class Tests
{
    private Location _location;
    private Item _sword;
    private Item _shield;

    [SetUp]
    public void Setup()
    {
        _location = new Location(new string[] { "room", "kitchen" }, "Kitchen", "A small kitchen");
        _sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
        _shield = new Item(new string[] { "shield" }, "Shield", "A protective barrier");
    }

    [Test]
    public void TestLocationCreation()
    {
        Assert.That(_location.Name, Is.EqualTo("Kitchen"));
        Assert.That(_location.ShortDescription, Is.EqualTo("Kitchen (room)"));
        Assert.That(_location.AreYou("room"), Is.True);
        Assert.That(_location.AreYou("kitchen"), Is.True);
    }

    [Test]
    public void TestLocationInventory()
    {
        _location.Inventory.Put(_sword);
        _location.Inventory.Put(_shield);

        Assert.That(_location.Inventory.HasItem("sword"), Is.True);
        Assert.That(_location.Inventory.HasItem("shield"), Is.True);
    }

    [Test]
    public void TestLocateItem()
    {
        _location.Inventory.Put(_sword);
        
        var locatedItem = _location.Locate("sword");
        Assert.That(locatedItem, Is.EqualTo(_sword));
    }

    [Test]
    public void TestLocateSelf()
    {
        var locatedSelf = _location.Locate("room");
        Assert.That(locatedSelf, Is.EqualTo(_location));
    }

    [Test]
    public void TestLocateNonExistentItem()
    {
        var locatedItem = _location.Locate("nonexistent");
        Assert.That(locatedItem, Is.Null);
    }

    [Test]
    public void TestFullDescription()
    {
        _location.Inventory.Put(_sword);
        _location.Inventory.Put(_shield);

        string expectedDescription = "You are in Kitchen\nIn this room you can see:\nSword (sword), Shield (shield)";
        Assert.That(_location.FullDescription, Is.EqualTo(expectedDescription));
    }

    [Test]
    public void TestEmptyLocationDescription()
    {
        string expectedDescription = "You are in Kitchen\nIn this room you can see:\n";
        Assert.That(_location.FullDescription, Is.EqualTo(expectedDescription));
    }
}
