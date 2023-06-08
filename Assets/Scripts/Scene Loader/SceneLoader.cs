using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void loadFreeMode()
    {
        //redirects to free mode
        SceneManager.LoadScene("Example_01");
    }

    public void loadCareerMode()
    {
        //redirects to Careen Mode 
        SceneManager.LoadScene("CareerMode");
    }
    public void LoadHomePage()
    {
        //Redirects to Dashboard
        SceneManager.LoadScene("SampleScene");
    }
}
