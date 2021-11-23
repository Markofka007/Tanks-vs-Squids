using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    private Rigidbody2D playerRB;
    private GameObject tankHead;
    private GameObject cannonTip;

    [SerializeField] private float speed;
    [SerializeField] private float vertSpeed;
    [SerializeField] private float smoothing = 0.05f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bulletPrefab;

    private float horizontalInput;
    private float targetYVelocity;
    private float headRotationFloat;
    private int fuel = 50;
    
    private Vector3 vector3Zero = Vector3.zero;
    private Vector3 targetVelocity;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        tankHead = GameObject.Find("TankHead");
        cannonTip = GameObject.Find("TankCannonTip");
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        tankHead.transform.position = transform.position + new Vector3(0, 0.5f, 0);

        Vector3 mousePosDif = mainCamera.ScreenToWorldPoint(Input.mousePosition) - tankHead.transform.position;
        tankHead.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(mousePosDif.y, mousePosDif.x) * Mathf.Rad2Deg;

        gameManager.fuelMeter.text = "Fuel: " + fuel;

        headRotationFloat = tankHead.GetComponent<Rigidbody2D>().rotation;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, cannonTip.transform.position, tankHead.transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(CosDeg(headRotationFloat) * 0.3f, SinDeg(headRotationFloat) * 0.3f);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            playerRB.AddForce(Vector2.up * vertSpeed, ForceMode2D.Impulse);
            fuel--;
            //Debug.Log(fuel);
        }
        
        Vector3 targetVelocity = new Vector2((horizontalInput * speed * Time.fixedDeltaTime), playerRB.velocity.y);
        playerRB.velocity = Vector3.SmoothDamp(playerRB.velocity, targetVelocity, ref vector3Zero, smoothing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            fuel = 50;
            //Debug.Log(fuel);
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
