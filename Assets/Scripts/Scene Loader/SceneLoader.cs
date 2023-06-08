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
        SceneManager.LoadScene("Example_01");
    }

    public void loadCareerMode()
    {
        SceneManager.LoadScene("CareerMode");
    }
}
