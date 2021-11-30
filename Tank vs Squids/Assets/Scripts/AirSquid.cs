using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSquid : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private float speed;

    private Vector3 playerInitialPos;
    private Vector3 initialPos;
    private Vector3 offscreenOffset;

    private float squidAngle;

    private Rigidbody2D SquidRB;
    private GameObject player;

    private bool mirrored = false;

    // Start is called before the first frame update
    void Start()
    {
        SquidRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Tank");

        playerInitialPos = player.transform.position;
        initialPos = transform.position;
        offscreenOffset = playerInitialPos + new Vector3(24, 11, 0);

        squidAngle = Mathf.Atan2( player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().rotation = squidAngle;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(squidAngle * Mathf.Deg2Rad) * 10, Mathf.Sin(squidAngle * Mathf.Deg2Rad) * 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < playerInitialPos.y && !mirrored)
        {
            squidAngle = Mathf.Abs(squidAngle);
            GetComponent<Rigidbody2D>().rotation = squidAngle;
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(squidAngle * Mathf.Deg2Rad) * 10, Mathf.Sin(squidAngle * Mathf.Deg2Rad) * 10);
            mirrored = true;
        }

        if (transform.position.y > player.transform.position.y + 25.0f && mirrored)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            //gameManager.enemiesKilled++;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
