using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class Track : ISessionInfo
    {
        
        public int TrackNumber { get; set; }
        public List<Proposal> Proposals { get; set; }
        public SortedDictionary<DateTime, Proposal> Schedule = new SortedDictionary<DateTime, Proposal>()
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
            var lunchBreakDuration = new TimeSpan(0,60,0 );
            var finishTime = GetStartTime() + totalProposalDuration + lunchBreakDuration;
            return finishTime;
        }

        public int GetTotalProposalDuration()
        {
            return Proposals.Sum(proposal => proposal.Duration);
        }
        
    }

}