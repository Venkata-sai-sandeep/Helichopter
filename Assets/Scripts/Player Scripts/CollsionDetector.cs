using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public bool start = false;
    public bool finish = false;
    private string currentTag;
    private TimeCounter timer;
    private GameObject player;
    private void Start()
    {
        currentTag = gameObject.tag;
        timer = GameObject.FindGameObjectWithTag("Player Controller").GetComponent<TimeCounter>();
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(currentTag.ToString());
    }
    int cnt = 0;
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if(other.tag == "Front wheel" && currentTag == "Start")
        {
            start = true;
            if(cnt == 0)
            {
                timer.StartCounting();

            }
            cnt++;
        }
        else if(other.tag == "Back wheel" && currentTag == "End")
        {
            finish = true;
            StartCoroutine(stopPlayer());
            timer.StopCounting();
        }
    }

    IEnumerator stopPlayer()
    {
        yield return new WaitForSeconds(1);
        player.GetComponent<Rigidbody>().isKinematic = true;
    }
}
