using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D temas)//sert temas 
    {
        if(temas.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
            ScorGenerator.diamondscore_int = 0;
        }
    }
}
