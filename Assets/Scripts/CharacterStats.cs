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
        // -1 dememizin sebebi listeler 0 dan baþlar 4 ekadar kalbimiz yani 5 kalbimiz var.
        //health -= amount; //vurduðumuz kadar çýkarýr 

        //rb.AddForce(Vector2.left * 3000);//düþman sana vurunca kuvvet uygula 

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
        health += amount; //can yenilemesi için

        //ekrandaki kalpleri tekrar göstermek için for kullancaz

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

        if (health <= 0)//caným sýfýrsa ve küçükse anamenuye dön ve elmas deðerini sýfýrla :)
        {
            GoToMainMenu();
            ScorGenerator.diamondscore_int = 0;
        }

        //HASAR ALIYOR MU TEST KODU:
        //if (Input.GetKeyDown(KeyCode.H))
        //{
        //    if(health > 0)
        //    {
        //        //caným 0 dan büyükse 1 vursun
        //        Damage(1);
        //    }
        //}


        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    if(health < maxHealth)
        //    {
        //        //caným max candan küçükse 1 yenilesin
        //        Regen(1);
        //    }
        //}
    }


}
