using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class switchNavAndWP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        pausemenu.gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnoffFollowWP()
    {
        this.GetComponent<FollowWP>().enabled = false;
        this.GetComponent<FollowNavMesh>().enabled = true;
        this.GetComponent<NavMeshAgent>().enabled = true;
    }
    public void turnoffNavMesh()
    {
        this.GetComponent<FollowNavMesh>().enabled = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<FollowWP>().enabled = true;
    }
}
