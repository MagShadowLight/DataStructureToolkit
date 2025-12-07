using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class SimpleHashTable_Tests
    {
        SimpleHashTable hashTable;
        AssociativeHelpers associative;
        Stopwatch timer;
        [SetUp]
        public void Setup()
        {
            hashTable = new SimpleHashTable(5);
            timer = new Stopwatch();
        }

        [Test]
        public void Given_ThereAreNoValuesInHashTable_When_InsertingMultipleValuesInHashTable_Then_ItShouldContainsThoseValues()
        {
            timer.Start();
            hashTable.Insert(12);
            hashTable.Insert(22);
            hashTable.Insert(37);
            Assert.IsTrue(hashTable.Contains(12));
            Assert.IsTrue(hashTable.Contains(22));
            Assert.IsTrue(hashTable.Contains(37));
            Assert.IsFalse(hashTable.Contains(99));
            Assert.IsFalse(hashTable.Contains(50));
            timer.Stop();
            TestContext.WriteLine($"Contains 12? {hashTable.Contains(12)}");
            TestContext.WriteLine($"Contains 22? {hashTable.Contains(22)}");
            TestContext.WriteLine($"Contains 37? {hashTable.Contains(37)}");
            TestContext.WriteLine($"Contains 99? {hashTable.Contains(99)}");
            TestContext.WriteLine($"Contains 50? {hashTable.Contains(50)}");
            TestContext.WriteLine($"Time to insert value: {timer.Elapsed}");
            TestContext.WriteLine($"Time to insert value: {timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_ThereAreValuesInHashTable_When_PrintingTheValue_ThenItShouldPrintTheValueInCorrectBuckets()
        {
            timer.Start();
            hashTable.Insert(12);
            hashTable.Insert(22);
            hashTable.Insert(37);
            string actual = hashTable.PrintTable();
            Assert.That(actual, Does.Contain("12"));
            Assert.That(actual, Does.Contain("22"));
            Assert.That(actual, Does.Contain("37"));
            timer.Stop();
            TestContext.WriteLine(hashTable.PrintTable());
            TestContext.WriteLine($"Time to print table: {timer.Elapsed}");
            TestContext.WriteLine($"Time to print table: {timer.ElapsedMilliseconds} ms");
        }
    }
}
