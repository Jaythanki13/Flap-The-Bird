using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnemyDestroy : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin") {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Enemy") {
            Destroy(collision.gameObject);
        }
    }
}
