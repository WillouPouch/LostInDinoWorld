using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevelManager : MonoBehaviour {

    int prevLevel = 1;
    int nextLevel;
    public GameObject panel;
    public GameObject playerObject;
    private GameOverScript gameOverScript;
    private IngredientManager ingredientManager;

	// Use this for initialization
	void Start () {
	}

    void Awake()
    {
        gameOverScript = panel.gameObject.GetComponent<GameOverScript>();
        ingredientManager = playerObject.gameObject.GetComponent<IngredientManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerGround") && this.GetComponent<Collider2D>().isTrigger)
        {
            nextLevel = prevLevel + 1;
            gameOverScript.ChangeLevel(prevLevel, nextLevel);
            ingredientManager.ChangeLevel(prevLevel, nextLevel);
            prevLevel = nextLevel;
        }
        
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<Collider2D>().isTrigger = false;
    }

}
