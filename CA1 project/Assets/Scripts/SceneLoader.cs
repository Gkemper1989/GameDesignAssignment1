using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Script to manage the game progression 

public class SceneLoader : MonoBehaviour
{
    //method to load the main menu scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //method to load the next scene
   public void LoadNextScene()
    {
        //setting the index of the scene progression
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    //method to exit the application by clicking on the exit button
    public void ExitGame()
    {
        Application.Quit();    
    }
}
