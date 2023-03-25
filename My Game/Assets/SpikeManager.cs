using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    float damage = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D (Collider2D hitInfo)
    {
        PlayerScript player = hitInfo.GetComponent<PlayerScript>();
        if(player != null && hitInfo.gameObject.tag == "Player")
        {
            player.TakeStaticDamage(damage);
        }
    }     
        
    
}
