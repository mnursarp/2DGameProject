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
        faceRight = !faceRight; //yönünü terse çevir
        Vector3 scaler = transform.localScale; // boyutu vector3 e yaz
        scaler.x *= -1; //saða sola dönmek için 
        transform.localScale = scaler; // transformu da çarpýlmýþ deðerle deðiþtir

        speed *= -1;

        StartCoroutine(SwitchDirections());
    }

    public void TakeDamage(int amonut)//alacaðým hasar amount
    {
        rb.AddForce(Vector2.right * 170);//hasar aldýðýnda addforce uygula

        health -= amonut;//hasarý canýmdan çýkar

        if (health <= 0)//caným 0 dan küçük ve eþitse
            Destroy(gameObject);//öl

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<CharacterStats>().TakeDamage(1);
            //1 deðerinde vur
        }
    }

}
