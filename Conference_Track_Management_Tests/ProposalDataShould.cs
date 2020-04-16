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
            Assert.Equal(19, ProposalData.GetAllProposals().Count);
        }
        
        
    }
}