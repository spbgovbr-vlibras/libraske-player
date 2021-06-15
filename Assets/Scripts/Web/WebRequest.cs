using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequest
{
    public static string a = "a";

    public static UnityWebRequest Get(WebConstants.URL url, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetString(url) + addicionalURL;

        var request = new UnityWebRequest( urlValue, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        return request;
    }

    public static UnityWebRequest Post(WebConstants.URL url, string jsonString, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetString(url) + addicionalURL;
        var request = new UnityWebRequest(urlValue, "POST");
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }
}