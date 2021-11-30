using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSquid : MonoBehaviour
{
    private Rigidbody2D squidRB;

    private GameObject player;

    private bool isActivated = false;

    private float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        squidRB = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isActivated)
        {
            float squidAngle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            GetComponent<Rigidbody2D>().rotation = squidAngle;
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(squidAngle * Mathf.Deg2Rad) * speed, Mathf.Sin(squidAngle * Mathf.Deg2Rad) * speed);
        }

        if (Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2) + Mathf.Pow(transform.position.y - player.transform.position.y, 2)) < 24.166f)
        {
            isActivated = true;
        }
    }

    float CosDeg(float degInput)
    {
        return Mathf.Cos(degInput * Mathf.Deg2Rad) * Mathf.Rad2Deg;
    }

    float SinDeg(float degInput)
    {
        return Mathf.Sin(degInput * Mathf.Deg2Rad) * Mathf.Rad2Deg;
    }
}
