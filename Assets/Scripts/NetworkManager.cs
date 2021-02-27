using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    private UnityEngine.Object[] assets;
    public GameObject[] instAssets;
    private int position = 0;

    private string url = String.Empty;
    IEnumerator getRequest(string url, Action<UnityWebRequest> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            callback(request);
        }
    }

    public void nextButtonPushed()
    {
        try
        {
            int current = position;
            position = (position + 1) % instAssets.Length;
            string temp = String.Format("Changing position from {0} to {1}", current, position);
            Debug.Log(temp);
            instAssets[current].SetActive(false);
            instAssets[position].SetActive(true);
        }
        catch(Exception e)
        {
            Debug.LogError("Error in nextButtonPushed");
            Debug.LogError(e);
        }
    }

    public void backButtonPushed()
    {
        try
        {
            int current = position;
            position = (position + instAssets.Length - 1) % instAssets.Length;
            string temp = String.Format("Changing position from {0} to {1}", current, position);
            Debug.Log(temp);
            instAssets[current].SetActive(false);
            instAssets[position].SetActive(true);
        }
        catch (Exception e)
        {
            Debug.LogError("Error in backButtonPushed");
            Debug.LogError(e);
        }
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        int i = 0;
        string url = "https://arvrclassstorage.blob.core.windows.net/models/PennyTestBundle/penny_prefab";
        UnityEngine.Networking.UnityWebRequest request
            = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
        assets = bundle.LoadAllAssets();
        int assetCount = 0;
        for(i = 0; i < assets.Length; i++)
        {
            if(assets[i].GetType() == typeof(GameObject))
            {
                assetCount++;
            }
        }
        Debug.Log(assetCount);
        instAssets = new GameObject[assetCount];
        i = 0;
        foreach(UnityEngine.Object obj in assets)
        {
            if(obj.GetType() == typeof(GameObject))
            {
                GameObject g = (GameObject)obj;
                GameObject used = Instantiate(g);
                used.SetActive(false);
                instAssets[i] = used;
                i++;
            }
        }
        instAssets[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
