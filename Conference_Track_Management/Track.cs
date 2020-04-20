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
        public SortedDictionary<DateTime, Proposal> Timetable = new SortedDictionary<DateTime, Proposal>()
        {
            {DateTime.Parse("12 PM"), new Proposal("Lunch", 60)},
            
        };

        public DateTime GetStartTime()
        {
            return DateTime.Parse("9 AM" );
        }

        public DateTime GetFinishTime()
        {
            var totalProposalDuration = new TimeSpan(0, GetTotalProposalDuration(), 0);
            var lunchBreakDuration = new TimeSpan(1,0,0 );
            var finishTime = GetStartTime() + totalProposalDuration + lunchBreakDuration;
            return finishTime;
        }

        public int GetTotalProposalDuration()
        {
            return Proposals.Sum(proposal => proposal.Duration);
        }
        
    }

}