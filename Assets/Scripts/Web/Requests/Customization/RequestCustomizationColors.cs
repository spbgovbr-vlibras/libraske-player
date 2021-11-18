using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestCustomizationColors : WebRequest
{
    [SerializeField] CustomizationHolderSO _personalizationHolder;
    [SerializeField] Wrapper<CustomizationColor> _colors;
    [SerializeField] CustomizationGroups.Groups _groupToRequest;

    void OnEnable() => StartCoroutine(SendRequest());
    public override string GetLogName() => "RequestPersonalizationColors";

    public override IEnumerator SendRequest()
    {
        Logger.Log(this, "Solicitou requisição de cores");
        var webRequest = WebRequestFormater.GetColors(_groupToRequest);// Get(WebConstants.URL.PersonalizationsColors);
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
		
		Logger.Log(this, request.downloadHandler.text);

        try
        {
            _colors = CustomizationConversor.FromRequestToColorWrapper(request);
            _personalizationHolder.SetColors(_colors, _groupToRequest);
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