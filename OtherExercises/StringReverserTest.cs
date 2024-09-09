using FluentAssertions;

namespace OtherExercises
{
    public class StringReverserTest
    {
        [Fact]
        public void ItReversesAString()
        {
            String input = "arroz";

            String actualOutput = StringReverser.Reverse(input);

            actualOutput.Should().Be("zorra");
        }
    }
}