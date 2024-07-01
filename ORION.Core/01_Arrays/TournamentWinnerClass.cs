using System;
using System.Collections.Generic;

namespace TournamentWinner;
public class TournamentWinnerClass
{
    /// <summary>
    /// There's an algorithms tournament taking place in which teams of programmers compete against
    /// each other to solve algorithmic problems as fast as possible. Teams compete in round robin,
    /// where each team faces off against all other teams. Only two teams compete against each team
    /// other at a time, and for each competition, one team is designated the home team, while the 
    /// other team is the away team. In each competition, there's always one winner and one loser; there
    /// are no ties. A team receives 3 points if it wins and 0 points if it loses. The winner of the 
    /// tournament is the team that receives 3 points it it wins 0 point it it loses. The winner of the 
    /// tournament is the team that receives the most points.
    /// 
    /// Given an array of pairs representing the teams that have completed against  each other and
    /// an array counting the result of each competition, Write a function that returns the winner of
    /// the tournament . The input arrays are names competitions and result, respectively. The 
    /// competitions array has elements in the form of [homeTeam, awayTeam ], where each team is a 
    /// string of at mos 30 characters representing the name of the team. The results array contains
    /// information about  the winner of each  corresponding competition in the competition array. 
    /// Specifically, results[i] denotes the winner of competitions[i], where 1 in the results array 
    /// means that the home team team in the corresponding competition won a 0 means that the away 
    /// team won.
    /// 
    /// it's guaranteed that exactly one team will win the tournament and thateach team will compete
    /// agaist all other teamns exactly once. It's also guaranteed that the tournament will always have 
    /// at leat two teamns.
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public int HOME_TEAM_WON = 1;

    public string TournamentWinner(List<List<string>> competitions, List<int> results)
    {
        var currentBestTeam = "";
        var scores = new Dictionary<string, int>();
        scores[currentBestTeam] = 0;

        for (int index = 0; index < competitions.Count; index++)
        {
            List<string> competition = competitions[index];
            int result = results[index];

            var homeTeam = competition[0];
            var awayTeam = competition[1];

            string winingTeam = (result == HOME_TEAM_WON) ? homeTeam : awayTeam;

            updateScores(winingTeam, 3, scores);

            if (scores[winingTeam]> scores[currentBestTeam])
            {
                currentBestTeam = winingTeam;
            }
        }

        return currentBestTeam;
    }

    private void updateScores(string winingTeam, int points, Dictionary<string,int> scores )
    {
        if (!scores.ContainsKey(winingTeam))
        {
            scores[winingTeam] = 0;
        }

        scores[winingTeam] += points;
    }
}
