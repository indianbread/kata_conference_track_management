using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class ConferenceManager : IConferenceManager
    {
        public ConferenceManager(ITrackManager trackManager, List<Proposal> proposals) //use interface so it's easier to test later on - using test doubles
        {
            _trackManager = trackManager;
            Proposals = proposals;
        }

        private ITrackManager _trackManager;
        public List<Proposal> Proposals { get; private set; }
        public ConferenceTrackResult AllocateAllProposals()
        {
            if (Proposals is null || Proposals.Count == 0) return ConferenceTrackResult.CreateError("No proposals to allocate");
            List<Track> tracks = _trackManager.GenerateTracksFromProposals(Proposals);
            
            return ConferenceTrackResult.CreateSuccess(tracks);

        }
        
    }
}