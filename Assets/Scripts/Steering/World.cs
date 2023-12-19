using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class World
{
    private static readonly World instance = new World();
    private static GameObject[] hidingSpots;

    static World()
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
    }

    private World()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
    }

    public static World Instance
    {
        get { return instance; }
    }

    public GameObject[] GetHidingSpots()
    {
        return hidingSpots;
    }
}
