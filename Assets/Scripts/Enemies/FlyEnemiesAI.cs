using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemiesAI : MonoBehaviour {

    // Private : 
    private Animator animator;
    private GameObject player;
    private PlayerController playerHealth;
    private bool playerInRange = false;
    private AudioSource Audio;                      // Audio source 
    private int currentHealth;                      // Flying dino
    private GameObject rock;
    private float nextattack;

    // Public : 
    public float speed;
    public int startingHealth = 3;
    public AudioClip flySound;                    // The sound of dino flying
    public GameObject prefabRock;
    public float ThrowRate = 2;
    public AudioClip attackSound;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        currentHealth = startingHealth;

        // Get the AudioSource of the player
        Audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        isInRange();

        //If near player, attack
        if (playerInRange)
        {
             Attack(); 
        }

        // Play the sound of footsteps
        if (!Audio.isPlaying)
        {
            Audio.PlayOneShot(flySound);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x<-27) Destroy(this.gameObject);
    }


    // Throws some rock
    private void Attack()
    {
        if (Time.time > nextattack)
        {
            // Instancier un objet
            Vector3 v = transform.GetChild(1).gameObject.transform.position;
            rock = Instantiate(prefabRock, v, transform.GetChild(1).gameObject.transform.rotation) as GameObject;


            // Jouer le sons des tires
            Audio.PlayOneShot(attackSound);

            // Appliquer une force 
            rock.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.forward) * speed);

            // Changer nextShoot
            nextattack = Time.time + ThrowRate;

            // Detruire Bullets après un temps
            Destroy(rock, 2f);
        }
    }

    private void isInRange()
    {
        if (transform.position.x < player.transform.position.x + 5) playerInRange = true;
        if(transform.position.x < player.transform.position.x -10) playerInRange = false;
    }



    
}
