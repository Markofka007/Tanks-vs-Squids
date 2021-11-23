using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private float horiAxis;
    public float forceValue;
    private Rigidbody2D tankRb;

    // Start is called before the first frame update
    void Start()
    {
        tankRb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horiAxis = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(forceValue * new Vector2(horiAxis, 0.0f), ForceMode2D.Force);
            //velocity += new Vector2(forceValue * horiAxis, 0);
            //.AddForce(new Vector2(horiAxis, 0.0f) * forceValue, ForceMode2D.Force);
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(horiAxis, 0.0f) * -forceValue/2, ForceMode2D.Force);
        }
    }
}
