using Lavid.Libraske.DataStruct;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestPersonalizationColors : WebRequest
{
    [SerializeField] Wrapper<PersonalizationColor> _colors;

    void OnEnable() => StartCoroutine(SendRequest());
    public override string GetLogName() => "RequestPersonalizationColors";

    public override IEnumerator SendRequest()
    {
        Logger.Log(this, "Solicitou requisição de cores");
        var webRequest = WebRequestFormater.Get(WebConstants.URL.PersonalizationsColors);
        yield return webRequest.SendWebRequest();
        VerifyRequest(webRequest);
    }

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.DownloadPersonalizationColorsError);
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;

        try
        {
            _colors = PersonalizationConversor.FromRequestToColorWrapper(request);
            PrintSuccessText(request);
            InvokeOnSuccessEvent();
        }
        catch
        {
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.CastPersonalizationColorError);

            Logger.LogError(this, "Houve um problema no cast de variáveis");
        }
    }
}