using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public GameObject panel;
    public Text distanceText, fossilDistanceText, fruitText;
    public Text enemiesText, fossilEnemiesText;
    public Text bonusText, fossilBonusText;
    public Text totalFossils;

    private float countFossils, fossilDistance;
    private FossilSystem fossilSystem;
    private GameObject player;
    private PlayerController playerScript;
    private IngredientManager ingredientManager;
    private int levelCount, levelPonderation;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fossilSystem = player.GetComponent<FossilSystem>();
        playerScript = player.GetComponent<PlayerController>();
        ingredientManager = player.GetComponent<IngredientManager>();

        // Disable panel
        HidePanel();
    }

    public void HidePanel()
    {
        panel.gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        panel.gameObject.SetActive(true);
        calculateScore();
       
    }

    public void calculateScore()
    {
        //-------------INGREDIENTS
        IngredientQuantity ingredientQuantity = ingredientManager.getIngredientsOfLevel(1);
        fruitText.text = ingredientQuantity.actual.ToString() + "/" + ingredientQuantity.max.ToString();

        //------------FOSSILS

        //distance

        float distance = fossilSystem.getDistance();

        if (distance < 0)
        {
            distanceText.text = "0";
            fossilDistanceText.text = "0";
        } else
        {
            distanceText.text = distance.ToString("F2");

            fossilDistance = distance * 2;
            fossilDistanceText.text = fossilDistance.ToString("F0");
        }

        //enemieskilled
        int enemiesKilled = fossilSystem.getEnemiesKilled();

        enemiesText.text = enemiesKilled.ToString("F0");
        fossilEnemiesText.text = enemiesKilled.ToString("F0");

        //bonuses
        bonusText.text = levelCount.ToString("F0");
        fossilBonusText.text = levelCount.ToString("F0");

        //total
        countFossils = fossilDistance + enemiesKilled + levelCount;
        totalFossils.text = countFossils.ToString("F0");
    }

    public void ChangeLevel(int prevLevel, int nextLevel)
    {
        switch (nextLevel)
        {
            case 2: case 3:
                levelPonderation = 10;
                break;
            case 4: case 5:
                levelPonderation = 15;
                break;
            case 6:
                levelPonderation = 20;
                break;
            default:
                levelPonderation = 30;
                break;

        }

        levelCount += levelPonderation;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToStore()
    {
        SceneManager.LoadScene(6);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(5);
    }
}