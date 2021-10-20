using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteUserRequest : MonoBehaviour
{
    public void RequestDeletion()
    {
        StartCoroutine(DeleteUserCoroutine(WebConstants.URL.UsersURL));
    }

    IEnumerator DeleteUserCoroutine(WebConstants.URL url)
    {
        var webRequest = WebRequestFormater.Delete(url);
 
        yield return webRequest.SendWebRequest();
    }
}
