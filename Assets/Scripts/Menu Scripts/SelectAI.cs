using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectAI : MonoBehaviour
{
    public void startAStar()
    {
        SceneManager.LoadScene("AStarAlgorithm");
    }
}
