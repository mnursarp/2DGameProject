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
        Debug.Log("Oyundan ��kt�k");//editorde g�remeyece�im i�in log att�m
        Application.Quit();

    }
}
