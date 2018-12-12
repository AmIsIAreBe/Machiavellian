using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerForAttack : MonoBehaviour {
 
    public bool attackInRange;
	// Use this for initialization
	void Start () {
        attackInRange = false;
	}
	
	// Update is called once per frame
	public void Update () {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector3.forward, 100);
        Debug.DrawLine(transform.position, hit.point, Color.cyan);

        if (hit)
        {
            if (hit.collider.name == "Player")
            {
                attackInRange = true;
            }
        }
        else { attackInRange = false; }
    }
}
