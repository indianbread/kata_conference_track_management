using System;

namespace Conference_Track_Management
{
    public static class ProposalParser
    {
        public static Tuple<string, int> SplitTopicFromDuration(string proposal)
        {
            const int durationDigitCount = 2;
            int durationIndex = proposal.IndexOf("min") - durationDigitCount;
            const int durationPhraseWithSpace = 6;             //xxmins
            string topic = proposal.Substring(0, proposal.Length - durationPhraseWithSpace);
            string durationString = proposal.Substring(durationIndex, 2);
            int duration = int.Parse(durationString);
            var parsedProposal = Tuple.Create(topic, duration);
            return parsedProposal;
            
        }
    }
}