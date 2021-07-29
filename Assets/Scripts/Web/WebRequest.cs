using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequest
{
    public static UnityWebRequest GetTexture(string url)
    {
        var request = UnityWebRequestTexture.GetTexture(url);
        //request.downloadHandler = new DownloadHandlerBuffer();
        return request;
    }

    public static UnityWebRequest Get(WebConstants.URL url, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetString(url) + addicionalURL;

        var request = new UnityWebRequest( urlValue, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        return request;
    }

    public static UnityWebRequest SendFrame(
                                                WebConstants.URL url,
                                                int frameId,
                                                byte[] image,
                                                string sessionId, 
                                                string addicionalURL = ""
                                            )
    {
        WWWForm form = new WWWForm();

        form.AddField(WebConstants.FrameIdField, frameId);

        if (image != null)
            form.AddBinaryData("frame", image, $"{sessionId}-{frameId}.png", "image/png");

        UnityWebRequest www = UnityWebRequest.Post(url + addicionalURL, form);
        return www;
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