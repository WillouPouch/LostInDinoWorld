using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//------------------------------------------------------------------------
//
//  Name:   MovingPlatform.cs
//
//  Desc:   Define the behavior of a moving platform
//
//  Attachment : This class is used in the "MovingPlatform" GameObject
//
//  Last modification :
//      RM - 03/11/2017 : Init version
//------------------------------------------------------------------------

public class DetectionZone : MonoBehaviour {

    private bool playerInZone;

    private void Start() {
        playerInZone = false;
    }

    // When something triggers the detection's zone
    void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "PlayerGround") {
            playerInZone = true;
            /*Transform player = other.transform.parent;
			player.transform.SetParent (this.transform);*/
        }
	}


    // When something leaves the detection's zone
    void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "PlayerGround") {
            playerInZone = false;
            /*Transform player = other.transform.parent;
			player.transform.SetParent (null);*/
		}
	}

    public bool isPlayerInZone() {
        return playerInZone;
    }

}
