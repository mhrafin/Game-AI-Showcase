using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public Node headNode;
    public Node footNode;

    public Edge(Node from, Node to)
    {
        this.headNode = from;
        this.footNode = to;
    }   
}
