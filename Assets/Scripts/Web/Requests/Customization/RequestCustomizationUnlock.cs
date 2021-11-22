using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestCustomizationUnlock : WebRequest
{
    [SerializeField] ColorPalettsController _controller;
    public override string GetLogName() => "RequestCustomizationUnlock";

    public override IEnumerator SendRequest()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.UnlockColorSetError);
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;
    }
}
