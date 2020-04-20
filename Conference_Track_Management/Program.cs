using System;

namespace Conference_Track_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "/Users/nhan.dang/OneDrive - MYOB/Future-Makers-Academy/General_Developer/katas/kata-conference-track-management/kata_conference_track_management/Conference_Track_Management/Conference_Track_Management/Proposals.csv";

            var proposalsListString = ProposalData.GetProposalDataFromFile(filePath);

            var proposalList = ProposalData.GetAllProposals(proposalsListString);
        }
    }
}