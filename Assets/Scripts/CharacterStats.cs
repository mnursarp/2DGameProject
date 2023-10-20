using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    public Image[] hearts;

    Rigidbody2D rb;

    public int health = 5;
    int maxHealth = 5;

    public void TakeDamage(int amount)
    {
        //hearts[health - 1].enabled = false;
        // -1 dememizin sebebi listeler 0 dan ba�lar 4 ekadar kalbimiz yani 5 kalbimiz var.
        //health -= amount; //vurdu�umuz kadar ��kar�r 

        //rb.AddForce(Vector2.left * 3000);//d��man sana vurunca kuvvet uygula 

        if (health <= 0)
            return;

        hearts[health - 1].enabled = false;
        health -= amount;
        rb.AddForce(Vector2.left * 3000);

    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(1);
    }


    public void Regen(int amount)
    {
        health += amount; //can yenilemesi i�in

        //ekrandaki kalpleri tekrar g�stermek i�in for kullancaz

        for(int i = 0; i < health; i++)
        {
            hearts[i].enabled = true;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health > maxHealth)
        {
            health = maxHealth; //can en fazla 5 olur 6 olamaz 
        }

        if (health <= 0)//can�m s�f�rsa ve k���kse anamenuye d�n ve elmas de�erini s�f�rla :)
        {
            GoToMainMenu();
            ScorGenerator.diamondscore_int = 0;
        }

        //HASAR ALIYOR MU TEST KODU:
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    if(health > 0)
        //    {
        //        //can�m 0 dan b�y�kse 1 vursun
        //        Damage(1);
        //    }
        //}


        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    if(health < maxHealth)
        //    {
        //        //can�m max candan k���kse 1 yenilesin
        //        Regen(1);
        //    }
        //}
    }


}
