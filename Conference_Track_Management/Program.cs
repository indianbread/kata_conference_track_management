using System;
using System.Collections.Generic;
using System.IO;

namespace Conference_Track_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: error handling if file path is unable to be located
            var filePath = @$"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}/App_Data/Proposals.csv";
            var proposalsToAllocate = GetProposalsToAllocate(filePath);


        }

        private static List<Proposal> GetProposalsToAllocate(string filePath)
        {
            
            var proposalsListString = ProposalData.GetProposalDataFromFile(filePath);
            var proposalsToAllocate = ProposalData.GetAllProposals(proposalsListString);
            return proposalsToAllocate;
        }
    }
}