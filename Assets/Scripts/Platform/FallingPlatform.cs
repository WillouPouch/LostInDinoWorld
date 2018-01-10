using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------------
//
//  Name:   FallingPlatform.cs
//
//  Desc:   Define the behavior of a falling platform
//
//  Attachment : This class is used in the "FallingPlatform" GameObject
//
//  Last modification :
//      RM - 09/11/2017 : Init version
//------------------------------------------------------------------------

public class FallingPlatform : MonoBehaviour {

    // GameObjects
    //-----------
    private GameObject playerGameObject;
    private DetectionZone detectionZone;
    private PlayerController playerController;

    // Other
    //-----------
    private bool isFalling;
    private float sustainedTime;
    private float playerGroundedTimeToActivate;
    private float downSpeed;

    // Use this for initialization
    void Start() {

        isFalling = false;
        sustainedTime = 0.3f;//1.5f;
        playerGroundedTimeToActivate = 0.1f;
        downSpeed = 0;

        playerGameObject = GameObject.FindWithTag("Player");
        playerController = playerGameObject.GetComponent<PlayerController>();

        Transform detectionZoneTransfom = transform.Find("DetectionZone");
        if (detectionZoneTransfom) detectionZone = detectionZoneTransfom.gameObject.GetComponent<DetectionZone>();

    }

    // Update is called once per frame
    void Update() {

        if (isFalling) fallingMovement();
        else {
            //Be sure that detectionZone exists and player is in zone
            if (detectionZone && detectionZone.isPlayerInZone()) {
                if (playerGroundedTimeToActivate <= 0) isFalling = true;
                else if (playerController.isGrounded && playerGroundedTimeToActivate >= 0) playerGroundedTimeToActivate -= Time.deltaTime;
            }
        }

    }

    private void fallingMovement() {

        if (sustainedTime >= 0) sustainedTime -= Time.deltaTime;
        else if (transform.position.y >= -70.0f) { //Note : -70.0f not clean
            downSpeed += Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y - downSpeed);
        }

    }

}
