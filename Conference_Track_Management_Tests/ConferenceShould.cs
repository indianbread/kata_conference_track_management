using System;
using System.Collections.Generic;
using System.Linq;
using Conference_Track_Management;
using Xunit;

namespace Conference_Track_Management_Tests
{
    [Collection("ProposalDataCollection")]
    public class ConferenceShould
    {
        public ProposalDataFixture Fixture;
        
        public ConferenceShould(ProposalDataFixture fixture)
        {
            Fixture = fixture;
            Sut = new Conference("Test Conference", Fixture.ProposalList);

        }

        public Conference Sut;
        
        [Fact]
        public void CreateCorrectNumberOfTracksBasedOnTotalProposalDuration()
        {
            Assert.Equal(2, Sut.Tracks.Count);
        }
        
        [Fact]
        public void AllocateProposalsToCoverMinTrackDuration()
        {
            foreach (var track in Sut.Tracks)
            {
                const int minTrackDuration = 6 * 60;
                const int maxTrackDuration = 7 * 60;
                var actualTrackProposalDuration = track.Proposals.Sum(proposal => proposal.Duration);
                Assert.True( actualTrackProposalDuration >= minTrackDuration && actualTrackProposalDuration <= maxTrackDuration  );

            }

        }

        [Fact]
        public void AllocateAllProposals()
        {
            var expectedProposalCount = Fixture.ProposalList.Count;
            var actualProposalCount = Sut.Tracks.Select(track => track.Proposals.Count).Sum();
            Assert.Equal(expectedProposalCount, actualProposalCount);
        }
        
        

    }
}