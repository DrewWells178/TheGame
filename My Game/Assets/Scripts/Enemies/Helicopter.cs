using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc2;
    [SerializeField] LayerMask lm;

    // *** MY ADDITIONS***

    [HideInInspector]
    public Transform player;

    // Roaming Variables
    public float moveSpeed;
    private Vector3 startingPosition;
    public float stopDistance;



    // Pursuing Variables
    // *** MY ADDITIONS ***



    // Flipping Variables
 





    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // What does this portion do?
        rb = GetComponent<Rigidbody2D>();
        bc2 = transform.GetComponent<BoxCollider2D>();
        

        // ***My additions***
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if(Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }
        }
    }
   
}
