using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float health = 100;

    // public GameObject deathEffect;
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate() some gameObject death effect
        // GameOver
        Destroy(gameObject);
    }
}
