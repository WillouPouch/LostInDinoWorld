using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemiesAI : MonoBehaviour {

    // Private :
    private Animator animator;
    private GameObject player;
    private PlayerController playerHealth;
    private bool isFacingRight = false;             // To know when to change Dinos' direction
    private int currentHealth;                      // The current Health of the Dino             
    private bool dead;                              // To know when the Dino is dead
    private float startingPosX;                     // To know the starting pos x and use it with the moving range
    private bool Returnback = false;                // Flip to go back to the starting point
    private FossilSystem fossilSystem;
    private AudioSource Audio;                      // Audio source 

    // Public :
    public Transform target;                        // Set the target to go after 
    public float speed;                             // Moving speed
    public int damageAttack = 5;                    // The damage caused by an attack
    public float attackRate = 0.5f;                 // Time between attacks
    public int startingHealth = 3;                  // The starting health of the Dino
    public float vanichingTime = 2.5f;              // Time before the Dino vanishes after death
    public float movingRangeRight = 5;              // The range where the dino can move right
    public float movingRangeLeft = 5;               // The range where the dino can move left
    public bool delimiter = false;                  // Check if the dino has delimiter or not
    public AudioClip StepsSound;                    // The sound of dino walking



    //Triggers
    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject == player && !dead && !animator.GetCurrentAnimatorStateInfo(0).IsName("Raptor_Attack")) Attack();
    }

    private void Start() {
        dead = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerController>();
        fossilSystem = player.GetComponent<FossilSystem>();
        animator = GetComponent<Animator>();
        currentHealth = startingHealth;
        startingPosX = transform.position.x;
        animator.SetBool("Alive", true);

        // Get the AudioSource of the player
        Audio = GetComponent<AudioSource>();
    }


    void Update() {

        if (!dead) {

            if (MovingRange() && !animator.GetCurrentAnimatorStateInfo(0).IsName("Raptor_Attack")) {
                Run();
                
                // Play the sound of footsteps
                if (!Audio.isPlaying)
                {
                    Audio.PlayOneShot(StepsSound);
                }

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                //Flip sprite if necessary
                Flip();
            }

        }
    }


    void FixedUpdate() {

    }

    private void Run() {
        animator.SetBool("Run", true);
    }

    private void StopRun() {
        animator.SetBool("Run", false);
    }

    private void Attack() {
        StopRun();
        animator.SetTrigger("Attack");
        playerHealth.playerHurt(damageAttack, isFacingRight);
    }

    public void DinoHurt(int amount) {
        if (!dead) {
            currentHealth -= amount;

            if (currentHealth == 0) DinoDead();
            else {
                animator.SetTrigger("Hurt");
            }
        }
    }

    public void DinoDead() {
        dead = true;

        animator.SetTrigger("Dead");
        animator.SetBool("Alive", false);

        //Count dinos killed by player
        fossilSystem.countDinoKills(startingHealth);

        //this.gameObject.SetActive(false);
        Destroy(this.gameObject, vanichingTime); // enlever le dino du jeu
    }


    // Filp the Dino to face the correct direction 
    private void Flip() {
        if ((!isFacingRight && target.position.x > transform.position.x) || (isFacingRight && target.position.x < transform.position.x)) {

            isFacingRight = !isFacingRight;

            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }


    // Return The current health of the Dino to use it in other class (ex : PlayerController)
    public int getCurrentHealth() {
        return currentHealth;
    }



    // To know if the Dino still have range to move
    private bool MovingRange() {
        if (delimiter) {
            if (transform.position.x > movingRangeLeft && transform.position.x < movingRangeRight)
                return true;
        }
        else {
            if (transform.position.x + 24 > target.position.x && transform.position.x - 24 < target.position.x)
                return true;
        }

        return false;
    }


    /*// Go back in the start pos 
    private bool goBack()
    {
        if ((transform.position.x+24 < target.position.x || transform.position.x - 24 > target.position.x) && transform.position.x!=startingPosX)
            return true;
        return false;
    }*/
}