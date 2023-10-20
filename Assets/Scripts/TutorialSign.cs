using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSign : MonoBehaviour
{
    public GameObject tutorialText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collider ýn içine girince yazýyý göstercek
        tutorialText.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //collider dan çýkýnca yazýyý saklayacak
        tutorialText.SetActive(false);

    }

}
