using System;

namespace Conference_Track_Management
{
    public class Proposal
    {
        public Proposal(string topic, int duration)
        {
            Topic = topic;
            Duration = duration;
        }

        public string Topic { get; }
        public int Duration { get; }

    }
}