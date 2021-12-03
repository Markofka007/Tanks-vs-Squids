using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{ private GameManager gameManager;  private float timeAlive = 0;void Start(){ gameManager = GameObject.FindObjectOfType<GameManager>(); } void Update(){if(timeAlive > 0.1){Destroy(gameObject);}timeAlive += Time.deltaTime;}private void OnTriggerEnter2D(Collider2D other){if (other.gameObject.CompareTag("Squid")){ gameManager.enemiesKilled++;  Destroy(other.gameObject);}}}
