using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//sahne y�netimi i�in gerekli 


public class MenuButtonScript : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        ScorGenerator.diamondscore_int = 0; // Elmas say�s�n� s�f�rla
    }
}
