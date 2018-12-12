/*
/ Author: Mike Young
/ Version: 1.0
/ This file saves game data to a file in unity's persistant data path
/ this allows the player to save and load data to continue play from where
/ they currently are within the game world.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

//this is sort of a singleton class to ensure there is only
//one game controller persisting data across scenes
public class GameController : MonoBehaviour
{
    // this makes the GameController accessible in other scripts with out finding or referencing
    // For example type GameController.controller.
    public static GameController controller;
    public int s_health;
    public float s_experience;
    string sceneName;

    // Use this for initialization
    void Awake()
    {
        //if this isn't a game controller object yet make it one
        if (controller == null)
        {
            //keep it for cross scene traversal
            DontDestroyOnLoad(gameObject);
            //make it 
            controller = this;
        }
        //it is a game controller but not this destory
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        gameLoadOccured = false;
    }

    //this will work on mobile Android and iOS and PC, not sure about PS4
    public void SaveGame()
    {
        Debug.Log("Game Saved");
        //get the active scene name to save
        sceneName = SceneManager.GetActiveScene().name;
        //instanciate and create new binary formatter
        BinaryFormatter bf = new BinaryFormatter();
        //create a file and set it to playerinfo.dat in the persistant data path, set the file mode to be open
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.data");
        //instanciate a new serializable data class in order to serialize and save player data
        PlayerData data = new PlayerData();
        //assign health and experience to the serializable class
        data.s_health = s_health;
        data.s_experience = s_experience;
        data.sceneNameToSave = sceneName;
        //serializs file with data content
        bf.Serialize(file, data);
        //close the file
        file.Close();
    }

    public void LoadGame()
    {
        //check if the file exists
        if (File.Exists(Application.persistentDataPath + "/playerInfo.data"))
        {
            // get the current scene to close
            sceneName = SceneManager.GetActiveScene().name;
            //load the level
            SceneManager.LoadScene(sceneName);
            Debug.Log("Game Loaded");
            //instanciate a new binary formatter
            BinaryFormatter bf = new BinaryFormatter();
            //create a file and open the playerInfo.dat file
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.data", FileMode.Open);
            //deserialise the file data
            PlayerData data = (PlayerData)bf.Deserialize(file);
            //close the file
            file.Close();
            //assign health and experience 
            s_health = data.s_health;
            s_experience = data.s_experience;
            //apply load to the game
            yield(1f);
            WaitToSave();
        }
        //ensure that the players health and experience are updated then ensure that the players not reading game save data
    }
}

[System.Serializable]
class PlayerData
{
    public int s_health;
    public float s_experience;
    public string sceneNameToSave;
}

public void WaitToSave()
{
    gameObject.Find("NameOfTheGameObjectTarget").GetComponent<PlayerHealthManager>().NameOfTheProperty = ...;
    yield return new WaitForSeconds(1f);
}
