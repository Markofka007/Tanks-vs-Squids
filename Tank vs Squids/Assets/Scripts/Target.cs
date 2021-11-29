using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour //Destroys a specified object when the target is hit
{
    public GameObject door;
    public float raisedHeight;
    bool isRaised = false;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRaised)
        {
            if(door.gameObject.transform.position.y < raisedHeight)
            {
                Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));
                door.gameObject.transform.position = Vector3.SmoothDamp(door.gameObject.transform.position, targetPosition, ref velocity, smoothTime);
            }
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

