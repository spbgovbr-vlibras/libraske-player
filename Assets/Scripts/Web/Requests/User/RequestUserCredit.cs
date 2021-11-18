using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public struct UserData
{
    public string id;
    public string name;
    public string email;
    public string profilePhoto;
    public string refreshToken;
    public string cpf;
    public string credit;
    public string isGuest;
    public string created_at;
    public string updated_at;
    public string pele;
    public string olhos;
    public string cabelo;
    public string camisa;
    public string calca;
}


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
            FindObjectOfType<ErrorSystem>().ThrowError(new InGameError(webRequest.error));
        }
    }
}
