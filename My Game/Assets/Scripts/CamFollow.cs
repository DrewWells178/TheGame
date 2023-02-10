using System;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    
    [SerializeField] Camera cam;
    [SerializeField] Transform character;
    [SerializeField] float threshold;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (character.position + mousePos) / 2f;
        
        targetPos.x = Helper.Clamp(targetPos.x, -threshold + character.position.x, threshold + character.position.x);
        targetPos.y = Helper.Clamp(targetPos.y, -threshold + character.position.y, threshold + character.position.y);
        this.transform.position = targetPos;
    }
}
