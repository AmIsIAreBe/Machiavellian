using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingClouds : MonoBehaviour {
    public Rigidbody2D cloud;
    
    // Use this for initialization
    void Start () {
        cloud = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
    void Update() {
        cloud.velocity = new Vector2(-5, cloud.velocity.y);
    }   
}