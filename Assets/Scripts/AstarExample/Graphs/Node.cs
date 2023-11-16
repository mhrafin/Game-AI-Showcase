using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public List<Edge> edgeList= new List<Edge>();

    public Node path = null;

    GameObject id;

    
    public float f, g, h;

    public Node cameFrom;

    public Node(GameObject id)
    {
        this.id = id;

        

        path = null;
    }

    public GameObject getID()
    {
        return id;
    }
}
