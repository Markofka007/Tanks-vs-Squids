using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody2D missileRB;

    private bool explode = false;

    // Start is called before the first frame update
    void Start()
    {
        missileRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (explode)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            explode = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (explode && other.gameObject.CompareTag("Squid"))
        {
            Destroy(other.gameObject);
        }
    }
}
