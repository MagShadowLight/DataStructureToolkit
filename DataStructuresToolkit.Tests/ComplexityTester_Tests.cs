using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace DataStructuresToolkit.Tests
{
    public class ComplexityTester_Tests
    {
        
        private string[] stringinput = new string[100000];
        private int[] numInput = new int[100000];
        private Random randomGenerator = new Random();
        private Stopwatch timer = new Stopwatch();
        private ComplexityTester complexity = new ComplexityTester();
        [SetUp]
        public void Init()
        {
            for (int i = 0; i < numInput.Length; i++)
            {
                numInput[i] = randomGenerator.Next(100);
            }
            for (int i = 0; i < stringinput.Length; i++)
            {
                stringinput[i] = "Test";
            }
        }
        [Test]
        public void Given_There_Are_Inputs_When_Running_Constant_Scenario_Then_It_Should_Succeed()
        {
            int index = 4;
            timer.Start();
            int result = complexity.RunConstantScenario(numInput, index);
            timer.Stop();
            TestContext.WriteLine($"n={numInput.Length}: {timer.Elapsed}");
            TestContext.WriteLine($"n={numInput.Length}: {timer.ElapsedMilliseconds}");
            Assert.NotNull(result);
        }
        [Test]
        public void Given_There_Are_Inputs_When_Running_Linear_Scenario_Then_It_Should_Succeed()
        {
            timer.Start();
            string result = complexity.RunLinearScenario(stringinput);
            timer.Stop();
            TestContext.WriteLine($"n={stringinput.Length}: {timer.Elapsed}");
            TestContext.WriteLine($"n={stringinput.Length}: {timer.ElapsedMilliseconds}");
            Assert.NotNull(result);
        }
        [Test]
        public void Given_There_Are_Inputs_When_Running_Quadratic_Scenario_Then_It_Should_Succeed()
        {
            timer.Start();
            bool result = complexity.RunQuadraticScenario(stringinput);
            timer.Stop();
            TestContext.WriteLine($"n={stringinput.Length}: {timer.Elapsed}");
            TestContext.WriteLine($"n={stringinput.Length}: {timer.ElapsedMilliseconds}");
            Assert.IsTrue(result);
        }
    }
}
