using System;
using System.Collections.Generic;
using System.Linq;

namespace Conference_Track_Management
{
    public class Track : ISessionInfo
    {
        
        public int TrackNumber { get; set; }
        public List<Proposal> Proposals { get; set; }
        public SortedDictionary<int, Proposal> Schedule = new SortedDictionary<int, Proposal>()
        {
            {1200, new Proposal("Lunch", 60)},
            
        };

        public int GetStartTime()
        {
            return 0900;
        }

        public int GetFinishTime()
        {
            var totalProposalDuration = GetTotalProposalDuration();
            var lunchBreakDuration = 60;
            var finishTime = GetStartTime() + totalProposalDuration + lunchBreakDuration;
            return finishTime;
        }

        public int GetTotalProposalDuration()
        {
            return Proposals.Sum(proposal => proposal.Duration);
        }

        public bool IsSessionAvailable(int time)
        {
            return !Schedule.ContainsKey(time);
        }

        public static int ConvertToHoursAndMins(int mins)
        {
            var numOfHours = mins / 60;
            var numOfHoursString = numOfHours.ToString().Length == 2 ? $"{numOfHours}" : $"0{numOfHours}";
            var numOfMins = mins - (numOfHours * 60);
            var numOfMinsString = numOfMins.ToString().Length == 2
                ? $"{numOfMins}" : $"0{numOfMins}";
            var parsedTime = int.Parse(numOfHoursString +numOfMinsString);
            return parsedTime;
        }

        public static int FormatIntegerTime(int time)
        {
            var mins = time >= 1000 ? time % 100 : time % 10;
            if (mins >= 60)
            {
                var parsedMin = ConvertToHoursAndMins(mins);
                time += parsedMin;
            }

            return time;

        }
    }

}