using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    Transform goal;

    float speed = 5.0f;
    float accuracy = 5.0f;
    float rotationSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] waypoints;
    GameObject currentNode;

    int currentWP = 0;

    Graph g;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = wpManager.GetComponent<WPManager>().waypoints;

        g = wpManager.GetComponent<WPManager>().graph;

        currentNode = waypoints[0];

        //Invoke("GoToRuins", 3.0f);
    }

    public void GoToHelipad()
    {
        g.AStar(currentNode, waypoints[0]);

        currentWP = 0;
    }

    public void GoToRuins()
    {
        g.AStar(currentNode, waypoints[5]);

        currentWP = 0;
    }

    public void GoToValley()
    {
        g.AStar(currentNode, waypoints[1]);

        currentWP = 0;
    }

    public void GoToFactory()
    {
        g.AStar(currentNode, waypoints[4]);

        currentWP = 0;
    }

    public void GoToHospital()
    {
        g.AStar(currentNode, waypoints[2]);

        currentWP = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (g.pathList.Count == 0 || currentWP == g.pathList.Count)
        {
            return;
        }

        if (Vector3.Distance(g.pathList[currentWP].getID().transform.position, this.transform.position) < accuracy)
        {
            currentNode = g.pathList[currentWP].getID();
            currentWP++;
        }

        if(currentWP < g.pathList.Count)
        {
            goal = g.pathList[currentWP].getID().transform;
            Vector3 lookAtGoal = new Vector3(goal.position.x, this.transform.position.y, goal.position.z);
            Vector3 direction = lookAtGoal - this.transform.position;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
            this.transform.Translate(0,0,speed*Time.deltaTime);

        }
    }
}
