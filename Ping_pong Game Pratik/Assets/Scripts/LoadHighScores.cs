using System.IO;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHighScores : MonoBehaviour
{
    public TMP_Text leaderboardText; 
    private string filePath;

    private void Start()
    {
        filePath = "E:\\MultiPlayer Fighting 1v1 Unity\\Ping_pong Game\\Assets\\scoreData.xml"; // file path where the file will  be save 
        LoadLeaderboard();
    }

    void LoadLeaderboard() // Loading the High Score data from xml file
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ScoreData));
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            ScoreData data = (ScoreData)serializer.Deserialize(fileStream);
            fileStream.Close();

            // Leaderboard format
            string leaderboard = "HighScore:\n";
            for (int i = 0; i < data.highScores.Count; i++)
            {
                leaderboard += (i + 1) + ". " + data.highScores[i].ToString() + "\n";
            }

            // Update the leaderboard UI text
            leaderboardText.text = leaderboard;
        }
        else
        {
            leaderboardText.text = "No scores available.";
        }
    }

     public void OnMainMenuButtonClick() // Load the main menu scene
    {

        SoundManager.Instance.Playsound2D("UiSound");
        SceneManager.LoadScene("StartScene");
    }
}
