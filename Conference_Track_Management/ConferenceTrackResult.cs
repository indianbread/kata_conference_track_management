using System.Collections.Generic;

namespace Conference_Track_Management
{
    public class ConferenceTrackResult
    {
        public bool IsSuccess { get; set; }
        public List<Track> Tracks { get; set; }
        public string ErrorMessage { get; set; }

        internal static ConferenceTrackResult CreateError(string errorMessage) //this method ensures errors are logged & returned in a consistent manner
            //internal only allows the method to be accessed from within the project
        {
            return new ConferenceTrackResult()
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };

        }
        
        internal static ConferenceTrackResult CreateSuccess(List<Track> tracks) 
            //internal only allows the method to be accessed from within the project
        {
            return new ConferenceTrackResult()
            {
                IsSuccess = true,
                Tracks = tracks
                
            };

        }
    }
}