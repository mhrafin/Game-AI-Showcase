using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleCanvas : MonoBehaviour
{
    public GameObject waypointHudUI;
    public GameObject NavMeshHudUI;

    public GameObject tank;

    

    // Start is called before the first frame update
    void Start()
    {
        //waypointHudUI.SetActive(true);
        pausemenu.gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pausemenu.gameIsPaused)
        {
            waypointHudUI.SetActive(false);
            NavMeshHudUI.SetActive(false);
            //Debug.Log("HUD Deactivated");
        }
        else if (!pausemenu.gameIsPaused && tank.GetComponent<FollowWP>().isActiveAndEnabled)
        {
            waypointHudUI.SetActive(true);
            NavMeshHudUI.SetActive(false);
            //Debug.Log("HUD Activated");
        }
        else if (!pausemenu.gameIsPaused && tank.GetComponent<FollowNavMesh>().isActiveAndEnabled)
        {
            NavMeshHudUI.SetActive(true);
            waypointHudUI.SetActive(false);
            //Debug.Log("HUD Activated");
        }

        //if (tank.GetComponent<FollowWP>().isActiveAndEnabled)
        //{
        //    waypointHudUI.SetActive(true);
        //    NavMeshHudUI.SetActive(false);
        //}
        //else
        //{
        //    waypointHudUI.SetActive(false);
        //    NavMeshHudUI.SetActive(true);
        //}
    }
}
