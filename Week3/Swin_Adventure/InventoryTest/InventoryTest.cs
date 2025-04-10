using Swin_Adventure;
namespace InventoryTest;
using NUnit.Framework;
public class Tests
{

    private Inventory _inventory;
    private Item _sword;
    private Item _shield;
    private Item validItem;
    private Item invalidItem;
    private Item duplicateItem;

    [SetUp]
    public void Setup()
    {
        _inventory = new Inventory();
        _sword = new Item(new string[] { "sword" }, "Sword", "A sharp blade");
        _shield = new Item(new string[] { "shield" }, "Shield", "A protective barrier");
        validItem = new Item(new[] { "id1", "id2" }, "Valid", "Test");
        invalidItem = new Item(new[] { "a", "b", "c" }, "Invalid", "Test");
        duplicateItem = new Item(new[] { "id1" }, "Duplicate", "Test");

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

    [Test]
    public void TestRemoveItem()
    {
        _inventory.RemoveItem(_sword);
        Assert.IsFalse(_inventory.HasItem("_sword"));
    }

    [Test]
    public void TestPutItemWithLimit()
    {
      
        Assert.IsTrue( _inventory.PutItemWithLimit(validItem));

        Assert.IsFalse( _inventory.PutItemWithLimit(invalidItem));

        Assert.IsFalse( _inventory.PutItemWithLimit(duplicateItem));
    }
}
