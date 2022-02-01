//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StickyBomb : MonoBehaviour
//{
//    public GameObject Bomb;
//    private GameObject bomb;
//    private int quantity=0;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && quantity<3)
//        {
//            bomb = Instantiate(Bomb, transform.position, Bomb.transform.rotation);
//            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-700f, 700f, 0));
//        }
//        quantity++;
//    }
    
//}
