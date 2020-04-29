using System;
using System.Collections.Generic;
using Conference_Track_Management;
using Xunit;

namespace Conference_Track_Management_Tests
{
    public class OutputFormatterShould
    {
        // [Fact]
        // public void NumberEachTrack()
        // {
        //     var tracks = new List<Track>() {new Track()};
        //     
        //     var sut = OutputFormatter.GetTrackInfo(tracks[0]);
        //     Assert.Equal("Track 1", OutputFormatter.GetTrackInfo(tracks[0]));
        // }

        [Fact]
        public void FormatTrackScheduleInfo()
        {
            var track = new Track();
            track.Schedule.Add(DateTime.Parse("9 AM"), new Proposal("Writing Fast Tests Against Enterprise Rails", 60));
            track.Schedule.Add(DateTime.Parse("5 PM"), new Proposal("Networking Event", 0));

            var expectedSessionInfo = new List<string>() {"09:00AM Writing Fast Tests Against Enterprise Rails 60min", "12:00PM Lunch", "05:00PM Networking Event"};
            
            Assert.Equal(expectedSessionInfo, OutputFormatter.GenerateScheduleInfo(track));

        }
        
    }
}