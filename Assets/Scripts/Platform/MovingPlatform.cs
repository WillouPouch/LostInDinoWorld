using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

public class MovingPlatform : MonoBehaviour {

    // GameObjects
    //-----------
    private GameObject playerGameObject;
    private DetectionZone detectionZone;
    private PlayerController playerController;

    // Others
    //-------
    public float speedForce;
    private float oneDirectionMovingTime;
    public float timeLeft;
    public bool movingRight;

    // Use this for initialization
    void Start () {
        speedForce = 5;
        movingRight = true;
        oneDirectionMovingTime = 3;
        timeLeft = oneDirectionMovingTime;

        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            playerGameObject = GameObject.FindWithTag("Player");
            playerController = playerGameObject.GetComponent<PlayerController>();
        }

        Transform detectionZoneTransfom = transform.Find("DetectionZone");
        if (detectionZoneTransfom) detectionZone = detectionZoneTransfom.gameObject.GetComponent<DetectionZone>();

    }
	
	// Update is called once per frame
	void Update () {

        if (detectionZone && SceneManager.GetActiveScene().name == "PlayScene") {
            //Check if the player is in the detection's zone
            if (detectionZone.isPlayerInZone() && playerController.isGrounded) playerGameObject.transform.SetParent(this.transform);
            else playerGameObject.transform.SetParent(null);
        }

        timeLeft -= Time.deltaTime;
        //Change direction if timeLeft expired
        if (timeLeft <= 0) {
            movingRight = !movingRight;
            timeLeft = oneDirectionMovingTime;
        }

        if (movingRight) transform.Translate(Vector2.right * speedForce * Time.deltaTime);
        else transform.Translate(Vector2.left * speedForce * Time.deltaTime);
    }

}
