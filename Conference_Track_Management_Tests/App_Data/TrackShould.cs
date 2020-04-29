using System;
using System.Collections.Generic;
using Xunit;
using Conference_Track_Management;


namespace Conference_Track_Management_Tests.App_Data
{
    public class TrackShould
    {

        private Track _sut;

        public TrackShould()
        {
            _sut = new Track();

        }

        [Fact]
        public void DetermineIfScheduleSlotIsNotAvailable()
        {
            var lunchTime = DateTime.Parse("12 PM");
            
            Assert.False(_sut.IsSessionAvailable(lunchTime));
        }

        [Fact]
        public void DetermineIfScheduleSlotIsAvailable()
        {
            Assert.True(_sut.IsSessionAvailable(DateTime.Parse("9 AM")));
        }

        
        
        
    }
}