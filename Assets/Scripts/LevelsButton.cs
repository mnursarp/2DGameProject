using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButton : MonoBehaviour
{
    public void levels()
    {
        SceneManager.LoadScene(1);
    }

    public void OuitGame()
    {
        Debug.Log("Oyundan Çýktýk");//editorde göremeyeceðim için log attým
        Application.Quit();

    }
}
