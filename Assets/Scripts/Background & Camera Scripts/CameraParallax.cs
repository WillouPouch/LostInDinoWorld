using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//------------------------------------------------------------------------
//
//  Name:   CameraParallax.cs
//
//  Desc:   Makes the Main Camera and the background move with the player
//
//  Attachment : This class is used in the "Main Camera"
//
//  Last modification : Ayoub Al Haddan (01/11/2017)
//
//------------------------------------------------------------------------


public class CameraParallax : MonoBehaviour {

    public GameObject Player;
    public float minCameraX;
    public float maxCameraX;

	
	// Update is called once per frame
	void Update () {

        // Translate the Main Camera and the background (Changing juste the X position to the position of the player)
        float x = transform.position.x;
        if (Player.transform.position.x >= minCameraX && Player.transform.position.x <= maxCameraX) x = Player.transform.position.x;
        if (Player.transform.position.x < minCameraX) x = minCameraX;
        if (Player.transform.position.x > maxCameraX) x = maxCameraX;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

	}
}
