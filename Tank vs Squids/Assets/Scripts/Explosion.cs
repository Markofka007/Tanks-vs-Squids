using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{private float timeAlive = 0;void Start(){}void Update(){if(timeAlive > 0.1){Destroy(gameObject);}timeAlive += Time.deltaTime;}private void OnTriggerEnter2D(Collider2D other){if (other.gameObject.CompareTag("Squid")){Destroy(other.gameObject);}}}
