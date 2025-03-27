using Swin_Adventure;
namespace InventoryTest;
using NUnit.Framework;
public class Tests
{

    private Inventory _inventory;
    private Item _sword;
    private Item _shield;

    [SetUp]
    public void Setup()
    {
        _inventory = new Inventory();
        _sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
        _shield = new Item(new string[] { "shield" }, "Shield", "A protective barrier");
        _inventory.Put(_sword);
    }

    [Test]
    public void TestFindItem()
    {
        Assert.IsTrue(_inventory.HasItem("sword"));
    }

    [Test]
    public void TestNoItemFind()
    {
        Assert.IsFalse(_inventory.HasItem("bow"));
    }

    [Test]
    public void TestFetchItem()
    {
        var item = _inventory.Fetch("sword");
        Assert.AreEqual(_sword, item);
        Assert.IsTrue(_inventory.HasItem("sword"));
    }

    [Test]
    public void TestTakeItem()
    {
        var item = _inventory.Take("sword");
        Assert.AreEqual(_sword, item);
        Assert.IsFalse(_inventory.HasItem("sword"));
    }

    [Test]
    public void TestItemList()
    {
        _inventory.Put(_shield);
        string expectedList = "\ta Sword (sword)\n\ta Shield (shield)";
        Assert.AreEqual(expectedList, _inventory.ItemList);
    }
}
