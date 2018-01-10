using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour {

    public GameObject panelWeapon, panelArmor, panelAbilities;
    public Button weapon, armor, abilities;
    public Color active, unactive;

    private ColorBlock abilColor, weaponColor, armorColor;


    public void Update()
    {
        if (panelWeapon.activeSelf)
        {
            weaponColor = weapon.colors;
            weaponColor.normalColor = active;
            weapon.colors = weaponColor;

            armorColor = armor.colors;
            armorColor.normalColor = unactive;
            armor.colors = armorColor;

            abilColor = abilities.colors;
            abilColor.normalColor = unactive;
            abilities.colors = abilColor;
        } else if(panelArmor.activeSelf)
        {
            weaponColor = weapon.colors;
            weaponColor.normalColor = unactive;
            weapon.colors = weaponColor;

            armorColor = armor.colors;
            armorColor.normalColor = active;
            armor.colors = armorColor;

            abilColor = abilities.colors;
            abilColor.normalColor = unactive;
            abilities.colors = abilColor;

        } else if (panelAbilities.activeSelf)
        {
            weaponColor = weapon.colors;
            weaponColor.normalColor = unactive;
            weapon.colors = weaponColor;

            armorColor = armor.colors;
            armorColor.normalColor = unactive;
            armor.colors = armorColor;

            abilColor = abilities.colors;
            abilColor.normalColor = active;
            abilities.colors = abilColor;

        }
    }

    private void Awake()
    {

        panelWeapon.SetActive(true);
        panelArmor.SetActive(false);
        panelAbilities.SetActive(false);

       
    }


    public void LoadPanel(int panel)
    {
        switch (panel)
        {
            case 1:
                panelWeapon.SetActive(true);
                panelArmor.SetActive(false);
                panelAbilities.SetActive(false);

               

                break;
            case 2:
                panelWeapon.SetActive(false);
                panelArmor.SetActive(true);
                panelAbilities.SetActive(false);

                

                break;
            case 3:
                panelWeapon.SetActive(false);
                panelArmor.SetActive(false);
                panelAbilities.SetActive(true);

                
                break;
        }


    }
}
