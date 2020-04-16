using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Conference_Track_Management_Tests
{
    public class ExternalProposalData
    {

        public static IEnumerable<object[]> ProposalData
        {
            get
            {
                string[] csvLines = File.ReadAllLines(
                    "/Users/nhan.dang/OneDrive - MYOB/Future-Makers-Academy/General_Developer/katas/kata-conference-track-management/kata_conference_track_management/Conference_Track_Management/Conference_Track_Management_Tests/Proposals.csv");
                object[] proposal = csvLines.Cast<object>().ToArray();
                var proposals = new List<object[]>();
                proposals.Add(proposal);
                return proposals;
            }
        }

    }
}