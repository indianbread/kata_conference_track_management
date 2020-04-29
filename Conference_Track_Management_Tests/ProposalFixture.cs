using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Conference_Track_Management;
using Xunit;
using System.IO;

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
            string filePath = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}/App_Data/Proposals.csv";
            var proposalsListString = ProposalData.GetProposalDataFromFile(filePath);

            return ProposalData.GetAllProposals(proposalsListString);

        }

    }
}