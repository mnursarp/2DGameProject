using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D temas)
    {
        //karakter bitiþ noktasýyla temasa geçtiyse ve yýldýz puamý 15 olduysa
        if (temas.gameObject.tag == "Player" && ScorGenerator.diamondscore_int == 36)
        {
            panel.SetActive(true);//paneli aktif et 
            player.SetActive(false);//oyun bitince karakter hareket edemesin
            ScorGenerator.diamondscore_int = 0; // Elmas sayýsýný sýfýrla
        }
    }
}
