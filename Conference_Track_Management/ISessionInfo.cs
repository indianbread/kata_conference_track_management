using System;

namespace Conference_Track_Management
{
    public interface ISessionInfo
    {
        public int GetStartTime();

        public int GetFinishTime();
    }
}