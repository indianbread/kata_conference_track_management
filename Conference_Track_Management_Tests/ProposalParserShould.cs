using System;
using Xunit;
using Conference_Track_Management;

namespace Conference_Track_Management_Tests
{
    public class ProposalParserShould
    {
        [Theory]
        [InlineData("Writing Fast Tests Against Enterprise Rails 60min", "Writing Fast Tests Against Enterprise Rails", 60)]
        [InlineData("Rails for Python Developers lightning", "Rails for Python Developers", 5)]
        public void SplitStringIntoTopicAndDuration(string proposal, string topic, int duration)
        {
            var expected = new Tuple<string, int>(topic, duration);
            var actual = ProposalParser.SplitTopicFromDuration(proposal);
            
            Assert.Equal(expected, actual);

        }
    }
}