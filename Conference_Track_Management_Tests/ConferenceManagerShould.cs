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
            _trackManager = new TrackManager();
            _conferenceManager = new ConferenceManager(_trackManager, _fixture.ProposalList);
            
        }

        [Fact]
        public void DisplaysAnErrorMessageIfNoProposalsToAllocate()
        {
            var emptyProposalsList = new List<Proposal>();
            var errorMessage = "No proposals to allocate";
            ITrackManager testTrackManager = new TrackManager();
            IConferenceManager sut = new ConferenceManager(testTrackManager, emptyProposalsList);
            var actualResult = sut.AllocateAllProposals();
            
            Assert.Equal(errorMessage, actualResult.ErrorMessage);
            Assert.False(actualResult.IsSuccess);
        }

        [Fact]
        public void ReturnsASuccessResultIfProposalsToAllocate()
        {
            var actualResult = _conferenceManager.AllocateAllProposals();
            
            Assert.True(actualResult.IsSuccess);
            Assert.Equal(2, actualResult.Tracks.Count);
            
        }

        private IConferenceManager _conferenceManager;
        private ITrackManager _trackManager;
        private ProposalDataFixture _fixture;
    }
}