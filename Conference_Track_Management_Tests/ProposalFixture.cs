using System.Collections.Generic;
using Conference_Track_Management;
using Xunit;

namespace Conference_Track_Management_Tests
{
    public class ProposalDataFixture
    {
        public ProposalDataFixture()
        {
            ProposalList = GetProposalData();

        }

        public List<Proposal> ProposalList = new List<Proposal>();

        private List<Proposal> GetProposalData()
        {
            const string filePath = "/Users/nhan.dang/OneDrive - MYOB/Future-Makers-Academy/General_Developer/katas/kata-conference-track-management/kata_conference_track_management/Conference_Track_Management/Conference_Track_Management/Proposals.csv";

            var proposalsListString = ProposalData.GetProposalDataFromFile(filePath);

            return ProposalData.GetAllProposals(proposalsListString);

        }

    }
}