using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class TrackManager : ITrackManager //what is the purpose of the interface?
    {
        public TrackManager(List<Proposal> proposals)
        {
            _trackMaxDuration = 7 * 60;
            _trackMinDuration = 6 * 60;
            _lunchBreak = new Proposal("Lunch", 60);
            _proposals = proposals;
        }

        private readonly int _trackMinDuration;
        private readonly int _trackMaxDuration;
        private readonly Proposal _lunchBreak;
        private List<Proposal> _proposals;

        
        public List<Track> GenerateTracksFromProposals(List<Proposal> proposals)
        {
            var unallocatedProposals = proposals; 
            var tracks = new List<Track>();
            while (unallocatedProposals != null && unallocatedProposals.Count > 0)
            {
                var track = AllocateProposalsToTrack(proposals);
                tracks.Add(track);
            }

            return tracks;
        }

        private Track AllocateProposalsToTrack(List<Proposal> proposals)
        {
            var unAllocatedProposals = proposals;
            var allocatedProposals = new List<Proposal>();
            var allocatedProposalDuration = allocatedProposals.Sum(p => p.Duration);
            foreach (var proposal in unAllocatedProposals)
            {
                if (allocatedProposalDuration + proposal.Duration > _trackMaxDuration) continue;
                allocatedProposals.Add(proposal);
                unAllocatedProposals.Remove(proposal);
            }

            return new Track() {Proposals = allocatedProposals};
        }

    }
}