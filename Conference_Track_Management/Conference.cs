using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class Conference
    {

        private List<Proposal> _proposals { get; set; }
        public Conference(string name, List<Proposal> proposals)
        {
            Name = name;
            _proposals = proposals;
            Tracks = CreateTracksFromProposals();
        }

        public List<Track> Tracks = new List<Track>();
        
        public string Name { get; }
        
        private int CalculateDurationOfAllProposals()
        {
            int totalProposalDuration = 0;
            foreach (var proposal in _proposals)
            {
                totalProposalDuration += proposal.Duration;
            }

            return totalProposalDuration;
        }

        private List<Track> CreateTracksFromProposals()
        {
            int totalProposalDurationMins = CalculateDurationOfAllProposals();
            int numberOfTracksRequired = (int)Math.Ceiling((decimal)totalProposalDurationMins / trackMaxDurationMins);
            for (int i = 1; i <= numberOfTracksRequired; i++)
            {
                Track track = new Track(i);
                Tracks.Add(track);
            }
            AssignProposalsToTracks();
            return Tracks;
        }

        private void AssignProposalsToTracks()
        {
            Random random = new Random();
            int numOfProposals = _proposals.Count;
            var availableIndexes = Enumerable.Range(0, numOfProposals).ToList();
            foreach (var track in Tracks)
            {
                AssignProposalsToTrackForMinDuration(random, numOfProposals, availableIndexes, track);
            }

            if (!availableIndexes.Any()) return;
            AssignRemainingProposalsToTrack(availableIndexes);
        }

        private void AssignRemainingProposalsToTrack(List<int> availableIndexes)
        {
            foreach (var index in availableIndexes)
            {
                var trackWithAvailableSlot = Tracks.Find(trackItem
                    =>
                    ((trackItem.GetTotalProposalDuration() + _proposals[index].Duration) <=
                     trackMaxDurationMins));
                if (trackWithAvailableSlot == null)
                {
                    throw new ArgumentException("Unable to allocate all proposals to tracks");
                }
                trackWithAvailableSlot.Proposals.Add(_proposals[index]);
            }
        }

        private void AssignProposalsToTrackForMinDuration(Random random, int numOfProposals, List<int> availableIndexes, Track track)
        {
            do
            {
                int randomIndex;
                do
                {
                    randomIndex = random.Next(0, numOfProposals);
                } while (!availableIndexes.Contains(randomIndex));

                availableIndexes.Remove(randomIndex);
                track.Proposals.Add(_proposals[randomIndex]);
            } while (track.Proposals.Sum(proposal => proposal.Duration) < trackMinDurationMins);
        }


        private const int trackMinDurationMins = 6 * 60 ;
        private const int trackMaxDurationMins = 7 * 60;
    }

}