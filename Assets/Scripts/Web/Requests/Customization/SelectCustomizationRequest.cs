using Lavid.Libraske.Avatar;
using System.Collections;
using UnityEngine.Networking;

public class SelectCustomizationRequest : WebRequest
{
    public override string GetLogName() => "SelectCustomizationRequest";

    [UnityEngine.SerializeField] AvatarCustomizationManager _customizationManager;

    private int _itemId;

    public void TrySelectItem(CustomizationColorHandler item)
    {
        _itemId = item.Id;
        StartCoroutine(SendRequest());
    }

    public override IEnumerator SendRequest()
    {
        Logger.Log(this, "Starting request to select item with id " + _itemId);
        string url = WebConstants.FormatActivateColorUrl(_itemId);
        var www = WebRequestFormater.EmptyPost(url);
        yield return www.SendWebRequest();
        VerifyRequest(www);
    }

    protected override void OnRequestError(UnityWebRequest request)
    {
        PrintFailText(request);

        if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            es.ThrowError(ErrorList.UnlockColorSetError);

        InvokeOnErrorEvent();
    }

    protected override void OnRequestSuccess(UnityWebRequest request)
    {
        _requestWasSuccess = true;
        PrintSuccessText(request);
        _customizationManager.SaveCustomizatedColors();
        InvokeOnSuccessEvent();
    }
}