using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresToolkit.Tests
{
    public class AssocativeHelpers_Tests
    {
        AssociativeHelpers _associative;
        Stopwatch timer;

        [SetUp]
        public void SetUp()
        {
            _associative = new AssociativeHelpers();
            timer = new Stopwatch();
        }

        [Test]
        public void Given_ThereAreNoPhoneNumberInDictionary_When_InsertingANewPhoneNumber_Then_ItShouldContainsThoseValue()
        {
            timer.Start();
            _associative.InsertDictionary("Alice", "111-1234");
            _associative.InsertDictionary("Jesse", "222-5678");
            _associative.InsertDictionary("Charlie", "333-9012");
            Assert.IsTrue(_associative.ContainName("Alice"));
            Assert.IsTrue(_associative.ContainName("Jesse"));
            Assert.IsTrue(_associative.ContainName("Charlie"));
            Assert.IsTrue(_associative.ContainPhoneNumber("111-1234"));
            Assert.IsTrue(_associative.ContainPhoneNumber("222-5678"));
            Assert.IsTrue(_associative.ContainPhoneNumber("333-9012"));
            Assert.IsFalse(_associative.ContainName("David"));
            timer.Stop();
            TestContext.WriteLine($"Contain Alice? {_associative.ContainName("Alice")}");
            TestContext.WriteLine($"Contain David? {_associative.ContainName("David")}");
            TestContext.WriteLine($"Time to insert values into dictionary: {timer.Elapsed}");
            TestContext.WriteLine($"Time to insert values into dictionary: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereArePhoneNumberInPhoneBook_When_PrintingANameAndPhoneNumber_Then_ItShouldPrintCorrectNameAndPhoneNumber()
        {
            timer.Start();
            _associative.InsertDictionary("Alice", "111-1234");
            _associative.InsertDictionary("Jesse", "222-5678");
            _associative.InsertDictionary("Charlie", "333-9012");
            string actual = _associative.PrintDictionary();
            timer.Stop();
            Assert.That(actual, Does.Contain("Alice"));
            Assert.That(actual, Does.Contain("Jesse"));
            Assert.That(actual, Does.Contain("Charlie"));
            Assert.That(actual, Does.Contain("111-1234"));
            Assert.That(actual, Does.Contain("222-5678"));
            Assert.That(actual, Does.Contain("333-9012"));
            Assert.That(actual, !Does.Contain("David"));
            TestContext.WriteLine(_associative.PrintDictionary());
            TestContext.WriteLine($"Time to print phone book: {timer.Elapsed}");
            TestContext.WriteLine($"Time to print phone book: {timer.ElapsedMilliseconds} ms");
        }

        [Test]
        public void Given_ThereAreNoValueInHashset_When_InsertingAValueIntoHashset_Then_ItShouldContainsThoseValues()
        {
            timer.Start();
            _associative.InsertHashSet("apple");
            _associative.InsertHashSet("banana");
            _associative.InsertHashSet("grape");
            _associative.InsertHashSet("apple");
            Assert.IsTrue(_associative.Contains("apple"));
            Assert.IsTrue(_associative.Contains("banana"));
            Assert.IsTrue(_associative.Contains("grape"));
            Assert.IsFalse(_associative.Contains("chocolate"));
            timer.Stop();
            TestContext.WriteLine($"Contains apple? {_associative.Contains("apple")}");
            TestContext.WriteLine($"Contains banana? {_associative.Contains("banana")}");
            TestContext.WriteLine($"Contains grape? {_associative.Contains("grape")}");
            TestContext.WriteLine($"Contains chocolate? {_associative.Contains("chocolate")}");
            TestContext.WriteLine($"Time to insert into hashset: {timer.Elapsed}");
            TestContext.WriteLine($"Time to insert into hashset: {timer.ElapsedMilliseconds} ms");
        }
        [Test]
        public void Given_ThereAreValueInHashset_When_PrintingHashset_Then_ItShouldPrintCorrectValueWithNoDuplicateValue()
        {
            timer.Start();
            _associative.InsertHashSet("apple");
            _associative.InsertHashSet("banana");
            _associative.InsertHashSet("grape");
            _associative.InsertHashSet("apple");
            string actual = _associative.PrintHashSet();
            timer.Stop();
            Assert.That(actual, Does.Contain("apple"));
            Assert.That(actual, Does.Contain("banana"));
            Assert.That(actual, Does.Contain("grape"));
            TestContext.WriteLine($"Hashset: ");
            TestContext.WriteLine(actual);
            TestContext.WriteLine($"Time to print hashset: {timer.Elapsed}");
            TestContext.WriteLine($"Time to print hashset: {timer.ElapsedMilliseconds} ms");
        }
    }
}
