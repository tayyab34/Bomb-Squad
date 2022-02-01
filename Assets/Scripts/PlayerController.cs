using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    int lives = 0;
    private Animator animator;
    public bool ismine = false;
    public bool bombspawn = true;
    public bool normalbomb=true;
    public bool isstickybomb = false;
    public bool ismultibomb = false;
    public GameObject[] Bomb;
    //public Powe currentpowerup;
    private GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SpawnBomb();
    }
    private void Movement()
    {
        float horizontaInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow)
           || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.left * speed * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * horizontaInput * Time.deltaTime);
            animator.SetBool("isrun", true);
        }
        else
        {
            animator.SetBool("isrun", false);
        }
    }
    private void SpawnBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombspawn && normalbomb)
        {
            bomb = Instantiate(Bomb[0], transform.position, Bomb[0].transform.rotation);
            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
            bombspawn = false;
            StartCoroutine(BombSpawnerDelay());
        }
        if (Input.GetKeyDown(KeyCode.Space) && isstickybomb)
        {
            for (int i= 0; i < 3;i++)
            {
                    bomb = Instantiate(Bomb[1], transform.position, Bomb[1].transform.rotation);
                    bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
                    i++;     
            }
            isstickybomb = false;
        }
        if(Input.GetKeyDown(KeyCode.Space) && ismultibomb)
        {
            bomb = Instantiate(Bomb[3], transform.position, Bomb[3].transform.rotation);
            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
            Destroy(bomb, 5.0f);
            StartCoroutine(BombSpawnerDelay());
        }
        if (Input.GetKeyDown(KeyCode.Space) && ismine)
        {
            bomb = Instantiate(Bomb[2], transform.position, Bomb[2].transform.rotation);
            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
        }


    }

    IEnumerator BombSpawnerDelay()
    {
        yield return new WaitForSeconds(5);
        bombspawn = true;
        Destroy(bomb);
    }
    public void AddLives(int value)
    {
        lives += value;
        Debug.Log("Lives:" + lives);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mines"))
        {
            Destroy(other.gameObject);
            ismine = true;
            normalbomb = false;
        }
        if (other.CompareTag("StickyBomb"))
        {
            Destroy(other.gameObject);
            isstickybomb = true;
            normalbomb = false;
        }
        if (other.CompareTag("MultiBomb"))
        {
            Destroy(other.gameObject);
            ismultibomb = true;
            normalbomb = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isstickybomb == true)
        {
            bomb.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = collision.gameObject.transform;
            isstickybomb = false;
        }
        
    }

}   



