using System;
using System.Collections.Generic;

namespace Conference_Track_Management
{
    public class Conference
    {
        public Conference(string name, List<Proposal> proposals)
        {
            Name = name;
            _proposals = proposals;
            Tracks = CreateTracksFromProposals();
        }

        public List<Track> Tracks = new List<Track>();
        
        public string Name { get; }
        private List<Proposal> _proposals { get; set; }

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
            int numberofTracksRequired = totalProposalDurationMins / trackMaxDurationMins;
            for (int i = 1; i <= numberofTracksRequired; i++)
            {
                Track track = new Track(i);
                Tracks.Add(track);
            }

            return Tracks;
        }
        
            
        private const int trackMinDurationMins = 6 * 60 ;
        private const int trackMaxDurationMins = 7 * 60;
    }

}