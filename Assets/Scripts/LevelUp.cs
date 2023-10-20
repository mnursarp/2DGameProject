using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp : MonoBehaviour
{
    public void level1finish()
    {
        LevelsManager.level2 = true;
        SceneManager.LoadScene(1);
    }

    public void level2finish()
    {
        LevelsManager.level3 = true;
        SceneManager.LoadScene(1);
    }

    public void level3finish()
    {
        LevelsManager.level4 = true;
        SceneManager.LoadScene(1);
    }

    public void level4finish()
    {
        SceneManager.LoadScene(1);
    }

}
