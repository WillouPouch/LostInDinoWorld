using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FossilSystem : MonoBehaviour {

    private float distance = 0f;
    public Text distanceText;
    private float lastPosition;
    private int smallDinosKilled, mediumDinosKilled, bigDinosKilled = 0;    //To count the dinos killed by player

    // Use this for initialization
    void Start () {
        lastPosition = transform.position.x/100;
    }
	
	// Update is called once per frame
	void Update () {
        calculateDistance();
        showDistance();
    }

    //-------------------
    //  DISTANCE
    //-------------------
    void calculateDistance()
    {
        distance += (transform.position.x/100 - lastPosition);
        lastPosition = transform.position.x/100;
    }
    public void showDistance()
    {
        if(distance < 0) distanceText.text = "0 km";
        else distanceText.text = distance.ToString("F2") + " km";
    }

    public float getDistance()
    {
        return distance;
    }

    //-------------------
    //  ENEMIES
    //-------------------
    
    public void countDinoKills(int dinoHealth)
    {
        //Count how many dinos killed
        switch (dinoHealth)
        {
            case 3:
            case 6:
                smallDinosKilled++;
                break;
            case 9:
            case 12:
                mediumDinosKilled++;
                break;
            case 15:
            case 18:
                bigDinosKilled++;
                break;
        }

    }

    public int getEnemiesKilled()
    {
        return 1 * smallDinosKilled + 2 * mediumDinosKilled + 3 * bigDinosKilled;
    }

    //-------------------
    //  BONUSES
    //-------------------
    public float getBonuses()
    {
        return 0;
    }
}
