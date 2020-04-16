using System.Collections.Generic;

namespace Conference_Track_Management
{
    public class Conference
    {
        public Conference(string name, List<Proposal> proposals)
        {
            Name = name;
            _proposals = proposals;
        }

        public List<Track> Tracks;
        
        public string Name { get; }
        private List<Proposal> _proposals { get; set; }

        private int CalculateDurationOfAllProposals()
        {
            return 0;
        }
    }
}