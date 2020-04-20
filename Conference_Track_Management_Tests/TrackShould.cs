using System.Linq;
using Xunit;

namespace Conference_Track_Management_Tests
{
    [Collection("ProposalDataCollection")]
    public class TrackShould
    {
        private ProposalDataFixture _fixture;

        public TrackShould(ProposalDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ContainEnoughProposalsForExpectedDuration()
        {
            const int minTrackDurationMins = 6 * 60;
            const int maxTrackDurationMins = 7 * 60;

            var actualDurationOfFirstTrack = _fixture.Conference.Tracks[0].GetTotalProposalDuration();
            var actualDurationOfSecondTrack = _fixture.Conference.Tracks[1].GetTotalProposalDuration();

            Assert.True(actualDurationOfFirstTrack >= minTrackDurationMins &&
                        actualDurationOfFirstTrack <= maxTrackDurationMins);
            Assert.True(actualDurationOfSecondTrack >= minTrackDurationMins &&
                        actualDurationOfFirstTrack <= maxTrackDurationMins);
        }

        [Fact]
            public void IncludeAllProposalsInTimetable()
            {
                var sut = _fixture.Conference.Tracks[0];
                var expectedProposalCount = _fixture.Conference.Tracks[0].Proposals.Count;
                Assert.Equal(expectedProposalCount, sut.Timetable.Count);

            }

            [Fact]
            public void CalculateFinishTimeBasedOnProposalDuration()
            {


            }




    }
}