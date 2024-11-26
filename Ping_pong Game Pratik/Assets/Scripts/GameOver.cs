using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOVer : MonoBehaviour
{
    Score Score;

    private void Start()
    {
        Score = FindAnyObjectByType<Score>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            SoundManager.Instance.SetBGMVolume(0.0f);
            SoundManager.Instance.Playsound2D("GameOver");
            SceneManager.LoadScene("EndGameScene");
            Score.SaveScore();
        }
          
    }

}
