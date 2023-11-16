using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Edge> allEdges = new List<Edge>();
    List<Node> allNodes = new List<Node>();
    public List<Node> pathList = new List<Node>();

    public Graph() { }

    public void AddNode(GameObject id)
    {
        Node node = new Node(id);
        allNodes.Add(node);
    }

    public void AddEdge(GameObject fromNode, GameObject toNode)
    {
        Node from = FindNode(fromNode);
        Node to = FindNode(toNode);

        if(from != null && to != null)
        {
            Edge edge = new Edge(from, to);
            allEdges.Add(edge);
            from.edgeList.Add(edge);
        }
    }

    Node FindNode(GameObject id)
    {
        foreach (Node node in allNodes)
        {
            if(node.getID() == id)
            {
                return node;
            }
        }
        return null;
    }

    public bool AStar(GameObject startid, GameObject endid)
    {
        if(startid == endid)
        {
            pathList.Clear();
            return false;
        }


        Node startNode = FindNode(startid);
        Node endNode = FindNode(endid);

        if(startNode == null || endNode == null)
        {
            return false;
        }

        List<Node> openNodes = new List<Node>();
        List<Node> closedNodes = new List<Node>();

        float tentative_g_score = 0; //the current node's g score + the cost to the neighbor = This sum is the tentative_g_score.
        bool tentative_is_better;

        startNode.g = 0;
        startNode.h = distance(startNode, endNode);
        startNode.f = startNode.h;

        openNodes.Add(startNode);

        while(openNodes.Count > 0)
        {
            int i = lowestF(openNodes);

            Node thisNode = openNodes[i];

            if(thisNode.getID() == endid)
            {
                ReconstructPath(startNode, endNode);
                return true;
            }

            openNodes.RemoveAt(i);

            closedNodes.Add(thisNode);

            Node neighbour;

            foreach(Edge edge in thisNode.edgeList)
            {
                neighbour = edge.footNode;
                

                if(closedNodes.IndexOf(neighbour) > -1) //If neighbour is not in closedNodes, IndexOf returns -1
                {
                    continue;
                }

                tentative_g_score = thisNode.g + distance(thisNode, neighbour);

                if(openNodes.IndexOf(neighbour) == -1)
                {
                    openNodes.Add(neighbour);
                    tentative_is_better = true;
                }
                else if(tentative_g_score < neighbour.g)
                {
                    tentative_is_better = true;
                }
                else
                {
                    tentative_is_better = false;
                }

                if (tentative_is_better)
                {
                    neighbour.cameFrom = thisNode;
                    neighbour.g = tentative_g_score;
                    neighbour.h = distance(thisNode, endNode);
                    neighbour.f = neighbour.g + neighbour.h;

                }
            }
        }
        return false;
    }

    public void ReconstructPath(Node start, Node end)
    {
        pathList.Clear();
        pathList.Add(end);

        var p = end.cameFrom;

        while(p != start && p != null)
        {
            pathList.Insert(0, p);
            p = p.cameFrom;
        }

        pathList.Insert(0, start);
    }


    float distance(Node a, Node b)
    {
        return(Vector3.SqrMagnitude(a.getID().transform.position - b.getID().transform.position));
    }

    int lowestF(List<Node> nodeList)
    {
        float lowestf = nodeList[0].f;
        int iteratorCount = 0;


        for (int count = 1; count < nodeList.Count; count++)
        {
            if (nodeList[count].f < lowestf)
            {
                lowestf = nodeList[count].f;
                iteratorCount = count;  // Update the iteratorCount to the current index
            }
        }
        return iteratorCount;


        //int count = 0;
        //for (int i = 1; i < nodeList.Count; i++)
        //{
        //    if (nodeList[i].f < lowestf)
        //    {
        //        lowestf = nodeList[i].f;
        //        iteratorCount = count;
        //    }
        //    count++;
        //}
        //return iteratorCount;
    }
}
 