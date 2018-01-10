using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class StoreInfo {

    
    //WEAPONS (useful if need to set)
    private static string[] pickaxe, axe, bat, sword, throwingKnife, pistol, shotgun, rifle, grenadeLaunch, portalGun;

    //---------------------------------------------
    //  WEAPONS
    //---------------------------------------------


    public static string[] GetItem(string name)
    {
        if (name == "Pickaxe") return new string[] { "Pickaxe", "Gives 1 damage", "0", "unlocked", "purchased", "using" };
        if (name == "Axe") return new string[] { "Axe", "Gives 3 damage", "25", "unlocked", "notpurchased", "notusing" };
        if (name == "Bat") return new string[] { "Bat", "Gives 5 damage", "100", "locked", "notpurchased", "notusing" };
        if (name == "Sword") return new string[] { "Sword", "Gives 6 damage", "250", "locked", "notpurchased", "notusing" };
        if (name == "ThrowingKnife") return new string[] { "Throwing Knife", "Gives 6 damage", "500", "locked", "notpurchased", "notusing" };
        if (name == "Pistol") return new string[] { "Pistol", "Gives 8 damage", "750", "locked", "notpurchased", "notusing" };
        if (name == "Shotgun") return new string[] { "Shotgun", "Gives 10 damage", "1000", "locked", "notpurchased", "notusing" };
        if (name == "Rifle") return new string[] { "Rifle", "Gives 14 damage", "1250", "locked", "notpurchased", "notusing" };
        if (name == "GrenadeLauncher") return new string[] { "GrenadeLauncher", "Gives 17 damage", "1500", "locked", "notpurchased", "notusing" };
        if (name == "PortalGun") return new string[] { "Portal Gun", "Gives 20 damage", "5000", "locked", "notpurchased", "notusing" };
        else return new string[] { "Item title", "Description", "0", "IsLocked","IsPurchased", "IsUsing" };
    }
}
