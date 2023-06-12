using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject start;
    private GameObject end;

    private CollsionDetector startingPoint;
    private CollsionDetector endingPoint;
    private TimeCounter timer;
    void Start()
    {
        start = GameObject.FindGameObjectWithTag("Start");
        end = GameObject.FindGameObjectWithTag("End");
        startingPoint = start.GetComponent<CollsionDetector>();
        endingPoint = end.GetComponent<CollsionDetector>();
        timer = gameObject.GetComponent<TimeCounter>();
        //Debug.Log(start.name);
        //Debug.Log(end.name);

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(startingPoint.start);
        
    }
}
