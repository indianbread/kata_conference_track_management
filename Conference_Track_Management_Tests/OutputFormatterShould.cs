using System;
using System.Collections.Generic;
using Conference_Track_Management;
using Xunit;

namespace Conference_Track_Management_Tests
{
    public class OutputFormatterShould
    {
        [Fact]
        public void FormatTrackScheduleInfo()
        {
            var track = new Track();
            track.Schedule.Add(DateTime.Parse("9 AM"), new Proposal("Writing Fast Tests Against Enterprise Rails", 60));
            track.Schedule.Add(DateTime.Parse("5 PM"), new Proposal("Networking Event", 0));

            var expectedSessionInfo = new List<string>() {"09:00AM Writing Fast Tests Against Enterprise Rails 60min", "12:00PM Lunch", "05:00PM Networking Event"};
            
            Assert.Equal(expectedSessionInfo, OutputFormatter.GenerateScheduleInfo(track));

        }

        [Fact]
        public void DisplayErrorMessageIfAllocationUnsuccessful()
        {
            ITrackManager trackManager = new TrackManager();
            IConferenceManager conferenceManager = new ConferenceManager(trackManager, new List<Proposal>());
            var expectedResult = "No proposals to allocate";
            var actualResult = OutputFormatter.GetAllocationResult(conferenceManager);
            
            Assert.Equal(expectedResult, actualResult);
        }
        
    }
}