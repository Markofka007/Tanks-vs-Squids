using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool doSpawn = false;
    public GameObject airSquidPrefab;
    private GameObject player;

    //private float OSdistance = 24.166f;
    private float OSdistanceY = 11.0f;

    private float timeSinceLastSpawn;
    private float randomSpawnDelay;

    public float minSpawnTime = 3.0f; //The minimum amount of time between squid spawns
    public float maxSpawnTime = 5.0f; //The maximum amount of time between squid spawns

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Tank");
        randomSpawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (doSpawn)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= randomSpawnDelay)
            {
                StartCoroutine("SpawnAirSquid");
                timeSinceLastSpawn = 0;
                randomSpawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
            }
        }
    }

    IEnumerator SpawnAirSquidDelay()
    {
        float spawnDelay = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(spawnDelay);
        SpawnAirSquid();
    }

    void SpawnAirSquid()
    {
        //float spawnAngle = Random.Range(10.0f, 170.0f);
        //Debug.Log(CosDeg(spawnAngle));
        Vector2 spawnPos = new Vector2(player.transform.position.x + Random.Range(-25, 25), player.transform.position.y + OSdistanceY);
        Instantiate(airSquidPrefab, spawnPos, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            doSpawn = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doSpawn = false;
        }
    }
}
