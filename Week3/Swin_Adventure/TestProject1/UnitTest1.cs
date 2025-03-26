using Swin_Adventure;
using NUnit.Framework;

namespace TestProject1;


public class Tests
{
    private IdentifiableObject identifiableObject;
    [SetUp]
    public void Setup()
    {
    identifiableObject = new IdentifiableObject(new string[] {"007", "James", "Bond"}); 
    }

    [Test]
    public void TestAreYou ()
    {
        Assert.IsTrue(identifiableObject.AreYou("007"));

    }

    [Test]
    public void TestNotAreYou(){
         Assert.IsFalse(identifiableObject.AreYou("5442"));
    }

    [Test]
    public void TestCaseSensitive(){
         Assert.IsTrue(identifiableObject.AreYou("jaMEs"));
    }

    [Test]

    public void TestFirstID (){

        Assert.AreEqual("007",identifiableObject.FirstId);
    }

    [Test]

    public void TestFirstWithNoIDs (){

        identifiableObject.RemoveIdentifier("007");
        identifiableObject.RemoveIdentifier("James");
        identifiableObject.RemoveIdentifier("Bond");
        Assert.AreEqual(string.Empty,identifiableObject.FirstId);
    }
    
    public void TestAddIdentifier()
    {
        identifiableObject.AddIdentifier("NewID");
        Assert.IsTrue(identifiableObject.AreYou("newid"));
    }

    [Test]
    public void TestPrivilegeEscalation()
    {
        identifiableObject.PrivilegeEscalation("5442");
        Assert.AreEqual("COS20007".ToLower(), identifiableObject.FirstId);
    }
}
