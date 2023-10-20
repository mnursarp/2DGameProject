using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript2 : MonoBehaviour
{

    public GameObject panel;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D temas)
    {
        //karakter biti� noktas�yla temasa ge�tiyse ve y�ld�z puam� xx olduysa
        if (temas.gameObject.tag == "Player" && ScorGenerator.diamondscore_int == 22)
        {
            panel.SetActive(true);//paneli aktif et 
            player.SetActive(false);//oyun bitince karakter hareket edemesin
            ScorGenerator.diamondscore_int = 0; // Elmas say�s�n� s�f�rla
        }
    }
}
