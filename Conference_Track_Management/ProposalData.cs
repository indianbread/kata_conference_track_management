using System;
using System.Collections.Generic;
using System.IO;

namespace Conference_Track_Management
{
    public static class ProposalData
    {
        public static string[] GetProposalDataFromFile(string filePath)
        {
            string[] proposalList = File.ReadAllLines(filePath);
            return proposalList;
        }

        public static List<Proposal> GetAllProposals(string[] proposalStringList)
        {
            List<Proposal> proposals = new List<Proposal>();
            string[] proposalsListString = proposalStringList;
            foreach (var proposalString in proposalsListString)
            {
                var proposal = ProposalParser.GenerateProposal(proposalString);
                proposals.Add(proposal);
            }
            
            return proposals;
        }
    }
}