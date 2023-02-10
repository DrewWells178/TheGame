using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bc2;
    [SerializeField] LayerMask lm;
    
    private Vector3 startingPosition;

    private float wallCheck = 1.5f;

    private float horizontalDirection;

    // Roaming Variables
    private float moveSpeed = 1.25f;
    private float waitTime = 2f;
    private float wait;
    private float roamDist = 4.5f;

    private bool isFacingLeft = true;

    private void Start()
    {
        startingPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
        bc2 = transform.GetComponent<BoxCollider2D>();
        wait = waitTime;
    }

    private void FixedUpdate()
    {
        //Debug.Log(wait);
        Roaming();
        //Flip();
    }

    private void Roaming()
    {
        if(wait > 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            wait -= Time.deltaTime;
            horizontalDirection = UnityEngine.Random.Range(-1,1);
            if(horizontalDirection == 0)
            {
                horizontalDirection = .5f;
            }
        }
        else
        {
            if(!isWall() && Helper.Close(startingPosition, transform.position, roamDist))
            {
                Drive(horizontalDirection);
                Flip();
            }
            else if(isWall())
            {
                if(isWallLeft())
                {
                    horizontalDirection = 1f;
                    Drive(horizontalDirection);
                    Flip();
                }
                else
                {
                    horizontalDirection = -1f;
                    Drive(horizontalDirection);
                    Flip();
                }
            }
            else
            {
                wait = waitTime;
                startingPosition = transform.position;
            }
        }
    }

    private void Drive(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    private void Flip()
    {
        if(horizontalDirection > 0 && isFacingLeft)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            isFacingLeft = !isFacingLeft;
        }
        else if(horizontalDirection < 0 && !isFacingLeft)
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            isFacingLeft = !isFacingLeft;
        } 
    }

    private bool isWall()
    {
       if(isWallLeft() || isWallRight())
       {
            return true;
       }
       else
       {
        return false;
       }
    }

    private bool isWallRight()
    {
        RaycastHit2D rayCastWallCheck = Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size * .7f, 0f, Vector2.right, wallCheck, lm);
        return rayCastWallCheck.collider != null;
    }

    private bool isWallLeft()
    {
        RaycastHit2D rayCastWallCheck = Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size * .7f, 0f, Vector2.left, wallCheck, lm);
        return rayCastWallCheck.collider != null;
    }
}
