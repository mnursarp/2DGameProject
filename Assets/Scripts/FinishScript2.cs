using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript2 : MonoBehaviour
{

    public GameObject panel;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D temas)
    {
        //karakter bitiþ noktasýyla temasa geçtiyse ve yýldýz puamý xx olduysa
        if (temas.gameObject.tag == "Player" && ScorGenerator.diamondscore_int == 22)
        {
            panel.SetActive(true);//paneli aktif et 
            player.SetActive(false);//oyun bitince karakter hareket edemesin
            ScorGenerator.diamondscore_int = 0; // Elmas sayýsýný sýfýrla
        }
    }
}
