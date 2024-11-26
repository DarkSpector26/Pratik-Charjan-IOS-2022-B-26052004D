using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]  // This is Important for XML serialization
public class ScoreData
{
    public int player1Score;
    public int player2Score;
    public List<int> highScores = new List<int>();
}
