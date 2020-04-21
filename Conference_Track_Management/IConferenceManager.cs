using System.Collections.Generic;

namespace Conference_Track_Management
{
    public interface IConferenceManager
    {
        ConferenceTrackResult AllocateAllProposalsToConference(List<Proposal> proposals);
    }
}