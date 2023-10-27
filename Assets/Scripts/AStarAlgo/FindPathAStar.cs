using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class PathMarker
{
    public MapLocation location;
    public float G; //cost from the start
    public float H; //cost to the goal
    public float F; //Total cost (G+H)
    public GameObject marker;
    public PathMarker parent;

    public PathMarker(MapLocation location, float G, float H, float F, GameObject marker, PathMarker parent)
    {
        this.location = location;
        this.G = G;
        this.H = H;
        this.F = F;
        this.marker = marker;
        this.parent = parent;
    }

    // Overrided equals to check if one pathmarker is equal to the another through checking their location
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        PathMarker other = (PathMarker)obj;
        return location.Equals(other.location);
    }

    public override int GetHashCode()
    {
        return location.GetHashCode();
    }
}



public class FindPathAStar : MonoBehaviour
{
    public Maze maze;

    public Material closedMaterial;
    public Material openMaterial;

    List<PathMarker> openPath = new List<PathMarker>();
    List<PathMarker> closedPath = new List<PathMarker>();

    public GameObject start;
    public GameObject end;
    public GameObject path;

    bool goalFound = false;

    PathMarker startNode;
    PathMarker endNode;
    PathMarker lastPos;


    void removeAllMarkers()
    {
        GameObject[] markers = GameObject.FindGameObjectsWithTag("marker");
        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        }
    }

    void setStartEnd()
    {
        goalFound = false;
        removeAllMarkers();

        List<MapLocation> mapLocations = new List<MapLocation>();

        for(int z = 1; z < maze.depth;z++)
            for(int x = 1; x < maze.width; x++)
            {
                if (maze.map[x,z] != 1)
                {
                    mapLocations.Add(new MapLocation(x, z));
                }
            }
        mapLocations.Shuffle();

        Vector3 startLocation = new Vector3(mapLocations[0].x * maze.scale, 0, mapLocations[0].z * maze.scale);
        startNode = new PathMarker(new MapLocation(mapLocations[0].x, mapLocations[0].z), 0, 0, 0, Instantiate(start,startLocation,Quaternion.identity), null);

        Vector3 endLocation = new Vector3(mapLocations[1].x * maze.scale, 0, mapLocations[1].z * maze.scale);
        endNode = new PathMarker(new MapLocation(mapLocations[1].x, mapLocations[1].z), 0, 0, 0, Instantiate(end, endLocation, Quaternion.identity), null);

        openPath.Clear();
        closedPath.Clear();

        openPath.Add(startNode);
        lastPos = startNode;
    }

    void search(PathMarker currentNode)
    {
        if(currentNode == null) return;
        if(currentNode.Equals(endNode)) { goalFound = true; return; }

        foreach(MapLocation dir in maze.directions)
        {
            MapLocation neighbour = dir + currentNode.location;

            if (maze.map[neighbour.x, neighbour.z] == 1) continue;
            if (neighbour.x >= maze.width || neighbour.z >= maze.depth) continue;
            if (isClosed(neighbour)) continue;

            float G = Vector2.Distance(neighbour.ToVector(), currentNode.location.ToVector()) + currentNode.G;
            float H = Vector2.Distance(neighbour.ToVector(), endNode.location.ToVector());
            float F = G + H;

            GameObject pathBlock = Instantiate(path, new Vector3(neighbour.x * maze.scale, 0 , neighbour.z * maze.scale), Quaternion.identity);

            TextMesh[] ghfValues = pathBlock.GetComponentsInChildren<TextMesh>();

            ghfValues[0].text = "G" + G.ToString("0.00");
            ghfValues[1].text = "H" + H.ToString("0.00");
            ghfValues[2].text = "F" + F.ToString("0.00");

            if(!updateOpenPath(neighbour,G,H,F,currentNode))
            {
                openPath.Add(new PathMarker(neighbour, G, H, F, pathBlock, currentNode));
            }
        }

        openPath = openPath.OrderBy( p => p.F).ThenBy(n => n.H).ToList<PathMarker>();

        PathMarker toBeClosed = (PathMarker) openPath.ElementAt(0);
        closedPath.Add(toBeClosed);
        openPath.RemoveAt(0);
        toBeClosed.marker.GetComponent<Renderer>().material = closedMaterial;
        lastPos = toBeClosed;
    }

    bool updateOpenPath(MapLocation location, float G, float H, float F, PathMarker parent)
    {
        foreach(PathMarker entry in openPath)
        {
            if (entry.location.Equals(location))
            {
                entry.G = G;
                entry.H = H;
                entry.F = F;
                entry.parent = parent;
                return true;
            }
        }
        return false;
    }

    bool isClosed(MapLocation currentMapLocation)
    {
        foreach(PathMarker entry in closedPath)
        {
            if(currentMapLocation.Equals(entry.location)) return true;
        }
        return false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void createPath()
    {
        removeAllMarkers();
        PathMarker begining = lastPos;
        while(lastPos.parent != null)
        {
            Instantiate(path, new Vector3(lastPos.location.x * maze.scale, 0, lastPos.location.z * maze.scale), Quaternion.identity);
            lastPos = lastPos.parent;
        }
        Instantiate(path, new Vector3(lastPos.location.x * maze.scale, 0, lastPos.location.z * maze.scale), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            setStartEnd();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            search(lastPos);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            createPath();
        }
    }
}
