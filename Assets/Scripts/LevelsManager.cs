using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public Button level1_button, level2_button, level3_button, level4_button;
    public static bool level1, level2, level3, level4;

    private void Start()
    {
        level1 = true;
    }

    private void Update()
    {
        if(level2 == true)
        {
            level2_button.interactable = true; //seviye2 nin kilidini aç
        }

        if (level3 == true)
        {
            level3_button.interactable = true; //seviye3 un kilidini aç
        }

        if (level4 == true)
        {
            level4_button.interactable = true; //seviye4 un kilidini aç
        }

    }
}
