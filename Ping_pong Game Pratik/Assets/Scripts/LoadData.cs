using System.IO;
using System.Xml.Serialization;  // <-- Add this line
using TMPro;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public TMP_Text finalScoreText;

    private string filePath;

    private void Start()
    {
        //  file path where the score was saved
        filePath = "E:\\MultiPlayer Fighting 1v1 Unity\\Ping_pong Game\\Assets\\scoreData.xml";

        // Load the score from the file and display it
        LoadScore();
    }

    // Load the score data from the XML file
    void LoadScore()
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ScoreData));
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            ScoreData data = (ScoreData)serializer.Deserialize(fileStream);
            fileStream.Close();

            // Display the loaded score
            finalScoreText.text = "Player 1 Score: " + data.player1Score.ToString() + "\nPlayer 2 Score: " + data.player2Score.ToString();
        }
    }
}


