using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class TrackManager : ITrackManager
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

        
        public List<Track> GenerateTracksFromProposals()
        {
            var unallocatedProposals = _proposals.ToList(); 
            var tracks = new List<Track>();
            while (unallocatedProposals != null && unallocatedProposals.Count > 0)
            {
                var track = AllocateProposalsToTrack(unallocatedProposals);
                CreateTrackSchedule(track);
                tracks.Add(track);
            }

            return tracks;
        }
        

        private void CreateTrackSchedule(Track track)
        {
            var unallocatedProposals = track.Proposals.ToList();
            const int morningSessionDuration = 3 * 60;
            var proposalsNotAllocatedToMorningSchedule =
                CreateSessionSchedule(track.GetStartTime(), morningSessionDuration, unallocatedProposals, track);
            var afternoonSessionDuration = proposalsNotAllocatedToMorningSchedule.Sum(proposal => proposal.Duration);
            var afternoonSchedule = CreateSessionSchedule(DateTime.Parse("1 PM"), afternoonSessionDuration,
                proposalsNotAllocatedToMorningSchedule, track);
            var networkingEvent = new Proposal("Networking Event");
            track.Schedule.Add(track.GetFinishTime(), networkingEvent);
        }

        private List<Proposal> CreateSessionSchedule(DateTime sessionStartTime, int sessionDuration, List<Proposal> proposals, Track track)
        {
            //TODO: fix the scheduling - there is a gap between last morning session & lunch time
            var unAllocatedProposals = proposals.ToList();
            var allocatedProposalDuration = 0;
            var startTime = sessionStartTime;
            foreach (var proposal in unAllocatedProposals.ToList())
            {
                if (allocatedProposalDuration == sessionDuration) break;
                if (allocatedProposalDuration + proposal.Duration > sessionDuration) continue;
                track.Schedule.Add(startTime, proposal);
                allocatedProposalDuration += proposal.Duration;
                var timeSpanDuration = proposal.Duration == 60
                    ? TimeSpan.Parse($"1:00:00")
                    : TimeSpan.Parse($"0:{proposal.Duration.ToString()}:00");
                startTime += timeSpanDuration;
                unAllocatedProposals.Remove(proposal);
            }
            return unAllocatedProposals;
        }


        private Track AllocateProposalsToTrack(List<Proposal> proposals)
        {
            var unAllocatedProposals = proposals;
            var allocatedProposals = new List<Proposal>();
            var allocatedProposalDuration = 0;
            foreach (var proposal in unAllocatedProposals.ToList())
            {
                if (allocatedProposalDuration == _trackMaxDuration) break;
                if (allocatedProposalDuration + proposal.Duration > _trackMaxDuration) continue;
                allocatedProposals.Add(proposal);
                allocatedProposalDuration += proposal.Duration;
                unAllocatedProposals.Remove(proposal);
            }

            return new Track() {Proposals = allocatedProposals};
        }
        
    }
}