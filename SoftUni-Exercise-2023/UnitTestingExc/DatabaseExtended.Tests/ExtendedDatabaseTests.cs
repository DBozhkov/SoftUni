using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace DatabaseExtended.Tests
{

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database extendedDB;

        [SetUp]
        public void Setup()
        {
            extendedDB = new Database();
        }

        [Test]
        public void CtorShouldThrowExceptionWhenDbCapacityIsExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            Assert.Throws<ArgumentException>(() =>
            extendedDB = new Database(arguments));
        }

        [Test]
        public void CtorShouldAddInitialPeopleToDB()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }

            extendedDB = new Database(arguments);

            Assert.AreEqual(extendedDB.Count, arguments.Length);

            foreach (var person in arguments)
            {
                Person dbPerson = extendedDB.FindById(person.Id);
                Assert.AreEqual(person, dbPerson);
            }
        }

        [Test]
        public void AddShoulThrowExceptionWhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDB.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            extendedDB.Add(new Person(5, "InvalidUserName")));
        }

        [Test]
        public void AddShoulThrowExceptionWhenUserNameIsAlreadyAdded()
        {
            extendedDB.Add(new Person(1, "SU"));

            Assert.Throws<InvalidOperationException>(() =>
            extendedDB.Add(new Person(2, "SU")));
        }

        [Test]
        public void AddShoulThrowExceptionWhenIdIsAlreadyExists()
        {
            int id = 5;
            extendedDB.Add(new Person(id, "User1"));

            Assert.Throws<InvalidOperationException>(() =>
            extendedDB.Add(new Person(id, "User2")));
        }

        [Test]
        public void AddShoulIncreasedCounterWhenPeopleAreValid()
        {
            extendedDB.Add(new Person(1, "User1"));
            extendedDB.Add(new Person(2, "User2"));

            int expectedCount = 2;

            Assert.AreEqual(extendedDB.Count, expectedCount);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDBIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.Remove());
        }

        [Test]
        public void RemoveShouldRemoveElementFromDB()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                extendedDB.Add(new Person(i, $"Username{i}"));
            }

            extendedDB.Remove();

            Assert.AreEqual(extendedDB.Count, n - 1);

            Assert.Throws<InvalidOperationException>(() => extendedDB.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserNameShouldThrowExeptionWhenArgumentIsNotValid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDB.FindByUsername(username));
        }

        [Test]
        public void FindByUserNameShouldThrowExeptionWhenUsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindByUsername("Username"));
        }

        [Test]
        public void FindByUsernameShouldReturnExpectedUserWhenHeExist()
        {
            Person person = new Person(777, "Mitko");
            extendedDB.Add(person);

            Person dbPerson = extendedDB.FindByUsername(person.UserName);

            Assert.AreEqual(person, dbPerson);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindByIdShouldThrowExeptionWhenIdIsLessThanZero(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDB.FindById(id));
        }

        [Test]
        public void FindByIdShouldThrowExeptionWhenUserWithIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindById(100));
        }

        [Test]
        public void FindIdShouldReturnExpectedUserWhenUserExists()
        {
            Person person = new Person(1, "Mitko");
            extendedDB.Add(person);

            Person dbPerson = extendedDB.FindById(person.Id);

            Assert.AreEqual(person, dbPerson);
        }
    }
}
