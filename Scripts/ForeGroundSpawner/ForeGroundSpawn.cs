using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeGroundSpawn : MonoBehaviour {

  //  private GameObject[] backgrounds;
    private GameObject[] grounds;

    private float lastGroundX;
    private float lastBgX;

    void Awake () {
        grounds = GameObject.FindGameObjectsWithTag("Foreground");
 //       backgrounds = GameObject.FindGameObjectsWithTag("Background");

        lastGroundX = grounds[0].transform.position.x;
//        lastBgX = backgrounds[0].transform.position.x;

        for (int i = 1; i < grounds.Length; i++)
        {
            if (lastGroundX < grounds[i].transform.position.x)
            {
                lastGroundX = grounds[i].transform.position.x;
            }
        }
/*
        for (int i = 1; i < backgrounds.Length; i++)
        {
            if (lastBgX < backgrounds[i].transform.position.x)
            {
                lastBgX = backgrounds[i].transform.position.x;
            }
        } */
    }
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Foreground")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastGroundX + width;
            target.transform.position = temp;
            lastGroundX = temp.x;
        }

    /*    else if (target.tag == "Background")
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastBgX + width;
            target.transform.position = temp;
            lastBgX = temp.x;
        } */
    }
}
