using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody EnemyRb;
    private float speed = 1f;
    private Animator animator;
    public ParticleSystem explosionparticle;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player");
        EnemyRb = GetComponent<Rigidbody>();
    }

  //enemy follow player
    void Update()
    {
        Vector3 LookDirection = (Player.transform.position - transform.position).normalized;
        EnemyRb.AddForce(LookDirection * speed);
        animator.SetBool("isrun", true);
    }
    //Managing collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mines"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(explosionparticle, transform.position, explosionparticle.transform.rotation);
        }
        if (collision.gameObject.CompareTag("StickyBomb"))
        {
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = collision.gameObject.transform;
            StartCoroutine(BombDelay());
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        IEnumerator BombDelay()
        {
            yield return new WaitForSeconds(5);
            Instantiate(explosionparticle, transform.position, explosionparticle.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}