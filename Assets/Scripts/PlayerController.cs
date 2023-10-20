using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    public int damage; //hasar i�in

    float moveInput;

    Animator animator;
    Rigidbody2D rb;

    bool canjump = true; //havada �ift z�plama yapmas�n diye kullancaz
    bool faceRight = true; //y�n�n� d�nmesi i�in sa�a bakarken
    bool canAttack = true; //sald�rabilir miyim onun i�in


    Vector2 forward;//�n y�n�m raycast�n ��kaca�� y�n

    public Vector3 offset; //sald�r�n�n ��kaca�� �eyin raycast�n offsetini belitcez

    RaycastHit2D hit; //Silah�n ucuna ya da kameraya bir unity raycast sistemi entegre edilerek g�r�nmeyen bir ���n yayar.


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//animator componentini alacak
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()//pc i�in olan 
    {
        //hareket komutlar�m�z� fizik motoruna ba�l� olarak yapaca��m�z i�in fixedupdate metodunu kullan�yoruz
        //moveInput = Input.GetAxis("Horizontal"); //yatay eksendeki hareket i�in ok tu�lar� ve asdw
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //iki boyutlu eksende benim bast���m y�ne g�re 1 veya -1 ile �arp�laca�� i�in h�z kadar gir ve y eksenini koru

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true); //true olunca git false lunva gel demi�tik conditionsta animat�r tab�nda
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (faceRight == true && moveInput < 0)
        {
            Flip();
            // sa�a bak�yorsam ve input 0 dan k���kse -1 e gidecek ya o zaman d�nd�r..
        }
        else if (faceRight == false && moveInput > 0)
        {
            // sola bak�yorsam ve input 0 dan b�y�kse 1 e gidecekse d�nd�r.
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            Attack();
        }


    }

    

    public void MoveRight()
    {
        moveInput = 1;
    }

    public void MoveLeft()
    {
        moveInput = -1;
    }

    public void StopMovement()
    {
        moveInput = 0; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            canjump = true; // alt�mdaki objenin tag� platform ise z�pla 
        }
    }

    public void Jump()
    {
        if (canjump)
        {
            //z�playabiliyor isem
            rb.AddForce(Vector2.up * jumpSpeed); //g�� ekle yukar� dogru 
            canjump = false; //sonra z�playama 
        }
    }

    private void Flip()
    {
        faceRight = !faceRight; //y�n�n� terse �evir
        Vector3 scaler = transform.localScale; // boyutu vector3 e yaz
        scaler.x *= -1; //sa�a sola d�nmek i�in 
        transform.localScale = scaler; // transformu da �arp�lm�� de�erle de�i�tir
    }

    public void Attack()
    {
        canAttack = false; //bir kere sald�rabiliriz

        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2); //sola bak�yorsam d�z y�n�m sol olsun
        }
        else
        {
            forward = transform.TransformDirection(Vector2.right * 2); // sa�a bak�yorsam d�z y�n�m sa� olsun
        }



        animator.SetTrigger("attack"); //attack animasyon trigger�m�z� oynat 

        StartCoroutine(AttackDelay()); //her bir vuru�tan sonra attackdelay ba�lat�lacak

    }



    IEnumerator AttackDelay()//sald�rd�ktan sonra animasyon bitince bidaha 
    {
        yield return new WaitForSeconds(0.5f);//animasyon bitince tekrar sald�r�ya ge�ebilsin
        canAttack = true;
    }




}


