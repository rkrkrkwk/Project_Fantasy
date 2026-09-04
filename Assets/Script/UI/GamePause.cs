using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause
{
    public static GamePause Instance = new GamePause();
    private bool isPaused = false;
    
    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
