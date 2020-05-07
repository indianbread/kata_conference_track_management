using System;

namespace Conference_Track_Management
{
    public interface ISessionInfo
    {
        public DateTime GetStartTime();

        public DateTime GetFinishTime();
        
    }
}