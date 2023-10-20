using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour
{
    public int health;

    public int speed;
    public int turnDelay;

    bool faceRight = false;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SwitchDirections());
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    IEnumerator SwitchDirections()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }

    private void Switch()
    {
        faceRight = !faceRight; //y�n�n� terse �evir
        Vector3 scaler = transform.localScale; // boyutu vector3 e yaz
        scaler.x *= -1; //sa�a sola d�nmek i�in 
        transform.localScale = scaler; // transformu da �arp�lm�� de�erle de�i�tir

        speed *= -1;

        StartCoroutine(SwitchDirections());
    }

    public void TakeDamage(int amonut)//alaca��m hasar amount
    {
        rb.AddForce(Vector2.right * 170);//hasar ald���nda addforce uygula

        health -= amonut;//hasar� can�mdan ��kar

        if (health <= 0)//can�m 0 dan k���k ve e�itse
            Destroy(gameObject);//�l

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<CharacterStats>().TakeDamage(1);
            //1 de�erinde vur
        }
    }

}
