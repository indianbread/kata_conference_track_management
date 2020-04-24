using System.Collections.Generic;
using Xunit;
using Conference_Track_Management;


namespace Conference_Track_Management_Tests.App_Data
{
    [Collection("ProposalDataCollection")]
    public class TrackShould
    {
        private ProposalDataFixture _fixture;
        private List<Track> _sut = new List<Track>();

        public TrackShould(ProposalDataFixture fixture)
        {
            _fixture = fixture;
            _sut = new TrackManager(_fixture.ProposalList).GenerateTracksFromProposals();


        }
        
        
    }
}