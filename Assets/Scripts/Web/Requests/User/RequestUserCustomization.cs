using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Lavid.Libraske.Avatar;
using Lavid.Libraske.Util;

public class RequestUserCustomization : WebRequest
{
    public override string GetLogName() => "RequestUserCustomization";

    [SerializeField] AvatarCustomizationSO _defaultCustomization;
    [SerializeField] AvatarCustomizationSO _personalCustomization;

    /// <summary> Called on canvas. </summary>
    public void CallRequest() => StartCoroutine(SendRequest());

    public override IEnumerator SendRequest()
    {
        var webRequest = WebRequestFormater.Get(WebConstants.URL.UsersURL);
        yield return webRequest.SendWebRequest();
        VerifyRequest(webRequest);
    }

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        var colors = _defaultCustomization.GetColors();
        _personalCustomization.SetColors(colors);

        InvokeOnErrorEvent();
    }

    private bool IsValid(string color)
    {
        return color != null && color != "";
    }

    protected override string SuccessText(UnityWebRequest request)
    {
        return $"Request was success in {request.url}. Data got: {request.downloadHandler.text}";
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;

        PrintSuccessText(request);

        Logger.LogSuccess(this, "Data: " + request.downloadHandler.text);

        UserData loaded = JsonUtility.FromJson<UserData>(request.downloadHandler.text);

        var colors = _defaultCustomization.GetColors();

        if (IsValid(loaded.cabelo))
            colors.SetProperty(AvatarPropertiesEnum.CABELO, new SerializableColor(loaded.cabelo));

        if (IsValid(loaded.pele))
            colors.SetProperty(AvatarPropertiesEnum.CORPO, new SerializableColor(loaded.pele));

        if (IsValid(loaded.olhos))
            colors.SetProperty(AvatarPropertiesEnum.OLHOS, new SerializableColor(loaded.olhos));

        if (IsValid(loaded.camisa))
            colors.SetProperty(AvatarPropertiesEnum.CAMISA, new SerializableColor(loaded.camisa));

        if (IsValid(loaded.calca))
            colors.SetProperty(AvatarPropertiesEnum.CALCA, new SerializableColor(loaded.calca));

        _personalCustomization.SetColors(colors);

        InvokeOnSuccessEvent();
    }
}
