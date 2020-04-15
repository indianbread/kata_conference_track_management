using System;

namespace Conference_Track_Management
{
    public class Proposal
    {
        public Proposal(Tuple<string, int> parsedProposal)
        {
            Topic = parsedProposal.Item1;
            Duration = parsedProposal.Item2;
        }

        public string Topic;
        public int Duration;
        
        
    }
}