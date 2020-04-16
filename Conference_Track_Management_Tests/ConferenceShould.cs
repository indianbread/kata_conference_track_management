using System;
using System.Collections.Generic;
using Conference_Track_Management;
using Xunit;

namespace Conference_Track_Management_Tests
{
    public class ConferenceShould
    {
        [Fact]
        public void CreateCorrectNumberOfTracksBasedOnTotalProposalDuration()
        {
            List<Proposal> proposals = ProposalData.GetAllProposals();
            var sut = new Conference("Test Conference", proposals);
            
            Assert.Equal(2, sut.Tracks.Count);
        }
        
        

    }
}