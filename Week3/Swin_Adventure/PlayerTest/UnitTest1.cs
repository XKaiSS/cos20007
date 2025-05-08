namespace PlayerTest;

using NUnit.Framework.Internal;
using Swin_Adventure;

public class Tests
{
    
    private Item _sword;
    private Item _shield;
    private Player _player;

    [SetUp]
    public void Setup()
    {
        _player = new Player("XiKai", "A killer!");
        _sword = new Item(new string[] { "sword" }, "A sword", "A sharp sword");
        _shield = new Item(new string[] { "shield" }, "A shield", "A strong shield");
        _player.Inventory.Put(_sword);
        _player.Inventory.Put(_shield);

    }

    [Test]
    public void TestPlayerIsIdentifiable()
    {
        Assert.That( _player.AreYou("me"), Is.True );
        Assert.That( _player.AreYou("Inventory"), Is.True );
    }

    [Test]
    
    public void TestPlayerLocatesItself()
    {
        GameObject found = _player.Locate("me");
       
        Assert.That( found, Is.EqualTo(_player));
    }

    [Test]

    public void TestPlayerLocatesItems(){

        GameObject found = _player.Locate("sword");
        Assert.That(found, Is.EqualTo(_sword));
    }

    [Test]

    public void TestPlayerLocatesNothing(){
        GameObject found = _player.Locate("1");
        Assert.That(found, Is.Null);
    }

    [Test]

    public void TestPlayerFullDescription(){
        string FullDescription = _player.FullDescription;
        Assert.That( FullDescription.Contains("XiKai"), Is.True);
        Assert.That( FullDescription.Contains("A killer"), Is.True);
        Assert.That( FullDescription.Contains(_sword.ShortDescription), Is.True);
        Assert.That( FullDescription.Contains(_shield.ShortDescription), Is.True);
        Assert.That( FullDescription.Contains("You are carring:"), Is.True);   
        Assert.That( FullDescription.Contains("A sword (sword), A shield (shield)"), Is.True);

    }
    
}