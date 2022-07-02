using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class timeGameOver : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1f; 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitGame()
    {
        PlayFabClientAPI.ForgetAllCredentials();
        SceneManager.LoadScene("Main Menu");
    }


}
