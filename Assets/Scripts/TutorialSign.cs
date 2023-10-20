using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSign : MonoBehaviour
{
    public GameObject tutorialText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collider �n i�ine girince yaz�y� g�stercek
        tutorialText.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //collider dan ��k�nca yaz�y� saklayacak
        tutorialText.SetActive(false);

    }

}
