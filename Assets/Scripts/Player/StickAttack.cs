using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class StickAttack : MonoBehaviour {

    // Public : 
    public int damageAttack = 1;                                // Damage force of the arme
    public AudioClip soundHit;                                  // Arme sound

    // Private : 
    private bool attack = false;                                // To declare an attack or not
    private bool EnemyCollision = false;                        // if there is a Collision
    private GameObject dinoGround;                              // with whome is the collision 
    private GroundEnemiesAI dinoGroundHealth;                   // The script of the Dino with whome there is a collision
    private Animator animator;                                  // Players' animator
    private AudioSource audioSource;                            // AudioSource to play the sound of the arme
    [SerializeField] private bool keyboardOrAndroidInputs;      // For attack input on android


    // Use this for initialization
    void Start() {
        animator = this.GetComponentInParent<Animator>();
        audioSource = this.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
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
            animator.SetTrigger("hit");
            audioSource.PlayOneShot(soundHit);   // play hit sound

            if (EnemyCollision && dinoGroundHealth.getCurrentHealth() > 0)
            {
                dinoGroundHealth.DinoHurt(damageAttack);
            }

            attack = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundDino"))
        {
            dinoGround = other.gameObject;
            dinoGroundHealth = dinoGround.GetComponent<GroundEnemiesAI>();
            
            EnemyCollision = true;

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundDino")) EnemyCollision = false;
    }


}
