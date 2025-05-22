using NUnit.Framework;
using Swin_Adventure;

namespace Swin_Adventure.Tests
{
    [TestFixture]
    public class MoveCommandTests
    {
        private MoveCommand _moveCommand;
        private Player _player;
        private Location _room1;
        private Location _room2;
        private Path _path;

        [SetUp]
        public void Setup()
        {
            _moveCommand = new MoveCommand();
            _player = new Player("John", "A player");
            _room1 = new Location(new string[] { "room1" }, "Room 1", "First room");
            _room2 = new Location(new string[] { "room2" }, "Room 2", "Second room");
            _path = new Path(new string[] { "north" }, "North Path", "A path leading north", _room1, _room2);
            _room1.AddPath(_path);
            _player.Location = _room1;
        }

        [Test]
        public void TestMoveCommandIdentifiers()
        {
            Assert.That(_moveCommand.AreYou("move"), Is.True);
            Assert.That(_moveCommand.AreYou("go"), Is.True);
            Assert.That(_moveCommand.AreYou("head"), Is.True);
            Assert.That(_moveCommand.AreYou("leave"), Is.True);
            Assert.That(_moveCommand.AreYou("walk"), Is.False);
        }

        [Test]
        public void TestMoveCommandWithValidDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "north" });
            Assert.That(_player.Location, Is.EqualTo(_room2));
            Assert.That(result, Is.EqualTo("You have moved north to Room 2"));
        }

        [Test]
        public void TestMoveCommandWithInvalidDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "south" });
            Assert.That(_player.Location, Is.EqualTo(_room1));
            Assert.That(result, Is.EqualTo("I cannot find the south path"));
        }

        [Test]
        public void TestMoveCommandWithNoDirection()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move" });
            Assert.That(_player.Location, Is.EqualTo(_room1));
            Assert.That(result, Is.EqualTo("Move where?"));
        }

        [Test]
        public void TestMoveCommandWithDifferentCommandWords()
        {
            string[] commands = { "go", "head", "leave" };
            foreach (string cmd in commands)
            {
                string result = _moveCommand.Execute(_player, new string[] { cmd, "north" });
                Assert.That(_player.Location, Is.EqualTo(_room2));
                Assert.That(result, Is.EqualTo($"You have moved north to Room 2"));
                _player.Location = _room1; // Reset for next test
            }
        }
    }
} 