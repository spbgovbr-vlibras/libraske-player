using Lavid.Libraske.UnlockSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class UnlockColorSetRequest : WebRequest
{
    [SerializeField] RequestUserCredit _creditRequest;
    [SerializeField] UnlockController _controller;
    public override string GetLogName() => "UnlockColorSet";

    private IUnlockable _item;

    public void TryUnlock(IUnlockable item)
    {
        _item = item;
        StartCoroutine(SendRequest());
    }

    public override IEnumerator SendRequest()
    {
        Logger.Log(this, "Iniciando Requisição de desbloqueio.");

        yield return StartCoroutine(_creditRequest.RequestCreditCoroutine());

        if(_creditRequest.ReturnCredit() < _item.Price)
        {
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.OutOfCreditsError);

            yield break;
        }

        var www = WebRequestFormater.EmptyPost(WebConstants.URL.BuyColorSet, $"/{_item.Id}", false);
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
        _controller.OnRequestSuccess(_item);
        InvokeOnSuccessEvent();
    }
}
