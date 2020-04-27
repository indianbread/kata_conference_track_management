using System;
using System.Collections.Generic;
using System.Linq;
using Conference_Track_Management;
using Xunit;


namespace Conference_Track_Management_Tests
{
    [Collection("ProposalDataCollection")]
    public class TrackManagerShould
    {
        private ProposalDataFixture _fixture;

        public TrackManagerShould(ProposalDataFixture fixture)
        {
            _fixture = fixture;
            Sut = _fixture.TrackManager.GenerateTracksFromProposals(_fixture.ProposalList);
            
        }

        public List<Track> Sut;

        [Fact]
        public void ContainEnoughProposalsForExpectedDuration()
        {
            const int minTrackDurationMins = 6 * 60;
            const int maxTrackDurationMins = 7 * 60;

            var track1 = Sut[0];
            var track2 = Sut[1];

            Assert.True(track1.GetTotalProposalDuration() >= minTrackDurationMins &&
                        track1.GetTotalProposalDuration() <= maxTrackDurationMins);
            Assert.True(track2.GetTotalProposalDuration() >= minTrackDurationMins &&
                        track2.GetTotalProposalDuration() <= maxTrackDurationMins);
        }
        
        [Fact]
        public void CalculateFinishTimeBasedOnProposalDuration()
        {
            var track1 = Sut[0];
            var track2 = Sut[1];
            
            var expectedMinFinishTime = DateTime.Parse("4 PM");
            var expectedMaxFinishTime = DateTime.Parse("5 PM");

            var track1ActualFinishTime = track1.GetFinishTime();
            var track2ActualFinishTime = track2.GetFinishTime();

            Assert.True(track1ActualFinishTime >= expectedMinFinishTime &&
                        track1ActualFinishTime <= expectedMaxFinishTime);
            Assert.True(track2ActualFinishTime >= expectedMinFinishTime &&
                        track2ActualFinishTime <= expectedMaxFinishTime);


        }
        
        [Fact]
        public void IncludeAllProposalsInTimetable()
        {
            var track1 = Sut[0];
            var track2 = Sut[1];

            var actualProposalCount = track1.Proposals.Count + track2.Proposals.Count;
            Assert.Equal(19, actualProposalCount);
        }




    }
}