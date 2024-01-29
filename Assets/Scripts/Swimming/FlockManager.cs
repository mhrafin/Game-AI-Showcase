using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject fishPrefab;
    public int numFish = 20;
    public GameObject[] allFish;
    public Vector3 swimLimits = new Vector3(5, 5, 5);
    public Vector3 goalPos = Vector3.zero;
    public Slider minSpeedSlider;
    public Slider maxSpeedSlider;
    public Slider neighbourDistanceSlider;
    public Slider rotationSpeedSlider;



    [Header("Fish Settings")]
    //[Range(0.0f, 5.0f)]
    public float minSpeed;
    public void UpdateMinSpeed(float value)
    {
        value = minSpeedSlider.value;
        minSpeed = value;
        
    }

    
    //[Range(0.0f,5.0f)]
    public float maxSpeed;
    public void UpdateMaxSpeed(float value)
    {
        value = maxSpeedSlider.value;
        maxSpeed = value;
        
    }


    //[Range(1.0f, 10.0f)]
    public float neighbourDistance;
    public void UpdateNeighbourDistance(float value)
    {
        value = neighbourDistanceSlider.value;
        neighbourDistance = value;
        
    }


    //[Range(1.0f, 5.0f)]
    public float rotationSpeed;
    public void UpdateRotationSpeed(float value)
    {
        value = rotationSpeedSlider.value;
        rotationSpeed = value;
        
    }



    // Start is called before the first frame update
    void Start()
    {

        if (maxSpeedSlider != null)
        {
            maxSpeedSlider.value = maxSpeed;
        }



        allFish = new GameObject[numFish];

        for(int i = 0; i < numFish; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y, swimLimits.y),
                Random.Range(-swimLimits.z, swimLimits.z));

            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
        }

        FM = this;
        goalPos = this.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100)< 10)
        {
            goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y, swimLimits.y),
                Random.Range(-swimLimits.z, swimLimits.z));
        }
    }
}
