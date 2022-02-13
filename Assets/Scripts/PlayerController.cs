using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10f;
    int lives = 0;
    private Animator animator;
    public bool normalbomb = true;
    private int bombtype = 0;
    public GameObject[] Bomb;
    private GameObject bomb;
    public ParticleSystem explosionparticle;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Movement();
        SpawnBomb();
    }
    //player Movement
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
    //Bombs Spawning
    private void SpawnBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bombtype==0 && normalbomb)
        {
            bomb = Instantiate(Bomb[0], transform.position, Bomb[0].transform.rotation);
            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
            normalbomb = false;
            StartCoroutine(BombDelay());
        }

        else if (Input.GetKeyDown(KeyCode.Space) && bombtype==1)
        {
            for (int i = 0; i < 3; i++)
            {
                bomb = Instantiate(Bomb[1], transform.position, Bomb[1].transform.rotation);
                bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
                StartCoroutine(BombDelay());
            }
            StartCoroutine(PowerUpActive());
        }
        else if (Input.GetKeyDown(KeyCode.Space) && bombtype == 2)
        {
            bomb = Instantiate(Bomb[2], transform.position, Bomb[2].transform.rotation);
            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
            StartCoroutine(PowerUpActive());         
        }

        else if (Input.GetKeyDown(KeyCode.Space) && bombtype == 3)
        {
            bomb = Instantiate(Bomb[3], transform.position, Bomb[3].transform.rotation);
            bomb.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-400f, 400f, 0));
            StartCoroutine(BombDelay());
            StartCoroutine(PowerUpActive());
        }

    }
    IEnumerator BombDelay()
    {
        yield return new WaitForSeconds(5);
        if (bombtype == 0)
        {
            normalbomb = true;
        }  
        Instantiate(explosionparticle, bomb.transform.position, explosionparticle.transform.rotation);
        Destroy(bomb);
    }
    //power up active for 10s
    IEnumerator PowerUpActive()
    {
        if (bombtype==1)
        {
            yield return new WaitForSeconds(10);
            Bomb[1].SetActive(false);
        }
        if (bombtype == 2)
        {
            yield return new WaitForSeconds(10);
            Bomb[2].SetActive(false);
        }
        if (bombtype == 3)
        {
            yield return new WaitForSeconds(10);
            Bomb[3].SetActive(false);
        }
        bombtype = 0;
    }
    //Adding lives
    private void  AddLives(int value)
    {
        lives += value;
        Debug.Log("Lives:" + lives);
    }
    //Managing Triggering Operation
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MultiBombPowerUp"))
        {
            Destroy(other.gameObject);
            bombtype = 1;
            Bomb[1].SetActive(true);
        }
        if (other.CompareTag("MinesPowerUp"))
        {
            Destroy(other.gameObject);
            bombtype = 2;
            Bomb[2].SetActive(true);
        }
        if (other.CompareTag("StickyBombPowerUp"))
        {
            Destroy(other.gameObject);
            bombtype = 3;
            Bomb[3].SetActive(true);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("LifePowerUp"))
        {
            AddLives(1);
            Destroy(other.gameObject);
        }
    }
}





