using System.Collections.Generic;
using System.IO;

namespace Conference_Track_Management
{
    public static class ProposalData
    {
        private static string[] GetProposalDataFromFile()
        {
            string filePath =
                "/Users/nhan.dang/OneDrive - MYOB/Future-Makers-Academy/General_Developer/katas/kata-conference-track-management/kata_conference_track_management/Conference_Track_Management/Conference_Track_Management/Proposals.csv";
            string[] proposalList = File.ReadAllLines(filePath);
            return proposalList;
        }

        public static List<Proposal> GetAllProposals()
        {
            List<Proposal> proposals = new List<Proposal>();
            string[] proposalsListString = GetProposalDataFromFile();
            foreach (var proposalString in proposalsListString)
            {
                var proposal = ProposalParser.GenerateProposal(proposalString);
                proposals.Add(proposal);
            }
            
            return proposals;
        }
    }
}