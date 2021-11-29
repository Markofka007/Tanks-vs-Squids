using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossHealth = 2000;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth <= 0)
        {
            Destroy(gameObject);
        }

        //Debug.Log(bossHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Check");
        
        if(collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth -= 20;
        }
    }
}
