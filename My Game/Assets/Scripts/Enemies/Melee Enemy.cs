using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemiesLVL1
{
    public float stopDistance;
    private float attackTime;
    float waitTime;
    public float startWaitTime;

    
    public Transform[] patrolPoints;
    int currentPointIndex;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (detector.PlayerDetected)
        {
            isPursuing = true;
        }
        if (!isPursuing)
        {
            Patrolling();
        }
        else
        {
            PursueAttack();
        }
      
    }


    //Patrolling Function
    private void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            if(waitTime <= 0)
            {
                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex++;
                }
                else
                {
                    currentPointIndex = 0;
                }
                waitTime = 0;
            }
            else { waitTime -= Time.deltaTime; }
            

        }
    } 
    private void PursueAttack()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
