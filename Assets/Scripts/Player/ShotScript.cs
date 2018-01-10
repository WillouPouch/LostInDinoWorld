using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public int damageAttack = 1;

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;                  
    private GroundEnemiesAI dinoGroundHealth;

    void Start()
    {
        Destroy(gameObject, 20);
    }
    void Update()
    {
        // Mouvement du projectile
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
    }

    void FixedUpdate()
    {
        if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

        // Apply movement to the rigidbody
        rigidbodyComponent.velocity = movement;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GroundDino"))
        {
            dinoGroundHealth = other.gameObject.GetComponent<GroundEnemiesAI>();

            dinoGroundHealth.DinoHurt(damageAttack);

            //On détruit le projectile a la collision avec l'ennemi
            Destroy(gameObject);
        }
    }

  
}

