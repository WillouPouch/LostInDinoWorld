using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//------------------------------------------------------------------------
//
//  Name:   ParallaxScript.cs
//
//  Desc:   Makes the Layers move so that the player seem moving too
//
//  Attachment : This class is used in all the background "Layers" child of "Parallax"
//
//  Last modification : AA (01/11/2017)
//
//------------------------------------------------------------------------


public class ParallaxScript : MonoBehaviour {

    private float offset;           // Scrolling offset
    public int ScrollingSpeed;      // Layer's Speed scrolling
    public GameObject Player;       // The player 

	
	// Update is called once per frame
	void Update () {

        // Set the offset (divising it by the ScrollingSpeed gives it a 3D look as every layer has it own speed)
        offset = Player.transform.position.x / ScrollingSpeed;

        // Move the layers by changing the textureOffset
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));

	}
}
