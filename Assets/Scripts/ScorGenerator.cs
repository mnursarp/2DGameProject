using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorGenerator : MonoBehaviour
{
    public Text diamondscore;
    public static int diamondscore_int = 0;

    public void Update()
    {
        diamondscore.text = diamondscore_int.ToString(); //dönüþtür texte yaz 
    }
}
