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
        private readonly ITrackManager _sut;
        private List<Track> _tracks;
        private Track _track1;
        private Track _track2;

        public TrackManagerShould(ProposalDataFixture fixture)
        {
            _fixture = fixture;
            _sut = new TrackManager(_fixture.ProposalList);
            _tracks = _sut.GenerateTracksFromProposals();
            _track1 = _tracks[0];
            _track2 = _tracks[1];

        }

        [Fact]
        public void AllocateEnoughProposalsForExpectedDuration()
        {

            const int minTrackDurationMins = 6 * 60;
            const int maxTrackDurationMins = 7 * 60;

            Assert.True(_track1.GetTotalProposalDuration() >= minTrackDurationMins &&
                        _track1.GetTotalProposalDuration() <= maxTrackDurationMins);
            Assert.True(_track2.GetTotalProposalDuration() >= minTrackDurationMins &&
                        _track2.GetTotalProposalDuration() <= maxTrackDurationMins);
        }
        
        [Fact]
        public void CalculateFinishTimeBasedOnProposalDuration()
        {
            var expectedMinFinishTime = 1600;
            var expectedMaxFinishTime = 1700;

            var track1ActualFinishTime = _track1.GetFinishTime();
            var track2ActualFinishTime = _track2.GetFinishTime();

            Assert.True(track1ActualFinishTime >= expectedMinFinishTime &&
                        track1ActualFinishTime <= expectedMaxFinishTime);
            Assert.True(track2ActualFinishTime >= expectedMinFinishTime &&
                        track2ActualFinishTime <= expectedMaxFinishTime);
            
        }
        
        [Fact]
        public void AllocateAllProposals()
        {
            var actualProposalCount = _track1.Proposals.Count + _track2.Proposals.Count;
            Assert.Equal(19, actualProposalCount);
        }

        [Fact]
        public void Allocate3HoursDurationForMorningSession()
        {
            var actualtrack1duration = _track1.Schedule.Where(item => item.Key < 1200)
                .Sum(item => item.Value.Duration);
            
            var actualtrack2duration = _track2.Schedule.Where(item => item.Key < 1200)
                .Sum(item => item.Value.Duration);
            
            Assert.Equal(180, actualtrack1duration);
            Assert.Equal(180, actualtrack2duration);
            
        }
        
        [Fact]
        public void AllocateProposalsToTrackSchedule()
        {

            var track1Schedule = _track1.Schedule;
            var track2Schedule = _track2.Schedule;

            var lunchBreakNetworkingEventCount = 2;

            var track1ExpectedScheduleCount = _track1.Proposals.Count + lunchBreakNetworkingEventCount;
            var track2ExpectedScheduleCount = _track2.Proposals.Count + lunchBreakNetworkingEventCount;
            
            Assert.Equal(track1ExpectedScheduleCount, _track1.Schedule.Count);
            Assert.Equal(track2ExpectedScheduleCount, _track2.Schedule.Count);
            
        }




    }
}