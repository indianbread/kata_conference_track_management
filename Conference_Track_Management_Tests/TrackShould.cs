using System;
using System.Collections.Generic;
using Xunit;
using Conference_Track_Management;


namespace Conference_Track_Management_Tests.App_Data
{
    [Collection("ProposalDataCollection")]
    public class TrackShould
    {
        public TrackShould(ProposalDataFixture fixture)
        {
            _fixture = fixture;
            sut = new Track();
        }

        public Track sut;
        private ProposalDataFixture _fixture;

        [Fact]
        public void StartAt9AM()
        {
            var expectedStartTime = DateTime.Parse("9 AM");
            Assert.Equal(expectedStartTime, sut.GetStartTime());
        }

        [Fact]
        public void CalculateFinishTimeBasedOnProposalDuration()
        {
            var proposal1 = _fixture.ProposalList[0]; //60 min
            var proposal2 = _fixture.ProposalList[1]; // 45 min
            
            sut.Proposals = new List<Proposal>();
            
            sut.Proposals.Add(proposal1);
            sut.Proposals.Add(proposal2);

            var expectedFinishTime = DateTime.Parse("11:45 AM"); //proposals + lunch
            
            Assert.Equal(expectedFinishTime, sut.GetFinishTime());

        }
        
        [Fact]
        public void CalculateTotalProposalDuration()
        {
            var proposal1 = _fixture.ProposalList[0]; //60 min
            var proposal2 = _fixture.ProposalList[1]; // 45 min
            
            sut.Proposals = new List<Proposal>();
            
            sut.Proposals.Add(proposal1);
            sut.Proposals.Add(proposal2);

            var expectedTotalDuration = 105;
            
            Assert.Equal(expectedTotalDuration, sut.GetTotalProposalDuration());

        }

    }
}