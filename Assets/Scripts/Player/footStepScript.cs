using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//------------------------------------------------------------------------
//
//  Name:   FootStepScript.cs
//
//  Desc:   This class is used to play sounds when the player walks (footsteps sound)
//
//  Attachment : This class is used in the gameobject "Ground" child of the gameObject "Player" 
//
//  Last modification : AA - 01/11/2017
//
//------------------------------------------------------------------------

public class footStepScript : MonoBehaviour {

    public AudioClip footStepSound;
    private AudioSource Audio;
    public float pitchMin=0.9f, pitchMax=1.2f, volMin=0.8f, volMax=1.2f;
    

	
	void Start () {

        // Get the AudioSource of the player
        Audio = GetComponent<AudioSource>();

    }
	
	

	void Update () {

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (!Audio.isPlaying && transform.parent.GetComponent<PlayerController>().isGrounded)
            {
                // Set the pitch accord to a random float between the min and the max pitch declared above
                Audio.pitch = Random.Range(pitchMin, pitchMax);

                // Set the volume accord to a random float between the min and the max volume declared above
                Audio.volume = Random.Range(volMin, volMax);

                // Play the sound of footsteps
                Audio.PlayOneShot(footStepSound);
            }
        }
    }
}
