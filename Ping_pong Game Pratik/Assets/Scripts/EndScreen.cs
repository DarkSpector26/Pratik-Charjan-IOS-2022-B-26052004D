using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject LoadingScreen;
   
    public void Restartgame()  // restart the game and scores
    {
        StartCoroutine(LoadGameLevelAgain()); 
        SoundManager.Instance.Playsound2D("GameStart");
        SoundManager.Instance.PlayBackgroundMusic("BackGround");
    }

    IEnumerator LoadGameLevelAgain()  // coroutine for slight delay after clicking the button
    {
        LoadingScreen.SetActive(true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("GameScene");
    }

    public void QuitToMainMenu() // quit to main menu
    {
        SoundManager.Instance.Playsound2D("UiSound");
        SceneManager.LoadScene("StartScene");
    }
    
    public void OnLeaderBoardbuttonClick() // display the LeaderBoard Scene 
    {
        SoundManager.Instance.Playsound2D("UiSound");
        SceneManager.LoadScene("LeaderBoardScene");
    }
}
