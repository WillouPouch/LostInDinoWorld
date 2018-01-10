using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------------------------------
//
//  Name:   FlyAway.cs
//
//  Desc:   FlyAway animation (Ingredient and Fossil)
//
//
//  Last modification :
//      RM - 17/11/2017 : init version
//------------------------------------------------------------------------

public class FlyAway : MonoBehaviour {

    private bool isAnimated;
    public float speedForce;
    private float alpha;

    // Use this for initialization
    void Start () {

        isAnimated = false;
        alpha = 1;

    }
	
	// Update is called once per frame
	void Update () {

        if (isAnimated) {
            alpha -= Time.deltaTime;
            
            if(alpha <= 0) {
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                gameObject.SetActive(false);
                isAnimated = false;
            }
            else {
                transform.Translate(Vector2.up * speedForce * Time.deltaTime);
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
            }
        }
		
	}

    public void startAnimation() {
        isAnimated = true;
    }

}
