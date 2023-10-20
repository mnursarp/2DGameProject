using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // hedef
    public Vector3 offset; // hedeften ne kadar farklý konumda duracaðm
    public float damping;// 0 ile 1 arasýnda yumuþak deðer ne kadar azsa o kadar yumuþak



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
        //benim pozisyonumu yavaþlatarak takip et þuanki pozisyondan target pozisyonuna damping hýzýnda git ve offseti ekle 
    }
}
