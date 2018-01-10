using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GunAttack : MonoBehaviour {
    // Public : 
    public int damageAttack = 1;                                // Damage force of the arme
    public AudioClip soundHit;
    public Transform shotPrefab;
    private GameObject player;

    // Private : 
    private bool attack = false;                                // To declare an attack or not
    private bool EnemyCollision = false;                        // if there is a Collision
    private GameObject dinoGround;                              // with whome is the collision 
    private GroundEnemiesAI dinoGroundHealth;                   // The script of the Dino with whome there is a collision
    private Animator animator;                                  // Players' animator
    private AudioSource audioSource;                            // AudioSource to play the sound of the arme
    [SerializeField]
    private bool keyboardOrAndroidInputs;                       // For attack input on android


    // Use this for initialization
    void Start()
    {
        animator = this.GetComponentInParent<Animator>();
        audioSource = this.GetComponentInParent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboardOrAndroidInputs)
        {
            if (Input.GetKeyDown(KeyCode.H)) attack = true;
        }
        else
        {
            if (CrossPlatformInputManager.GetButtonDown("Attack")) attack = true;
        }

        if (attack)
        {
            animator.SetTrigger("Rshoot");
            audioSource.PlayOneShot(soundHit);   // play hit sound

            //instanciate shot at player position
            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = player.transform.position;
            

            attack = false;
        }
    }
}
