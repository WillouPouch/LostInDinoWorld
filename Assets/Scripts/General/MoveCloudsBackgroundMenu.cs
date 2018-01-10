using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloudsBackgroundMenu : MonoBehaviour {
    
    public float speedForce;
    private float oneDirectionMovingTime;
    public float timeLeft;
    public bool movingRight;

    // Use this for initialization
    void Start()
    {
        speedForce = 5;
        movingRight = true;
        oneDirectionMovingTime = 3;
        timeLeft = oneDirectionMovingTime;

    }

    // Update is called once per frame
    void Update()
    {
        
        timeLeft -= Time.deltaTime;
        //Change direction if timeLeft expired
        if (timeLeft <= 0)
        {
            movingRight = !movingRight;
            timeLeft = oneDirectionMovingTime;
        }

        if (movingRight) transform.Translate(Vector2.right * speedForce * Time.deltaTime);
        else transform.Translate(Vector2.left * speedForce * Time.deltaTime);
    }
}
