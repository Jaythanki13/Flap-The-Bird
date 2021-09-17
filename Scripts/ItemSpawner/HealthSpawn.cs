using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour {

    public GameObject health;
    public Transform spawnPoint;

    private float spawnTime = 50f;
    private float spawnNext = 100f;

    private float maxHeight = 3f;
    private float minHeight = -2f;

    private float timer;


    void Start () {
        timer = Time.time;
    }
	
	void Update () {
        float t = Time.time - timer;

        if (t >= spawnTime)
        {
            transform.position = new Vector3(spawnPoint.position.x, Random.Range(maxHeight, minHeight));
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(health, transform.position, transform.rotation);
            spawnTime = Time.time + spawnNext;
        }
    }
}
