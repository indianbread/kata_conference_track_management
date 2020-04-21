using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class ConferenceManager : IConferenceManager
    {
        public ConferenceManager(ITrackManager trackManager) 
        {
            _trackManager = trackManager;
        }

        private ITrackManager _trackManager;
        public ConferenceTrackResult AllocateAllProposalsToConference(List<Proposal> proposals)
        {
            //validate if proposal list is null
            if (proposals is null || proposals.Count == 0) return ConferenceTrackResult.CreateError("No proposals to allocate");
            List<Track> tracks = _trackManager.CreateTracksForGivenProposals(proposals);

            //create a private method that returns an int which returns the amount of tracks required
            //pass the list of proposals to track manager to allocate, then return the list of unallocated proposals

            return ConferenceTrackResult.CreateSuccess(tracks);

        }
    }
}