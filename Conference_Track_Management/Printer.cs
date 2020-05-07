using System;
using System.Collections.Generic;

namespace Conference_Track_Management
{
    public static class Printer
    {
        public static void PrintAllocationResult(ConferenceTrackResult result)
        {
            if (!result.IsSuccess)
            {
                Console.WriteLine("Error: " + result.ErrorMessage);
            }
            
            PrintConferenceSchedule(result.Tracks);
        }

        private static void PrintConferenceSchedule(List<Track> tracks)
        {
            foreach (var track in tracks)
            {
                Console.WriteLine("Track" + " "+ track.TrackNumber);
                Console.WriteLine();
                var proposalsFormatted = OutputFormatter.GenerateScheduleInfo(track);
                foreach (var line in proposalsFormatted)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine();
            }
        }
    }
}