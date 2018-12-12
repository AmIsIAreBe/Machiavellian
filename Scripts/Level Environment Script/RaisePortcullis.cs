using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisePortcullis : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        Rigidbody2D rigi;
        hit = new RaycastHit2D();
        rigi = new Rigidbody2D();

        hit = Physics2D.Raycast(transform.position, Vector2.left, 100);
        //do this if hit is true
        if (hit)
        {
            //do this if the hit was the player by referencing the tag name
            if (hit.collider.name == "Player")
            {
                rigi = GetComponentInParent<Rigidbody2D>(); 
                rigi.AddForce(new Vector2(0, 99999));
            }
        }
    }
}
