using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour //Destroys a specified object when the target is hit
{
    public GameObject objectToBeDestroyed;
    public float raisedHeight;
    bool isRaised = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRaised)
        {
            objectToBeDestroyed.gameObject.transform.position += new Vector3(0, 5);
            isRaised = false;//Mathf.Lerp(gameObject.transform.position.y, raisedHeight, 0.5f)                    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        
        if(collision.gameObject.CompareTag("Bullet"))
        {
            isRaised = true;
        }
    }
}

