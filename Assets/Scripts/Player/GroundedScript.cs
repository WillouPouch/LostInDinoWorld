using System.Collections;
using UnityEngine;



//------------------------------------------------------------------------
//
//  Name:   GroundedScript.cs
//
//  Desc:   This class is used to know if the player is on the ground or not
//
//  Attachment : This class is used in the gameobject "Ground" child of the gameObject "Player" 
//
//  Last modification : AA - 01/11/2017
//
//------------------------------------------------------------------------


public class GroundedScript : MonoBehaviour {

    private AudioSource Audio;
    public AudioClip GroundedSound;


    void Start()
    {
        // Get the AudioSource of the player
        Audio = GetComponent<AudioSource>();
    }

    // When something triggers (Enters) in the box collider beneath the player then the player is on the ground
    void OnTriggerEnter2D (Collider2D other)
    {
		if (other.gameObject.tag != "DetectionZone" && other.gameObject.tag != "LevelChange") {
			// Change the bool in the playerController Class to true
			transform.parent.GetComponent<PlayerController> ().isGrounded = true;

			// Set the pitch and the volume of the AudiSource
			Audio.pitch = 1;
			Audio.volume = 1;

			// Play the footsteps on the ground sound
			Audio.PlayOneShot (GroundedSound);
		}
    }


    // When it's no longer in the boxCollider beneath the player then the player is not on the ground
    void OnTriggerExit2D(Collider2D other)
    {
		if (other.gameObject.tag != "DetectionZone" && other.gameObject.tag != "LevelChange") {
			transform.parent.GetComponent<PlayerController> ().isGrounded = false;
		}
    }


}
