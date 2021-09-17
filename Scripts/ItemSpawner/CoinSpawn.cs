using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour {

    public GameObject[] coin;
    public Transform spawnPoint;

    private float spawnTime = 10f;
    private float spawnNext = 20f;

    private float maxHeight = 3f;
    private float minHeight = -2f;

    private float timer;

	void Start () {
        timer = Time.time;
	}
	
	void Update () {
        float t = Time.time - timer;

        if (t >= spawnTime) {
            transform.position = new Vector3(spawnPoint.position.x, Random.Range(maxHeight, minHeight));
            Quaternion spawnRotation = Quaternion.identity;
            int rand = Random.Range(0, 2);
            Instantiate(coin[rand], transform.position, transform.rotation);
            spawnTime = Time.time + spawnNext;
        }
	}
}
