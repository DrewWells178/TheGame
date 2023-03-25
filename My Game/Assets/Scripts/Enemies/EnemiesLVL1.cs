using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesLVL1 : MonoBehaviour
{
    public float health;
    public float speed;
    public int damage;
    

    [HideInInspector]
    public Transform player;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Enemy taking damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
