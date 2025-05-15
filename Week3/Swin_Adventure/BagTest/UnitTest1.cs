using Swin_Adventure;
namespace BagTest;

public class Tests
{
    private Bag _testToolBag;
    private Bag _testFoodBag;

    private Item hammer;
    private Item apple;
    [SetUp]
    public void Setup()
    {
        _testToolBag = new Bag(new string[] { "toolbag" }, "ToolBag", "A tool bag");
        _testFoodBag = new Bag(new string[] { "foodbag" }, "FoodBag", "A food bag");

        hammer = new Item(new string[] { "hammer" }, "Hammer", "A big hammer");
        apple = new Item(new string[] { "apple" }, "Apple", "A juicy apple");

        _testToolBag.Inventory.Put(hammer);
        _testToolBag.Inventory.Put(apple);
    }

    [Test]
    public void TestBagLocatesItems()
    {
        GameObject item = _testToolBag.Locate("hammer");
        Assert.That(item, Is.EqualTo(hammer));
        Assert.That(_testToolBag.Inventory.HasItem("hammer"), Is.True);
    }
    [Test]
    public void TestBagLocatesItself()
    {
        var result = _testToolBag.Locate("toolbag");
        Assert.That(result, Is.EqualTo(_testToolBag));
    }

    [Test]
    public void TestBagLocatesNothing()
    {
        var result = _testToolBag.Locate("nothing");
        Assert.That(result, Is.Null);
    }

    [Test]
    public void TestBagFullDescription()
    {
        string desc = _testToolBag.FullDescription;
        Assert.That(desc, Does.Contain("In the ToolBag you can see:"));
        Assert.That(desc, Does.Contain("Hammer"));
    }
    [Test]

    public void TestBagInBag()
    {
        _testToolBag.Inventory.Put(_testFoodBag);
        var wrench = new Item(new string[] { "wrench", "spanner" }, "Wrench", "A heavy-duty wrench");
        _testToolBag.Inventory.Put(wrench);
        Assert.That(_testToolBag.Locate("foodbag"), Is.EqualTo(_testFoodBag));
        Assert.That(_testToolBag.Locate("Hammer"), Is.EqualTo(hammer));
        Assert.That(_testToolBag.Locate("wrench"), Is.EqualTo(wrench));

        // Put item into _testFoodBag and test if _testToolBag cannot locate it
        var nestedItem = new Item(new string[] { "biscuit" }, "Biscuit", "A sweet biscuit");
        _testFoodBag.Inventory.Put(nestedItem);
        Assert.That(_testToolBag.Locate("biscuit"), Is.Null);
    }
    [Test]
    public void TestBagInBagWithPrivilegedItem(){
       var secret = new Item(new string[] { "secret" }, "Secret Note", "A secret note inside");
        secret.PrivilegeEscalation("5442");
        _testToolBag.Inventory.Put(_testFoodBag);
        _testFoodBag.Inventory.Put(secret);
        Assert.That(_testToolBag.Locate("cos20007"), Is.Null);

    }
    //=====Verification task=======
    [Test]
    public void TestLocateItemInPlayerInventory1(){
       Player player= new Player("player1","a bad player");
        Bag bag= new Bag(new string[]{"bag"}, "bag", "A big bag");
        player.Inventory.Put(bag);
        Item item = new Item(new string[]{"item"}, "Item", "a old item");
        player.Inventory.Put(item);
        Assert.That(bag.LocateItemInPlayer(player, "item"), Is.EqualTo(1));
    }
    [Test]
    public void TestLocateItemInPlayerInventory2(){
       Player player= new Player("player1","a bad player");
        Bag bag= new Bag(new string[]{"bag"}, "bag", "A big bag");
        player.Inventory.Put(bag);
        Item item = new Item(new string[]{"item"}, "Item", "a old item");
        bag.Inventory.Put(item);
        Assert.That(bag.LocateItemInPlayer(player, "item"), Is.EqualTo(2));
    }
    [Test]
    public void TestLocateItemInPlayerInventory3(){
        Player player= new Player("player1","a bad player");
        Bag bag= new Bag(new string[]{"bag"}, "bag", "A big bag");
        Item item = new Item(new string[]{"item"}, "Item", "a old item");
        Assert.That(bag.LocateItemInPlayer(player, "item"), Is.EqualTo(3));
        
    }
    
    


}
