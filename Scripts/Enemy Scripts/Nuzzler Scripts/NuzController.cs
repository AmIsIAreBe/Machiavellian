using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuzController : MonoBehaviour
{
    //Rigidid body of the nuzzler
    Rigidbody2D rigi;
    //Animator of the Nuzzler
    Animator anim;
    //Get the playing time currently
    Time time;
    //used to work out the current time
    float currentTime;
    //use to work out the current time in the future
    float futureTime;
    //used to calculate the difference in time elapsed
    float timeDifference;
    //determine which directon the Nuzzler is facing
    bool facingRight;
    //determine if the nuzzle has been hit
    bool hit;
    
    // Use this for initialization
    void Start()
    {
        //instantiate rigid body, animator, and get the current time
        rigi = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentTime = Time.time;
    }

    // Update is called once per frame
    public void Update()
    {
        //instantiate the DetectPlayerForAttackScript in order too detect if the Nuzzler is in range of the player to perform an attack
        DetectPlayerForAttack detect;
        detect = GetComponentInChildren<DetectPlayerForAttack>();

        //if the enemy is in range, attack. otherwise do not attack.
        if (detect.attackInRange == true)
        {
            anim.SetBool("AttackInRange", true);
        }
        else
        {
            anim.SetBool("AttackInRange", false);
        }
    }

    void FixedUpdate()
    {
        //Instantiate the NuzzlerHealthManger to determine if a hit occured and to have a reaction
        NuzzlerHealthManager nuz = GetComponent<NuzzlerHealthManager>();
        //get the elapsed time
        futureTime = Time.time;
        //check the difference in time
        timeDifference = futureTime - currentTime;
        //Debug.Log(timeDifference);

        //check if the time has been less than 10
        if (timeDifference <= 10)
        {
            //move left
            rigi.velocity = new Vector2(-20, rigi.velocity.y);
            //trigger animation to play
            anim.SetFloat("Speed", Mathf.Abs(1));
            //do this if hit by player
            if (nuz.hit == true)
            {
                //move in the opposite direction
                rigi.velocity = new Vector2(-40, rigi.velocity.y);
                anim.SetFloat("Speed", Mathf.Abs(1));
            }
            else if (rigi.velocity.x < 0 && facingRight)
            {
                //nuzzlers direction has changed and the players scale needs to face the other way
                Flip();
            }
        }
        //check if the time has been longer than 10 but less than 20
        else if (timeDifference > 10 && timeDifference <= 20)
        {
            //move right
            rigi.velocity = new Vector2(20, rigi.velocity.y);
            //trigger animation to play
            anim.SetFloat("Speed", Mathf.Abs(1));
            //do this if hit by player
            if (nuz.hit == true)
            {
                //move in the opposite direction
                rigi.velocity = new Vector2(40, rigi.velocity.y);
                anim.SetFloat("Speed", Mathf.Abs(1));
            }
            else if (rigi.velocity.x > 0 && !facingRight)
            {
                //nuzzlers direction has changed and the players scale needs to face the other way
                Flip();
            }
        }
        else
        {
            //reset times to repeat the process
            currentTime = Time.time;
            timeDifference = 0;
            futureTime = 0;
        }

    }

    //flip the nuzzlers scale so that it changes from facing left to right and vice versa
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}