using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D temas)//trigger = yumuþak temas
    {
        if(temas.gameObject.tag == "Player")//temas eden objenin etiketi player ise
        {
            ScorGenerator.diamondscore_int += 1;
            Destroy(this.gameObject);//game objesini yok et 

        }
    }
}
