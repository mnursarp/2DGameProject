using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // hedef
    public Vector3 offset; // hedeften ne kadar farkl� konumda duraca�m
    public float damping;// 0 ile 1 aras�nda yumu�ak de�er ne kadar azsa o kadar yumu�ak



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, damping) + offset;
        //benim pozisyonumu yava�latarak takip et �uanki pozisyondan target pozisyonuna damping h�z�nda git ve offseti ekle 
    }
}
