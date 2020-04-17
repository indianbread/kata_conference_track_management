using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class Track : ISessionInfo
    {
        public Track(int trackNumber)
        {
            TrackNumber = trackNumber;
        }

        public int TrackNumber;
        public List<Proposal> Proposals = new List<Proposal>();
        public SortedDictionary<DateTime, Proposal> Timetable = new SortedDictionary<DateTime, Proposal>() {{DateTime.Parse("12 PM"), new Proposal("Lunch", 60)}};

        public DateTime GetStartTime()
        {
            return DateTime.Parse("9 AM" );
        }

        public DateTime GetFinishTime()
        {
            throw new NotImplementedException();
        }

        public int GetTotalProposalDuration()
        {
            return Proposals.Sum(proposal => proposal.Duration);
        }
    }

    public enum Session
    {
        Morning, Afternoon
    }
}