/* Version 1.0 Author Mike Young 21/11/2017
 / This file is for checking whether the player is touching the ground or not.
 / If the player is touching the ground, they can jump. Otherwise, they cannot.
 / It does this using a box collider as a trigger. If the colliders overlapping another
 / object the player can jump/
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    
    PlayerControllerScript player;

	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<PlayerControllerScript>();
    }
	
    
    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }

    //make sure that if the player is not grounded it remains that way till a change occurs
    void Update()
    {
        if(!player.grounded)
        player.grounded = false;
    }
}