using System;

namespace Conference_Track_Management
{
    public static class ProposalParser
    {
        public static Proposal GenerateProposal(string proposal)
        {
            Proposal proposalDetails = null;

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

        private static Proposal GetLightningTalkDetails(string proposal)
        {
            string lightningString = " lightning";
            string topic = proposal.Substring(0, proposal.Length - lightningString.Length);
            return new Proposal(topic, LightningTalkDuration);
            
        }

        private static Proposal GetRegularTalkDetails(string proposal)
        {
            const int durationDigitCount = 2;
            int durationIndex = proposal.LastIndexOf("min", StringComparison.Ordinal) - durationDigitCount;
            const int durationPhraseWithSpace = 6;             //xxmins
            string topic = proposal.Substring(0, proposal.Length - durationPhraseWithSpace);
            string durationString = proposal.Substring(durationIndex, durationDigitCount);
            int duration = int.Parse(durationString);
            var parsedProposal = new Proposal(topic, duration);
            return parsedProposal;
        }

        private const int LightningTalkDuration = 5;
    }

  
}