using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody EnemyRb;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        EnemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookDirection = Player.transform.position - transform.position;
        EnemyRb.AddForce(LookDirection * speed);

    }
}
