using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    //the total health of a nuzzle, set in the inspector
    public static int playerHealth;
    //tell the player controller that it has been hit so the behavior can change
    public bool hitPlayer;
    public bool isDead = false;
    public static bool isGameOver = false;

    Animator anim;

    void Start()
    {
        playerHealth = 5;
    }


    // Update is called once per frame
    void Update()
    {
        //if the nuzzler has nomore health, kill the nuzzler
        if (playerHealth <= 0 && !isDead && !isGameOver)
        {
            anim = GetComponent<Animator>();
            anim.SetBool("IsDead", true);
            isDead = true;
            isGameOver = true;
        }
        else if (isDead == true && isGameOver)
        {

            PlayerControllerScript player = GetComponent<PlayerControllerScript>();
            Destroy(player, 2f);
            //make sure this only completes once 
            isDead = false;
        }

    }

    //when the player has been attacked, minus the damage from the nuzzlers health
    public void giveDamageToPlayer(int damagePlayer)
    {
        playerHealth -= damagePlayer;
        //set hit to true so that the controller can change behavior of the player if needed
        hitPlayer = true;
    }

    public static void SaveHealthUpdate()
    {
        playerHealth = GameController.controller.s_health;
        //make sure the health update is complete
    }
}