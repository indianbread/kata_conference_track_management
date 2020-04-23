using System;
using System.IO;

namespace Conference_Track_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}/App_Data/Proposals.csv";
            var proposalsListString = ProposalData.GetProposalDataFromFile(filePath);

            var proposalsToAllocate = ProposalData.GetAllProposals(proposalsListString);
            
            
        }
    }
}