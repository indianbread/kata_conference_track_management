using System;

namespace Conference_Track_Management
{
    public static class ProposalParser
    {
        public static Tuple<string, int> SplitTopicFromDuration(string proposal)
        {
            Tuple<string, int> proposalDetails = null;

            if (proposal.Contains("lightning"))
            {
                proposalDetails =  GetLightningTalkDetails(proposal);
            }

            if (proposal.Contains("min"))
            {
                proposalDetails = GetRegularTalkDetails(proposal);
            }

            return proposalDetails;
        }

        private static Tuple<string, int> GetLightningTalkDetails(string proposal)
        {
            string lightningString = " lightning";
            string topic = proposal.Substring(0, proposal.Length - lightningString.Length);
            return Tuple.Create<string, int>(topic, 5);
            
        }

        private static Tuple<string, int> GetRegularTalkDetails(string proposal)
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