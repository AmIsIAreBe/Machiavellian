using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    PlayerControllerScript player;
    public bool attack = false;
    public bool inputJumpCheck = false;

	// Use this for initialization
	void Start () {
        attack = false;
        inputJumpCheck = false;
        player = gameObject.GetComponent<PlayerControllerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1"))
        {
            attack = true;
        }
        else { attack = false; player.anim.SetBool("Attack", false); }

        if (Input.GetButtonDown("Jump") || Input.GetButton("Jump"))
        {
            inputJumpCheck = true;
        }
        else
        {
            inputJumpCheck = false;
            player.anim.SetBool("grounded", true);
        }
    }
}
