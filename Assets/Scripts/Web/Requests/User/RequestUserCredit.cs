using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class RequestUserCredit : MonoBehaviour
{

    private int _credit;

    [SerializeField] private UnityEvent _onSuccess;

    public void RequestCredit()
    {
        StartCoroutine(RequestCreditCoroutine());
    }

    public int ReturnCredit()
    {
        return _credit;
    }

    public IEnumerator RequestCreditCoroutine()
    {
        var webRequest = WebRequestFormater.Get(WebConstants.URL.UsersURL);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            UserData loaded = JsonUtility.FromJson<UserData>(webRequest.downloadHandler.text);

            _credit = int.Parse(loaded.credit);

            _onSuccess?.Invoke();
        }
        else
        {
            if(FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(new InGameError(webRequest.error));
        }
    }
}
