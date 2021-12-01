using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody2D missileRB;

    private bool explode = false;
    private bool areSquids;
    private Collider2D myCollider;
    private List<Collider2D> colliderResults;

    // Start is called before the first frame update
    void Start()
    {
        missileRB = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        colliderResults = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(areSquids);
    }

    private void LateUpdate()
    {
        if (explode && !areSquids)
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Squid"))
        {
            areSquids = true;

            //Debug.Log(other);

            if (explode)
            {
                StartCoroutine("explosion");
                Destroy(other.gameObject);
            }
        }
        else
        {
            areSquids = false;
        }
    }

    IEnumerator explosion()
    {
        yield return 1;

        while(areSquids)
        {
            myCollider.OverlapCollider(new ContactFilter2D(), colliderResults);

            Debug.Log(colliderResults.Count);
        }
    }
}
