using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadingScreen;

    public void Start()
    {
        SoundManager.Instance.PlayBackgroundMusic("BackGround");
    }
    public void StartGame()
    {

        SoundManager.Instance.Playsound2D("UiSound");
        StartCoroutine(LoadGameScene());
        SoundManager.Instance.Playsound2D("GameStart");
       
    }


    IEnumerator LoadGameScene()
    {
        LoadingScreen.SetActive(true);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        SoundManager.Instance.Playsound2D("UiSound");
        Application.Quit();
    }
}
