namespace TestProject2;
using NUnit.Framework;
using Swin_Adventure;
public class Tests
{
    private Item magicalWeapon;
    [SetUp]
    public void Setup()
    {
        magicalWeapon = new Item(new string[]{"multifunctional weapon", "sward", "gun"}, "magical weapon", "This Magical Weapon can quickly change its form to adapt to both melee and ranged combat.");
    }

    [Test]
    public void TestAreYou()
    {

        Assert.IsTrue(magicalWeapon.AreYou("multifunctional weapon"));
    }
    [Test]
    public void TestAreNotYou()
    {

        Assert.IsFalse(magicalWeapon.AreYou("Standard Weapon"));
    }

    [Test]

    public void TestShortDescription(){

        Assert.AreEqual("a magical weapon (multifunctional weapon)", magicalWeapon.ShortDescription);

    }

     [Test]

    public void TestLongDescription(){

         Assert.AreEqual("This Magical Weapon can quickly change its form to adapt to both melee and ranged combat.", magicalWeapon.LongDescription);

    }

    [Test]

    public void TestAddIdentifier()
        {
            magicalWeapon.AddIdentifier("light shield");
            Assert.IsTrue(magicalWeapon.AreYou("light shield"));
        }



}
