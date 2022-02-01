//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MultiBomb : MonoBehaviour
//{
//    public GameObject Bomb;
//    private GameObject bomb;
//    public bool ispowerupactive = true;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space) && ispowerupactive)
//        {
//            bomb = Instantiate(Bomb, transform.position, Bomb.transform.rotation);
//            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-700f, 700f, 0));
//            Destroy(bomb, 5.0f);
//            ispowerupactive = true;
//            StartCoroutine(MultiBombActive());
//        }

//    }
//    IEnumerator MultiBombActive()
//    {
//        yield return new WaitForSeconds(10);
//        ispowerupactive = false;
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("PowerUp"))
//        {
//            Destroy(other.gameObject);
//        }
//    }


//}
