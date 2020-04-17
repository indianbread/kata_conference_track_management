using System;

namespace Conference_Track_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            var proposalsListString = ProposalData.GetAllProposals();

            foreach (var proposal in proposalsListString)
            {
                Console.WriteLine(proposal.Topic);
            }
        }
    }
}