using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
  public GameObject pauseMenu;
  public FadeController backgroundFadeController;

  private bool isPaused = false;

  public void Pause(bool pause)
  {
    if(!isPaused && pause)
    {
      //Pause the game
      isPaused = true;
      Time.timeScale = 0;
      pauseMenu.SetActive(true);

    }
    if(isPaused && !pause)
    {
      //Unpause the game
      isPaused = false;
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
    }
  }
}
