using System;
using System.Collections.Generic;

namespace Conference_Track_Management
{
    public interface ITrackManager
    {
        //put methods here that i want to expose to conference manager

        List<Track> GenerateTracksFromProposals(List<Proposal> proposals);
        
    }
}