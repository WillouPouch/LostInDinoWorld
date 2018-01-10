using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour {

    public AudioClip rockSound;
    public int attackDamage = 10;               // The amount of health taken away per attack.
    private GameObject player;
    private PlayerController playerHealth;


    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {

            // Setting up the references.
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerController>();

            playerHealth.playerHurt(attackDamage, true);


        }
        GetComponent<AudioSource>().PlayOneShot(rockSound);

    }
}
