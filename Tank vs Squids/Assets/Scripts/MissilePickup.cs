using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<CircleCollider2D>(), GameObject.Find("Tank").GetComponent<CircleCollider2D>());  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
