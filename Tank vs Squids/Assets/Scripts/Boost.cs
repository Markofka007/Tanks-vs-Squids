using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private float horiAxis;
    public float forceValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horiAxis = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiAxis, 0.0f) * forceValue, ForceMode2D.Impulse);
            //velocity += new Vector2(forceValue * horiAxis, 0);
            //.AddForce(new Vector2(horiAxis, 0.0f) * forceValue, ForceMode2D.Force);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiAxis, 0.0f) * -forceValue/2, ForceMode2D.Force);
        }
    }
}
