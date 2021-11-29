using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject airSquidPrefab;
    private GameObject player;

    private float OSdistance = 24.166f;

    private float timeSinceLastSpawn;
    private float randomSpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Tank");

        randomSpawnDelay = Random.Range(3.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= randomSpawnDelay)
        {
            StartCoroutine("SpawnAirSquid");
            timeSinceLastSpawn = 0;
            randomSpawnDelay = Random.Range(3.0f, 5.0f);
        }
    }

    IEnumerator SpawnAirSquidDelay()
    {
        float spawnDelay = Random.Range(3.0f, 5.0f);
        yield return new WaitForSeconds(spawnDelay);
        SpawnAirSquid();
    }

    void SpawnAirSquid()
    {
        //Debug.Log("Spawning Squid");
        float spawnAngle = Random.Range(10.0f, 170.0f);
        Debug.Log(CosDeg(spawnAngle));
        Vector2 spawnPos = new Vector2((player.transform.position.x + CosDeg(spawnAngle)) / 2, (player.transform.position.y + SinDeg(spawnAngle)) / 2);
        Instantiate(airSquidPrefab, spawnPos, Quaternion.identity);
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
