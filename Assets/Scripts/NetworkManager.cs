using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    IEnumerator getRequest(string url, Action<UnityWebRequest> callback)
    {
        using(UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("Hello!");
        string url = "https://arvrclassstorage.blob.core.windows.net/models/PennyTestBundle/penny_prefab";
        //string url = "file:///" + Application.dataPath + "/AssetBundles/" + "penny_prefab";
        UnityEngine.Networking.UnityWebRequest request
            = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        UnityEngine.Object[] objects = bundle.LoadAllAssets();
        foreach(UnityEngine.Object obj in objects)
        {
            GameObject g = (GameObject)obj;
            GameObject used = Instantiate(g);
            Vector3 scale = used.transform.localScale;
            scale *= 100;
            used.transform.localScale = scale;
            used.SetActive(true);
        }
        //GameObject cube = bundle.LoadAsset<GameObject>("Cube");
        //GameObject sprite = bundle.LoadAsset<GameObject>("Sprite");
        //foreach (string ob in bundle.GetAllAssetNames())
        //{
        //    Debug.Log(ob);
        //}
        //Instantiate(cube);
        //Instantiate(sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
