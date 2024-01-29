using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectAI : MonoBehaviour
{
    public void startAStar()
    {
        SceneManager.LoadScene("AStarAlgorithm");
        pausemenu.gameIsPaused = false;
        Time.timeScale = 1.0f;
    }
    public void startAStarExample()
    {
        SceneManager.LoadScene("WPTank");
        pausemenu.gameIsPaused = false;
        Time.timeScale = 1.0f;
    }
    public void startAutonomousAgents()
    {
        SceneManager.LoadScene("Steering");
        pausemenu.gameIsPaused = false;
        Time.timeScale = 1.0f;
    }

    public void startSwimming()
    {
        SceneManager.LoadScene("Swimming");
        pausemenu.gameIsPaused = false;
        Time.timeScale = 1.0f;
    }
}
