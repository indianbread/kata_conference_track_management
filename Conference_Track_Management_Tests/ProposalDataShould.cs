using Xunit;
using System;
using System.Collections.Generic;
using Conference_Track_Management;

namespace Conference_Track_Management_Tests
{
    public class ProposalDataShould
    {
        [Fact]
        public void GenerateAListOfProposals()
        {
            const string filePath = "/Users/nhan.dang/OneDrive - MYOB/Future-Makers-Academy/General_Developer/katas/kata-conference-track-management/kata_conference_track_management/Conference_Track_Management/Conference_Track_Management/Proposals.csv";
            var proposalsListString = ProposalData.GetProposalDataFromFile(filePath);
            
            Assert.Equal(19, ProposalData.GetAllProposals(proposalsListString).Count);
        }


    }
}