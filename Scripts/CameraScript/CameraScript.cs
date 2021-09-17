using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public static float offSetX;


	void Start () {
		
	}
	
	void Update () {
        if (PlayerMove.instance != null) {
            if (PlayerMove.instance.isAlive) {
                CameraMove();
            }
        }
	}

    void CameraMove() {
        Vector3 temp = transform.position;
        temp.x = PlayerMove.instance.GetPositionX() + offSetX;
        transform.position = temp;
    }
}
