using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    public int damage; //hasar için

    float moveInput;

    Animator animator;
    Rigidbody2D rb;

    bool canjump = true; //havada çift zýplama yapmasýn diye kullancaz
    bool faceRight = true; //yönünü dönmesi için saða bakarken
    bool canAttack = true; //saldýrabilir miyim onun için


    Vector2 forward;//ön yönüm raycastýn çýkacaðý yön

    public Vector3 offset; //saldýrýnýn çýkacaðý þeyin raycastýn offsetini belitcez

    RaycastHit2D hit; //Silahýn ucuna ya da kameraya bir unity raycast sistemi entegre edilerek görünmeyen bir ýþýn yayar.


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//animator componentini alacak
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()//pc için olan 
    {
        //hareket komutlarýmýzý fizik motoruna baðlý olarak yapacaðýmýz için fixedupdate metodunu kullanýyoruz
        //moveInput = Input.GetAxis("Horizontal"); //yatay eksendeki hareket için ok tuþlarý ve asdw
        
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); //iki boyutlu eksende benim bastýðým yöne göre 1 veya -1 ile çarpýlacaðý için hýz kadar gir ve y eksenini koru

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true); //true olunca git false lunva gel demiþtik conditionsta animatör tabýnda
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (faceRight == true && moveInput < 0)
        {
            Flip();
            // saða bakýyorsam ve input 0 dan küçükse -1 e gidecek ya o zaman döndür..
        }
        else if (faceRight == false && moveInput > 0)
        {
            // sola bakýyorsam ve input 0 dan büyükse 1 e gidecekse döndür.
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
            canjump = true; // altýmdaki objenin tagý platform ise zýpla 
        }
    }

    public void Jump()
    {
        if (canjump)
        {
            //zýplayabiliyor isem
            rb.AddForce(Vector2.up * jumpSpeed); //güç ekle yukarý dogru 
            canjump = false; //sonra zýplayama 
        }
    }

    private void Flip()
    {
        faceRight = !faceRight; //yönünü terse çevir
        Vector3 scaler = transform.localScale; // boyutu vector3 e yaz
        scaler.x *= -1; //saða sola dönmek için 
        transform.localScale = scaler; // transformu da çarpýlmýþ deðerle deðiþtir
    }

    public void Attack()
    {
        canAttack = false; //bir kere saldýrabiliriz

        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2); //sola bakýyorsam düz yönüm sol olsun
        }
        else
        {
            forward = transform.TransformDirection(Vector2.right * 2); // saða bakýyorsam düz yönüm sað olsun
        }



        animator.SetTrigger("attack"); //attack animasyon triggerýmýzý oynat 

        StartCoroutine(AttackDelay()); //her bir vuruþtan sonra attackdelay baþlatýlacak

    }



    IEnumerator AttackDelay()//saldýrdýktan sonra animasyon bitince bidaha 
    {
        yield return new WaitForSeconds(0.5f);//animasyon bitince tekrar saldýrýya geçebilsin
        canAttack = true;
    }




}


