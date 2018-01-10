using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public static class GeneralData {

    private static float fossils;

    public static float Fossils
    {
        get {
            return fossils;
        }
        set {
            fossils = value;
        }
    }

}
