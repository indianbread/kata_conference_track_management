using System.Collections.Generic;
using Conference_Track_Management;
using Xunit;

namespace Conference_Track_Management_Tests
{
    [Collection("ProposalDataCollection")]
    public class ConferenceManagerShould
    {
        //2 scenarios - create success, create error

        public ConferenceManagerShould(ProposalDataFixture fixture)
        {
            _fixture = fixture;
            _trackManager = new TrackManager(_fixture.ProposalList);
            _conferenceManager = new ConferenceManager(_trackManager);
            
        }

        [Fact]
        public void DisplaysAnErrorMessageIfNoProposalsToAllocate()
        {
            var emptyProposalsList = new List<Proposal>();
            var errorMessage = "No proposals to allocate";
            ITrackManager testTrackManager = new TrackManager(emptyProposalsList);
            IConferenceManager sut = new ConferenceManager(testTrackManager);
            var actualResult = sut.AllocateAllProposalsToConference(emptyProposalsList);
            
            Assert.Equal(errorMessage, actualResult.ErrorMessage);
            Assert.False(actualResult.IsSuccess);
        }

        [Fact]
        public void ReturnsASuccessResultIfProposalsToAllocate()
        {
            var actualResult = _conferenceManager.AllocateAllProposalsToConference(_fixture.ProposalList);
            
            Assert.True(actualResult.IsSuccess);
            Assert.Equal(2, actualResult.Tracks.Count);
            
        }

        private IConferenceManager _conferenceManager;
        private ITrackManager _trackManager;
        private ProposalDataFixture _fixture;
    }
}