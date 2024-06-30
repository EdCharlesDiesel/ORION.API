using System.Collections.Generic;

namespace StableInternships
{
    /// <summary>
    /// A Company has 
    /// </summary>
    public class StableInternshipsClass
    {
        public int[][] StableInternships(int[][] interns, int[][] teams)
        {
            Dictionary<int,int> chosenInterns = new Dictionary<int, int>();
            Stack<int> freeInterns = new Stack<int>();

            for (int i = 0; i < interns.Length; i++)
            {
                freeInterns.Push(i);
            }

            int[] currentInternsChoices = new int[interns.Length];

            List<Dictionary<int,int>> teamDictionarys = new List<Dictionary<int,int>> ();

            foreach (var team in teams)
            {
                Dictionary<int, int> rank = new Dictionary<int, int>();
                for (int i = 0; i < team.Length; i++)
                {
                    rank[team[i]] = i;
                }

                teamDictionarys.Add(rank);
            }

            while (freeInterns.Count != 0)
            {
                int internNum= freeInterns.Pop();

                int[] intern = new int[internNum];
                int teamPreference = intern[currentInternsChoices[internNum]];
                currentInternsChoices[internNum]++;

                if (!chosenInterns.ContainsKey(teamPreference))
                {
                    chosenInterns[teamPreference]= internNum;
                    continue;
                }

                int previousIntern = chosenInterns[teamPreference];
                int previousInternRank = teamDictionarys[teamPreference][previousIntern];
                int currentInternRank = teamDictionarys[teamPreference][internNum];

                if (currentInternRank < previousInternRank) 
                {
                    freeInterns.Push(previousIntern);
                    chosenInterns[teamPreference] = internNum;
                }
                else
                {
                    freeInterns.Push(internNum);
                }
            }

            int[][] matches = new int[interns.Length][];
            int index = 0;

            foreach (var chosenIntern in chosenInterns)
            {
                matches[index] = new int[] { chosenIntern.Value, chosenIntern.Key };
                index++;
            }
            return matches;
        }
    }
}