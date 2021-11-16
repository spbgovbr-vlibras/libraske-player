using Lavid.Libraske.DataStruct;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestPersonalizationGroup : WebRequest
{
    [SerializeField] PersonalizationHolderSO _personalizationHolder;
    [SerializeField] Wrapper<PersonalizationGroup> _groups;

    void OnEnable() => StartCoroutine(SendRequest());
    public override string GetLogName() => "RequestPersonalizationGroup";

    public override IEnumerator SendRequest()
    {
        Logger.Log(this, "Solicitou requisição dos grupos de cores");
        var webRequest = WebRequestFormater.Get(WebConstants.URL.PersonalizationsGroups);
        yield return webRequest.SendWebRequest();
        VerifyRequest(webRequest);
    }

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.DownloadPersonalizationGroupsError);
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;

        try
        {
            _groups = PersonalizationConversor.FromRequestToGroupWrapper(request);
            _personalizationHolder.SetGroups(_groups);
            PrintSuccessText(request);
            InvokeOnSuccessEvent();
        }
        catch
        {
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.CastPersonalizationGroupError);

            Logger.LogError(this, "Houve um problema no cast de variáveis");
        }
    }
}
