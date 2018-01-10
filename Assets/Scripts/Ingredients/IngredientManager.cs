using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//------------------------------------------------------------------------
//
//  Name:   IngredientManager.cs
//
//  Desc:   Manage ingredients collected by the player (per level)
//
//  Attachment : This class is used in the "Player" GameObject
//
//  Last modification :
//      RM - 14/11/2017 : init version
//------------------------------------------------------------------------

public class IngredientQuantity {
    public string srpiteName; //Name of the ingredient's sprite
    public uint actual; // Number of ingredients collected by the player for one ingredient
    public uint max; // Max ingredient's number for one ingredient
}

public class IngredientManager : MonoBehaviour {

    //Constants
    private const int blinkPositive = 1;
    private const int blinkNegative = 2;

    List<IngredientQuantity> ingredients;

    [SerializeField] private GameObject ingredientsCanvasGameObject;
    [SerializeField] private float yOffset;
    [SerializeField] private float sustainTime;
    private RectTransform ingredientsRectTransform;
    private float yStartingPoint;
    private float currentSustainTime;
    private bool slideDown;
    private bool slideUp;
    private bool sustain;
    private bool displayMonitor;
    private Text textToBlink;
    private float blinkTime;
    private Color blinkColor;
    public float switchColorTime;
    private float currentSwitchColorTime;

    //Color32 can be implicitly converted to and from Color
    private Color white = new Color32( 0xFF, 0xFF, 0xFF, 0xFF);
    private Color green = new Color32(0x00, 0xE6, 0x40, 0xFF);
    private Color red = new Color32(0xF2, 0x26, 0x13, 0xFF);

    // Use this for initialization
    void Start () {

        ingredients = new List<IngredientQuantity>();
        ingredients.Add( new IngredientQuantity{ srpiteName = "fruit", actual = 0, max = 2 });       // 1st level ingredient
        ingredients.Add( new IngredientQuantity { srpiteName = "insect", actual = 0, max = 1 });     // 2nd level ingredient
        ingredients.Add( new IngredientQuantity { srpiteName = "cactus", actual = 0, max = 2 });     // 3rd level ingredient
        ingredients.Add( new IngredientQuantity { srpiteName = "diamond", actual = 0, max = 2 });    // 4th level ingredient
        ingredients.Add( new IngredientQuantity { srpiteName = "snowflake", actual = 0, max = 4 });  // 5th level ingredient
        ingredients.Add( new IngredientQuantity { srpiteName = "bone", actual = 0, max = 1 });       // 6th level ingredient

        currentSustainTime = sustainTime;

        displayMonitor = false;
        slideDown = true;
        sustain = false;
        slideUp = false;

        textToBlink = null;
        blinkTime = 0;

        currentSwitchColorTime = switchColorTime;
    }

    void Awake() {

        ingredientsRectTransform = GameObject.Find("IngredientsCanvas").GetComponent<RectTransform>();
        yStartingPoint = ingredientsRectTransform.position.y;
    }


    void Update() {

        if (displayMonitor) {
            showMonitor();
            blinkIngredientText();
        }
        if (!displayMonitor && textToBlink != null) resetBlinkingText();

    }


    // This method is called when the player catch a ingredient
    public void OnTriggerEnter2D(Collider2D other) {
        //Increment carried ingredient number
        if (other.gameObject.CompareTag("Ingredient")) {

            //Only one player's collider need to detect the collision with an ingredient
            other.gameObject.tag = "Untagged";

            other.gameObject.GetComponent<FlyAway>().startAnimation();

            string spriteName = other.gameObject.GetComponent<SpriteRenderer>().sprite.texture.name;
            ingredients.Find(c => c.srpiteName == spriteName).actual++;

            updateMonitorData();
            blinkIngredientText(GameObject.Find(spriteName + "Text").gameObject.GetComponent<Text>(), blinkPositive);
            showMonitor(true);
        }
    }

    //Update datas of monitor with the variable "ingredients"
    private void updateMonitorData() {

        foreach (var ingredient in ingredients) {
            GameObject.Find(ingredient.srpiteName + "Text").gameObject.GetComponent<Text>().text = ingredient.actual + " / " + ingredient.max;
        }

    }

    //Show monitor of ingredients during game
    private void showMonitor(bool newAnimation = false) {

        if (newAnimation)  displayMonitor = true;

        //Sliding down
        if (slideDown) {

            if (yStartingPoint - ingredientsRectTransform.position.y < yOffset) {
                ingredientsRectTransform.transform.Translate(Vector2.down * 120 * Time.deltaTime);
            }
            else {
                slideDown = false;
                sustain = true;
            }
        }
        //Sustaining canvas
        else if (sustain) {

            if (newAnimation) currentSustainTime = sustainTime;
            else {

                currentSustainTime -= Time.deltaTime;
                if (currentSustainTime <= 0) {
                    currentSustainTime = sustainTime;
                    sustain = false;
                    slideUp = true;
                }
            }
        }
        //Sliding up
        else if (slideUp) {

            if (newAnimation) {
                slideDown = true;
                slideUp = false;
            }
            else if (yStartingPoint - ingredientsRectTransform.position.y > 0) {
                ingredientsRectTransform.transform.Translate(Vector2.up * 120 * Time.deltaTime);
            }
            else {
                //End of the animation
                displayMonitor = false;
                //reset conditions for the next animation
                slideDown = true;
                slideUp = false;
            }
        }

    }

    private void blinkIngredientText(Text text=null, int blinkState = 0) {

        if (blinkState == blinkPositive) blinkColor = green;
        else if(blinkState == blinkNegative) blinkColor = red;

        if (text != null) {
            if (textToBlink != null) resetBlinkingText();
            textToBlink = text;
        }

        if(textToBlink != null) {
            if (currentSwitchColorTime >= 0) currentSwitchColorTime -= Time.deltaTime;
            else {
                currentSwitchColorTime = switchColorTime;
                if (textToBlink.color == white) textToBlink.color = blinkColor;
                else textToBlink.color = white;
            }
        }

    }

    private void resetBlinkingText() {
        currentSwitchColorTime = switchColorTime;
        textToBlink.color = white;
        textToBlink = null;
    }


    public IngredientQuantity getIngredientsOfLevel(int levelNumber) {
        return ingredients[levelNumber - 1];
    }

    public void ChangeLevel(int prevLevel, int nextLevel) {

        IngredientQuantity ingredientQuantity = ingredients[prevLevel - 1];
        if (ingredientQuantity.actual < ingredientQuantity.max) {
            showMonitor(true);
            blinkIngredientText(GameObject.Find(ingredientQuantity.srpiteName + "Text").gameObject.GetComponent<Text>(), blinkNegative);
        }
    }

}
