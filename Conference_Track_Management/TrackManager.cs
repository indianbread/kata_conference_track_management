using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

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
                CreateMorningSession(track.GetStartTime(), morningSessionDuration, unallocatedProposals, track);
            var afternoonSessionStartTime = DateTime.Parse("1 PM");
            var startTime = afternoonSessionStartTime;
            foreach (var proposal in proposalsNotAllocatedToMorningSchedule)
            {
                track.Schedule.Add(startTime, proposal );
                startTime += ParseDurationToTimeSpan(proposal.Duration);
            }

            var networkingEvent = new Proposal("Networking Event");
            track.Schedule.Add(track.GetFinishTime(), networkingEvent);
        }

        private List<Proposal> CreateMorningSession(DateTime sessionStartTime, int sessionDuration, List<Proposal> proposals, Track track)
        {
            var unAllocatedProposals = proposals.ToList();
            var allocatedProposalDuration = 0;
            var startTime = sessionStartTime;
            if (unAllocatedProposals.Count(proposal => proposal.Duration == 45) < 2)
            {
                Allocate30Or60MinProposals(unAllocatedProposals, startTime, track.GetTotalProposalDuration(), track);

                return unAllocatedProposals;
            }
            foreach (var proposal in unAllocatedProposals.ToList())
            {
                if (allocatedProposalDuration == sessionDuration) break;
                if (proposal.Duration == 45 && allocatedProposalDuration < 90)
                {
                    track.Schedule.Add(startTime, proposal );
                    startTime += ParseDurationToTimeSpan(proposal.Duration);
                    unAllocatedProposals.Remove(proposal);
                    allocatedProposalDuration += proposal.Duration;
                    var nextTargetProposal = unAllocatedProposals.First(p => p.Duration == 45);
                    track.Schedule.Add(startTime, nextTargetProposal);
                    startTime += ParseDurationToTimeSpan(nextTargetProposal.Duration);
                    allocatedProposalDuration += nextTargetProposal.Duration;
                    unAllocatedProposals.Remove(nextTargetProposal);
                }
                if (proposal.Duration == 45 || proposal.Duration == 5) continue;
                if (proposal.Duration == 60 && allocatedProposalDuration > 120) continue;
                track.Schedule.Add(startTime, proposal );
                startTime += ParseDurationToTimeSpan(proposal.Duration);
                allocatedProposalDuration += proposal.Duration;
                unAllocatedProposals.Remove(proposal);
            }
            return unAllocatedProposals;
        }

        private void Allocate30Or60MinProposals(List<Proposal> unallocatedProposals, DateTime startTime,
            int durationToAllocate,
            Track track)
        {
            var allocatedProposalDuration = 0;
            var targetProposalsToAllocate = unallocatedProposals.Where(proposal => proposal.Duration % 30 == 0);
            foreach (var proposal in targetProposalsToAllocate.ToList())
            {
                if (allocatedProposalDuration == durationToAllocate) break;
                if ((allocatedProposalDuration += proposal.Duration) > durationToAllocate) continue;
                AddProposalToSchedule(unallocatedProposals, startTime, track, proposal);
                startTime = GetNextStartTime(startTime, proposal);
            }
        }

        private DateTime GetNextStartTime(DateTime currentStartTime, Proposal proposal)
        {
            var durationTimeSpan = ParseDurationToTimeSpan(proposal.Duration);
            var newStartTime = currentStartTime + durationTimeSpan;
            return newStartTime;

        }

        private void AddProposalToSchedule(List<Proposal> unallocatedProposals, DateTime startTime, Track track, Proposal proposal)
        {
            track.Schedule.Add(startTime, proposal);
            unallocatedProposals.Remove(proposal);
        }

        private TimeSpan ParseDurationToTimeSpan(int sessionDuration)
        {
            var durationTimeSpan = sessionDuration == 60
                ? TimeSpan.Parse("1:00:00")
                : TimeSpan.Parse($"0:{sessionDuration.ToString()}:00");
            return durationTimeSpan;
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