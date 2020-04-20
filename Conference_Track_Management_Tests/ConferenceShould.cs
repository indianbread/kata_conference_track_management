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
        private ProposalDataFixture Fixture;
        
        public ConferenceShould(ProposalDataFixture fixture)
        {
            Fixture = fixture;
        }
        
        [Fact]
        public void CreateCorrectNumberOfTracksBasedOnTotalProposalDuration()
        {
            Assert.Equal(2, Fixture.Conference.Tracks.Count);
        }
        
        [Fact]
        public void AllocateProposalsToCoverMinTrackDuration()
        {
            foreach (var track in Fixture.Conference.Tracks)
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
            var actualProposalCount = Fixture.Conference.Tracks.Select(track => track.Proposals.Count).Sum();
            Assert.Equal(expectedProposalCount, actualProposalCount);
        }
        
        

    }
}