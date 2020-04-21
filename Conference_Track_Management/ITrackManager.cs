using System.Collections.Generic;

namespace Conference_Track_Management
{
    public interface ITrackManager
    {

        List<Track> CreateTracksForGivenProposals(List<Proposal> proposals);
    }
}