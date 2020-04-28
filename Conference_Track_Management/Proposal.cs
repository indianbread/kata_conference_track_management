using System;

namespace Conference_Track_Management
{
    public class Proposal
    {
        public Proposal(string topic, int duration = 0)
        {
            Topic = topic;
            Duration = duration;
        }

        public string Topic { get; private set; } 
        //getter here more for memory management to make it a registered property so compiler knows how to deal with this field
        public int Duration { get; private set; } //private set - allows methods in this class to be able to change the value
        //if no setter at all then can only set the value from the constructor
        
    }
}