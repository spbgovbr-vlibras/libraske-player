using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class RequestUserCredit : MonoBehaviour
{

    private int _credit;
    private class UserData
    {
        public int credit;
    }
    [SerializeField] private UnityEvent _onSuccess;

    public void Start()
    {
        RequestCredit();
    }

    public void RequestCredit()
    {
        StartCoroutine(RequestCreditCoroutine(WebConstants.URL.UsersURL));
    }

    public int ReturnCredit()
    {
        return _credit;
    }

    IEnumerator RequestCreditCoroutine(WebConstants.URL url)
    {
        var webRequest = WebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            UserData loaded = JsonUtility.FromJson<UserData>(webRequest.downloadHandler.text);

            _credit = loaded.credit;

            _onSuccess?.Invoke();
        }
        else
        {
            FindObjectOfType<ErrorSystem>().ThrowError(new InGameError(webRequest.error));
        }
    }
}
