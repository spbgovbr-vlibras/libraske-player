using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotoExporter : MonoBehaviour
{
    public WebCamHandler _webCamHandler;

    public bool a;
    public int id;

    IEnumerator TakePhotos()
    {
        yield return new WaitForSeconds(2f);
        while (id != 10)
        {
            File.WriteAllBytes(Application.dataPath + $"/{id}.png", _webCamHandler.GetImageInBytes());
            yield return new WaitForSeconds(1f);
            id++;
        }

    }

    private void Update()
    {
        if (a)
        {
            StartCoroutine(TakePhotos());
            Debug.Log("exportado");
            a = false;
        }
    }


}
