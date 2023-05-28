using NUnit.Framework;
using System;
using System.Linq;

namespace Database.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(5)]
        [TestCase(16)]
        [TestCase(0)]
        [TestCase(1)]
        public void AddMethodShouldAddAllIntegersWhileBelow16(int count)
        {
            var database = new Database();
            for (int i = 0; i < count; i++)
            {
                database.Add(i);
            }
            Assert.AreEqual(count, database.Count);
        }

        [Test]
        public void AddMethodShouldNotBeOver16()
        {
            var database = new Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(7));
        }

        [TestCase(1, 3)]
        [TestCase(1, 16)]
        [TestCase(1, 8)]
        public void ConstructorShouldAddAllIntegersWhileBelow16(int startIndex, int count)
        {
            int[] arr = Enumerable.Range(startIndex, count).ToArray();

            var database = new Database(arr);

            Assert.AreEqual(count, database.Count);
        }

        [TestCase(1, 17)]
        [TestCase(1, 30)]
        [TestCase(1, 19)]
        public void ConstructorShouldThrowExceptionWhenIntsAreAbove16(int startIndex, int count)
        {
            int[] arr = Enumerable.Range(startIndex, count).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [TestCase(1, 10)]
        [TestCase(1, 16)]
        [TestCase(1, 1)]
        public void RemoveMethodShouldRemoveElementsWhileAbove0(int startIndex, int count)
        {
            int[] arr = Enumerable.Range(startIndex, count).ToArray();

            var database = new Database(arr);

            database.Remove();
            Assert.AreEqual(count - 1, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenIntegersAre0()
        {
            var database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase(1, 3, 3, 2)]
        [TestCase(1, 1, 3, 2)]
        [TestCase(1, 5, 3, 2)]
        public void FetchMethodShouldReturnAllValidValues(int start, int count, int elementsToAdd, int elementsToRemove)
        {
            int[] arr = Enumerable.Range(start, count).ToArray();
            var database = new Database(arr);

            for (int i = 0; i < elementsToAdd; i++)
            {
                database.Add(i + 6);
            }

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            int[] fetchedDatabase = database.Fetch().ToArray();

            Assert.AreEqual(fetchedDatabase.Length, database.Count);
        }
    }
}