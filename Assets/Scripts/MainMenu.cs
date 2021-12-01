using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
 
    public void PlayGame()
    {
        SceneManager.LoadScene(1);// When the button is pressed the player will load into the game.
    }

    public void QuitgGame()
    {
        Application.Quit();// When the button is pressed the application will close

    }
}
