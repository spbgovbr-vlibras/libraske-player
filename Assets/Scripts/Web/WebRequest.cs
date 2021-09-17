using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class WebRequest
{
    public static UnityWebRequest GetTexture(string url)
    {
        var request = UnityWebRequestTexture.GetTexture(url);
        return request;
    }

    public static UnityWebRequest Get(WebConstants.URL url, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetString(url) + addicionalURL;

        var request = new UnityWebRequest( urlValue, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + AccessSetup.AccessToken);

        /*request.SetRequestHeader("Authorization", "Bearer " + 
                                                                $"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjcGY" +
                                                                $"iOiIxMzI4MTUzNTA5NyIsImlhdCI6MTYzMDAyMTQyMCwiZX" +
                                                                $"hwIjoxNjMwMTA3ODIwfQ.gkzdYtOfg2Al8OiMmuLyuSm" +
                                                                $"EoMrj9jR8L3BAF90LvnE");*/
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

    public static UnityWebRequest Delete(WebConstants.URL url)
    {
        string urlValue = WebConstants.GetString(url);
        var request = new UnityWebRequest(urlValue, "DELETE");
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + AccessSetup.AccessToken);
        return request;
    }
}