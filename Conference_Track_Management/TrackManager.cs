using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class TrackManager : ITrackManager //what is the purpose of the interface?
    {
        public TrackManager()
        {
            _trackMaxDuration = 7 * 60;
            _trackMinDuration = 6 * 60;
            _lunchBreak = new Proposal("Lunch", 60);
        }
        
        private readonly int _trackMinDuration;
        private readonly int _trackMaxDuration;
        private readonly Proposal _lunchBreak;

        public List<Track> CreateTracksForGivenProposals(List<Proposal> proposals)
        {
            var proposalDuration = proposals.Sum(proposal => proposal.Duration);
            var numberOfTracksRequired = (int)Math.Ceiling((decimal)proposalDuration / _trackMaxDuration);
            var tracks = new List<Track>();
            for (var i = 1; i <= numberOfTracksRequired; i++)
            {
                Track track = new Track(i);
                tracks.Add(track);
            }

            return tracks;

        }
    }
}