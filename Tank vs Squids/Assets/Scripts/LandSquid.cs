using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSquid : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private float speed;
    [SerializeField] private float smoothing;

    private Vector3 directionFacing;

    private Rigidbody2D SquidRB;
    private GameObject player;

    private Vector3 vector3Zero = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        SquidRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        directionFacing = (player.transform.position - transform.position).normalized;
        Debug.Log(directionFacing.x);
    }

    private void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(directionFacing.x * speed * Time.fixedDeltaTime, SquidRB.velocity.y);
        SquidRB.velocity = Vector3.SmoothDamp(SquidRB.velocity, targetVelocity, ref vector3Zero, smoothing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            gameManager.enemiesKilled++;
        }
    }
}
