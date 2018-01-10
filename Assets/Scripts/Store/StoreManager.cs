using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {

    public Text fossilText;
    public Text itemTitle, itemDescription, itemPrice;
    public GameObject infoPanel;

    private float newFossilAmount;

	// Use this for initialization
	void Awake () {

        infoPanel.SetActive(false);



        //TEMP
        //GeneralData.Fossils = 30;
    }
	
	// Update is called once per frame
	void Update () {
        fossilText.text = GeneralData.Fossils.ToString("F0");
    }

    public void OnClickItem(Button button)
    {
        infoPanel.SetActive(true);

        string buttonName = button.name;

        itemTitle.text = buttonName;
        itemDescription.text = StoreInfo.GetItem(buttonName)[1];
        itemPrice.text = StoreInfo.GetItem(buttonName)[2];

    }

    public void OnClickBuy()
    {
        string itemName = itemTitle.text.ToString();

        float price; 
        float.TryParse(StoreInfo.GetItem(itemName)[2], out price);

        if (GeneralData.Fossils > price && StoreInfo.GetItem(itemName)[3] == "unlocked" && StoreInfo.GetItem(itemName)[4] == "notpurchased") {

            print("Weapon purchased");
            GeneralData.Fossils -= price;
            //UNLOCK WEAPON HERE 
        }
    }


    public void ClickClose()
    {
        infoPanel.SetActive(false);
    }

}
