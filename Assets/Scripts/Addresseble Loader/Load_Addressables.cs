using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Load_Addressables : MonoBehaviour
{

    private string bundleUrl1 = "https://drive.google.com/uc?export=download&id=1CeGAgSy-6f4yUEOMxUwJxFBRm3jaf1JM";
    private GameObject[] prefab1;
    [SerializeField]
    float progress;
    string localPath;
    bool iscache;
    //public GameObject loadui;
    //public GameObject backgroundimage;
    //public GameObject loadingScreen;
    //public Image progressBar;
    string sceneName;
    [SerializeField]
    //private ImageTrackingObjectManager imageTrackingObjectManager;
    void Start()
    {

        iscache = Caching.ClearCache();
        Debug.Log(Caching.ClearCache());
        sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(LoadAssets());
    }
    IEnumerator LoadAssets()
    {

        localPath = Application.persistentDataPath + "/level_1";
        Debug.Log(localPath);
        if (iscache == true)
        {
            if (System.IO.File.Exists(localPath))
            {

                // Load the asset bundle from the local path
                //loadui.SetActive(true);

                AssetBundle localAssetBundle = AssetBundle.LoadFromFile(localPath);
                prefab1 = localAssetBundle.LoadAllAssets<GameObject>();
                Debug.Log(prefab1.Length);  
                for (int i = 0; i < prefab1.Length;i++)
                {
                    Debug.Log(prefab1[i].name);
                }
                //backgroundimage.SetActive(false);

            }
            else
            {
                // Download the asset bundle from the URL

                UnityWebRequest webRequest1 = UnityWebRequest.Get(bundleUrl1);
                webRequest1.SendWebRequest();

                while (webRequest1.isDone == false)
                {

                    progress = webRequest1.downloadProgress;
                    Debug.Log(progress);
                    //progressBar.fillAmount = progress;

                    yield return null;
                }
                //loadui.SetActive(true);
                //progressBar.fillAmount = 1;


                if (webRequest1.result == UnityWebRequest.Result.Success)
                {
                    // Save the downloaded asset bundle to the local path
                    byte[] data = webRequest1.downloadHandler.data;
                    System.IO.File.WriteAllBytes(localPath, data);
                    Debug.Log("Saved");
                    // Load the asset bundle from the local path

                    AssetBundle localAssetBundle = AssetBundle.LoadFromFile(localPath);



                    Debug.Log("Current Scene Name: " + sceneName);

                    prefab1 = localAssetBundle.LoadAllAssets<GameObject>();
                    for (int i = 0; i < prefab1.Length; i++)
                    {
                        Debug.Log(prefab1[i].name);
                    }


                }
                else
                {
                    Debug.Log("Asset bundle download failed.");
                }

                //loadingScreen.SetActive(false);
                //backgroundimage.SetActive(false);
            }



            for (int i = 0; i < prefab1.Length; i++)
            {
                Instantiate(prefab1[0]);
                Debug.Log("Instantiated");
                //if (sceneName.Contains(prefab1[i].name))
                //{
                //    Instantiate(prefab1[0]);
                //    //Instantiate(prefab1[i]);
                    
                //    //imageTrackingObjectManager.onePrefab = prefab1[i];
                //    //Debug.Log(imageTrackingObjectManager.onePrefab.name);
                //    break;

                //}
            }

        }


    }
    //IEnumerator DownloadAssetBundle(UnityWebRequest webRequest)
    //{
    //    webRequest.SendWebRequest();

    //    while (!webRequest.isDone)
    //    {
    //        // Update the progress bar
    // //       progressBar.fillAmount = webRequest.downloadProgress;

    //        yield return null;
    //    }
    //}
}
