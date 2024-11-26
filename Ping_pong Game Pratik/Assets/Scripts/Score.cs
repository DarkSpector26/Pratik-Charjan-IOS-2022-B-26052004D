

using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;
   // public TMP_Text leaderboardText;  // Reference to display leaderboard

    private int player1Score = 0;
    private int player2Score = 0;
    private string filePath;

    private List<int> highScores = new List<int>();  // List to store high scores

    void Start()
    {
        filePath = "E:\\MultiPlayer Fighting 1v1 Unity\\Ping_pong Game\\Assets\\scoreData.xml";

        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        ResetScore();

        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            LoadScore();  // Load saved scores
            //UpdateLeaderboard();  // Update leaderboard display
        }
        else
        {
            // If the scene is not the EndScene, load the high scores on game start
            LoadHighScores();
        }
    }

    public void Player1Score()
    {
        player1Score++;
        UpdateScore();
        SaveScore();
    }

    public void Player2Score()
    {
        player2Score++;
        UpdateScore();
        SaveScore();
    }

    void UpdateScore()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void SaveScore()
    {
        // Add the current scores to the high scores list
        highScores.Add(player1Score);
        highScores.Add(player2Score);

        // Sort high scores in descending order
        highScores.Sort((a, b) => b.CompareTo(a));  // Sort in descending order
        if (highScores.Count > 5)
        {
            highScores = highScores.GetRange(0, 5);  // Keep only top 5 scores
        }

        // Save the scores to the file
        ScoreData data = new ScoreData
        {
            player1Score = player1Score,
            player2Score = player2Score,
            highScores = highScores
        };

        XmlSerializer serializer = new XmlSerializer(typeof(ScoreData));
        FileStream fileStream = new FileStream(filePath, FileMode.Create);
        serializer.Serialize(fileStream, data);
        fileStream.Close();
    }

    public void LoadScore()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ScoreData));
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            ScoreData data = (ScoreData)serializer.Deserialize(fileStream);
            fileStream.Close();

            player1Score = data.player1Score;
            player2Score = data.player2Score;
            highScores = data.highScores;  // Load high scores
            UpdateScore();
        }
        else
        {
            // If no scores exist, set defaults
            highScores = new List<int>();
        }
    }

    public void ResetScore()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScore();
    }

    // Method to update the leaderboard display
    //void UpdateLeaderboard()
    //{
    //    if (highScores.Count > 0)
    //    {
    //        string leaderboard = "Leaderboard:\n";
    //        for (int i = 0; i < highScores.Count; i++)
    //        {
    //            leaderboard += (i + 1) + ". " + highScores[i] + "\n";
    //        }
    //        leaderboardText.text = leaderboard;
    //    }
    //    else
    //    {
    //        leaderboardText.text = "Leaderboard: No scores available.";
    //    }
    //}

    // Method to load and display the leaderboard
    void LoadHighScores()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ScoreData));
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            ScoreData data = (ScoreData)serializer.Deserialize(fileStream);
            fileStream.Close();

            highScores = data.highScores;  // Load high scores
            //UpdateLeaderboard();  // Display the leaderboard
        }
        else
        {
            //leaderboardText.text = "Leaderboard: No scores available.";
        }
    }
}

