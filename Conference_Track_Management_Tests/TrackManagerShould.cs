using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
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
            _sut = new TrackManager(_fixture.ProposalList);
            
        }

        private readonly ITrackManager _sut;

        [Fact]
        public void AllocateEnoughProposalsForExpectedDuration()
        {
            var tracks = _sut.GenerateTracksFromProposals();
            var track1 = tracks[0];
            var track2 = tracks[1];
            
            const int minTrackDurationMins = 6 * 60;
            const int maxTrackDurationMins = 7 * 60;

            Assert.True(track1.GetTotalProposalDuration() >= minTrackDurationMins &&
                        track1.GetTotalProposalDuration() <= maxTrackDurationMins);
            Assert.True(track2.GetTotalProposalDuration() >= minTrackDurationMins &&
                        track2.GetTotalProposalDuration() <= maxTrackDurationMins);
        }
        
        [Fact]
        public void CalculateFinishTimeBasedOnProposalDuration()
        {
            var tracks = _sut.GenerateTracksFromProposals();
            var track1 = tracks[0];
            var track2 = tracks[1];
            
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
        public void AllocateAllProposals()
        {
            var tracks = _sut.GenerateTracksFromProposals();
            var track1 = tracks[0];
            var track2 = tracks[1];

            var actualProposalCount = track1.Proposals.Count + track2.Proposals.Count;
            Assert.Equal(19, actualProposalCount);
        }

        [Fact]
        public void AllocateAProposalToAnEmptyScheduleSlot()
        {
            var tracks = _sut.GenerateTracksFromProposals();
            var track1 = tracks[0];
            var track2 = tracks[1];

//TODO: Assertion
        }

        [Fact(Skip = "Doesn't work at the moment")]
        public void AllocateAllProposalToTrackSchedule()
        {
            var tracks = _sut.GenerateTracksFromProposals();
            var track1 = tracks[0];
            var track2 = tracks[1];

            var lunchBreakNetworkingEventCount = 2;

            var track1ExpectedScheduleCount = track1.Proposals.Count + lunchBreakNetworkingEventCount;
            var track2ExpectedScheduleCount = track2.Proposals.Count + lunchBreakNetworkingEventCount;
            
            Assert.Equal(track1ExpectedScheduleCount, track1.Schedule.Count);
            Assert.Equal(track2ExpectedScheduleCount, track2.Schedule.Count);
            
        }




    }
}