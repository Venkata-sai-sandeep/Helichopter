using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    private float startTime;
    private bool isCounting = false;
    public TextMeshProUGUI timeDisplay;

    private void Start()
    {
        timeDisplay.text = "00:00";
        // Start counting when the script is enabled
        //StartCounting();
    }

    private void Update()
    {
        if (isCounting)
        {
            // Calculate the elapsed time since starting
            float elapsedTime = Time.time - startTime;

            // Format the time as minutes and seconds
            string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            timeDisplay.text = minutes.ToString() + ":" + seconds.ToString(); 
            // Display the time
            //Debug.Log("Elapsed Time: " + minutes + ":" + seconds);
        }
    }

    public void StartCounting()
    {
        // Reset the start time and begin counting
        startTime = Time.time;
        isCounting = true;
    }

    public void StopCounting()
    {
        // Stop counting
        isCounting = false;
    }
}
