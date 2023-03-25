using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketScript : MonoBehaviour
{
    public Transform tip;
    public Transform crosshair;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    public float speed = 20f;
    public float rotateSpeed = 200f;

    public float damage = 30f;

    private Vector3 directions;
    
    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.FindGameObjectWithTag("Crosshair").transform;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        directions = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(directions.x, directions.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotate and travel towards mouse position
        Vector2 direction = (Vector2)crosshair.position - rb.position;
        direction.Normalize();
        //Vector2 face = (Vector2)tip.position - (Vector2)transform.position;
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        

        if(hitInfo.name != "Player" && hitInfo.name != "Rocket(Clone)")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
