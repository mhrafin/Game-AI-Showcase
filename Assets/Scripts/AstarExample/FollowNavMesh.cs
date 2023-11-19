using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowNavMesh : MonoBehaviour
{

    public GameObject wpManager;
    GameObject[] waypoints;
    GameObject currentNode;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = wpManager.GetComponent<WPManager>().waypoints;

        currentNode = waypoints[0];

        agent = this.GetComponent<NavMeshAgent>();

        //Invoke("GoToRuins", 3.0f);
    }

    public void GoToHelipad()
    {
        //g.AStar(currentNode, waypoints[0]);

        agent.SetDestination(waypoints[0].transform.position);
      
    }

    public void GoToRuins()
    {
        //g.AStar(currentNode, waypoints[5]);

        agent.SetDestination(waypoints[5].transform.position);
    }

    public void GoToValley()
    {
        //g.AStar(currentNode, waypoints[1]);

        agent.SetDestination(waypoints[1].transform.position);
    }

    public void GoToFactory()
    {
        //g.AStar(currentNode, waypoints[4]);

        agent.SetDestination(waypoints[4].transform.position);

    }

    public void GoToHospital()
    {
        //g.AStar(currentNode, waypoints[2]);

        agent.SetDestination(waypoints[2].transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
