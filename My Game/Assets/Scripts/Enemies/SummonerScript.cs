using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVS.AIPlayerDetector;



public class SummonerScript : Enemy
{

    private Rigidbody2D rb;
    private BoxCollider2D bc2;
    [SerializeField] LayerMask lm;

    // Player Detection Variables.
    [SerializeField] AIPlayerDetector detector;
    bool isPursuing;

    //Patrolling Variables
    float waitTime;
    public float startWaitTime;
    public Transform[] patrolPoints;
    int currentPointIndex;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2 = transform.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Patrolling Function
    private void Patrolling()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            if (waitTime <= 0)
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
}
