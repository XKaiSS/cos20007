namespace LookCommandTest;
using Swin_Adventure;

public class Tests
{
    private Item gem;
    private Item pen;
    private Player player;
    private Bag bag;
    private LookCommand lookCommand;

    [SetUp]
    public void Setup()
    {
        player = new Player("Sun", "An adventurous player");
        gem = new Item(new string[] { "gem" }, "a shiny gem", "A sparkling red gem");
        pen = new Item(new string[] { "pen" }, "a black pen", "A simple black ink pen");
        bag = new Bag(new string[] { "bag" }, "a leather bag", "A medium-sized leather bag");
        lookCommand = new LookCommand(new string[] { "" });
    }

    [Test]
    public void LookAtPlayer()
    {
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "me" }), Is.EqualTo(player.FullDescription));
    }

    [Test]
    public void LookAtItem()
    {
        player.Inventory.Put(pen);
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "pen" }), Is.EqualTo("A simple black ink pen"));


    }
    [Test]
    public void LookAtNothing()
    {
        player.Inventory.Put(pen);
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "gem" }), Is.EqualTo("I can't find the gem"));

    }
    [Test]
    public void LookAtItemInPlayer()
    {
        player.Inventory.Put(pen);
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "pen" }), Is.EqualTo("A simple black ink pen"));

    }

    [Test]
    public void LookAtItemInBag()
    {
        player.Inventory.Put(bag);
        bag.Inventory.Put(gem);
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("A sparkling red gem"));
    }

    [Test]
    public void LookAtItemInNoBag()
    {
        bag.Inventory.Put(gem);
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I cannot find the bag"));


    }
    [Test]
    public void LookAtNothingInBag()
    {
        player.Inventory.Put(bag);
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "gem", "in", "bag" }), Is.EqualTo("I can't find the gem"));


    }
    [Test]
    public void InvalidLook()
    {
        Assert.That(lookCommand.Execute(player, new string[] { "look", "around" }), Is.EqualTo("I do not know how to look like that"));
        Assert.That(lookCommand.Execute(player, new string[] { "Hello", "sudent", "104215442" }), Is.EqualTo("Error in look input"));
        Assert.That(lookCommand.Execute(player, new string[] { "look", "at", "your", "name", "id" }), Is.EqualTo("What do you want to look in?"));

    }


}
