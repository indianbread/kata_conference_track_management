using System;
using System.Collections.Generic;
using System.Globalization;

namespace Conference_Track_Management
{
    public static class OutputFormatter
    {
        public static List<string> GenerateScheduleInfo(Track track)
        {
            var scheduleString = new List<string>();
            foreach (var talk in track.Schedule)
            {
                var talkInfo = GenerateTalkInfo(talk);
                scheduleString.Add(talkInfo);
            }

            return scheduleString;
        }

        private static string GenerateTalkInfo(KeyValuePair<DateTime, Proposal> talk)
        {
            var time = talk.Key.ToString("hh:mmtt");
            var topic = talk.Value.Topic;
            if (topic == "Lunch" || topic == "Networking Event")
            {
                return time + " " + topic;
            }
            var duration = talk.Value.Duration;
            var durationString = duration == 5 ? "lightning" : duration + "min";
            return time + " " + topic + " " + durationString;
        }
    }
}