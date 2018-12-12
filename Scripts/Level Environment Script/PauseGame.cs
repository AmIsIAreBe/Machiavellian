using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    //string name to store the main menu name
    public string mainMenu;

    //bool to check the pause state of the game
    public bool isPaused;

    //assign the canvas to manipulate to this in the inspector to have an effect
    public GameObject pauseMenuCanvas;

    void FixedUpdate()
    {
        //if escape key is pressed set the bool ispaused to true and call SetPause method.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            SetPause();
        }
    }
    public void SetPause()
    {
        //escape will only pause the game and never unpause it
        if (isPaused)
        {
            // AUDIO ISN"T TURNING OFF CURRENTLY, NEEDS MORE RESEARCH
            AudioListener.pause = true;
            AudioListener.volume = 0f;
            //display the pausemenu interface
            pauseMenuCanvas.SetActive(true);
            //pause game 
            Time.timeScale = 0f;
            //show mouse cursor
            Cursor.visible = true;
        }
    }
    //when the resume game button is clicked it calls this method
    public void ResumeGame()
    {
        // hide the pause menu
        pauseMenuCanvas.SetActive(false);
        //set the game time to 1 so the game unpauses
        Time.timeScale = 1f;
        //un mute and unpause audio
        AudioListener.pause = false;
        AudioListener.volume = 1f;
        //show the mouse cursor
        Cursor.visible = false;
    }

    //the game menu ui calls this method on click of the Exit to main menu button
    public void QuitGame()
    {
        //ensure the time is back to playing as it causes a bugs on restarting the game from the main menu
        Time.timeScale = 1f;
        //load main menu scene
        SceneManager.LoadScene(mainMenu);
    }

    public void SaveGame()
    {
        GameController.controller.SaveGame();
    }

    public void LoadGame()
    {
        GameController.controller.LoadGame();
    }
}
