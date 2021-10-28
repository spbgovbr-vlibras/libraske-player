using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotoExporter : MonoBehaviour
{
    public WebCamHandler _webCamHandler;

    public bool _export;
    public int id;

    IEnumerator TakePhotos()
    {
        yield return new WaitForSeconds(2f);
        while (id != 10)
        {
            File.WriteAllBytes(Application.dataPath + $"/PhotosExporteds/{id}.png", _webCamHandler.GetImageInBytes());
            yield return new WaitForSeconds(1f);
            id++;
        }

    }

    private void Update()
    {
        if (_export)
        {
            StartCoroutine(TakePhotos());
            Debug.Log("exportado");
            _export = false;
        }
    }


}
