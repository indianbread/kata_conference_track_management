using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class ConferenceManager : IConferenceManager
    {
        public ConferenceManager(ITrackManager trackManager) //use interface so it's easier to test later on - using test doubles
        {
            _trackManager = trackManager;
        }

        private ITrackManager _trackManager;
        public ConferenceTrackResult CreateSchedule(List<Proposal> proposals)
        {
            if (proposals is null || proposals.Count == 0) return ConferenceTrackResult.CreateError("No proposals to allocate");
            List<Track> tracks = _trackManager.GenerateTracksFromProposals(proposals);
            
            return ConferenceTrackResult.CreateSuccess(tracks);

        }


        public ConferenceTrackResult AllocateAllProposalsToConference(List<Proposal> proposals)
        {
            throw new System.NotImplementedException();
        }
    }
}