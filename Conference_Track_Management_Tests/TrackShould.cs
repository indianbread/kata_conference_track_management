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


    }
}