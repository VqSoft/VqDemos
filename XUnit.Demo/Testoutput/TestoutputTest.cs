using System;
using Xunit;
using Xunit.Abstractions;


namespace XUnit.Demo.Testoutput
{
    public class TestoutputTest
    {
        ITestOutputHelper output;

        public TestoutputTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestThis()
        {
            output.WriteLine("I'm inside the test!");
        }
    }
}
