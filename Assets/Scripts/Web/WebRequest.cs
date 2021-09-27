using System.Text;
using UnityEngine;
using UnityEngine.Networking;

internal struct RequestKeys
{
    public static string Authorization => "Authorization";
    public static string Bearer => "Bearer";

    public static string Get => "Get";
    public static string Delete => "DELETE";
    public static string Post => "POST";

    public static string ContentType => "Content-Type";
    public static string JsonType => "application/json";
    public static string PngType = "image/png";
}

public static class WebRequest
{
    public static UnityWebRequest GetTexture(string url)
    {
        var request = UnityWebRequestTexture.GetTexture(url);
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Get(WebConstants.URL url, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetString(url) + addicionalURL;

        var request = new UnityWebRequest( urlValue, RequestKeys.Get);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader(RequestKeys.ContentType, RequestKeys.JsonType);

        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest SendFrame(
                                                int frameId,
                                                byte[] image,
                                                string sessionId, 
                                                string addicionalURL = ""
                                            )
    {
        WWWForm form = new WWWForm();

        form.AddField(WebConstants.FrameIdField, frameId);

        if (image != null)
            form.AddBinaryData(WebConstants.FrameField, image, $"{sessionId}-{frameId}.png", RequestKeys.PngType);

        var url = WebConstants.GetString(WebConstants.URL.SendFrame) + addicionalURL;
        UnityWebRequest request = UnityWebRequest.Post(url, form);

        AuthorizeRequest(request);

        return request;
    }

    private static void AuthorizeRequest(UnityWebRequest request)
    {
        request.SetRequestHeader(RequestKeys.Authorization, $"{RequestKeys.Bearer}  {AccessSetup.AccessToken}");
    }

    public static UnityWebRequest Post(WebConstants.URL url, string jsonString, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetString(url) + addicionalURL;
        var request = new UnityWebRequest(urlValue, RequestKeys.Post);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Delete(WebConstants.URL url)
    {
        string urlValue = WebConstants.GetString(url);
        var request = new UnityWebRequest(urlValue, RequestKeys.Delete);
        request.SetRequestHeader(RequestKeys.ContentType, RequestKeys.JsonType);
        AuthorizeRequest(request);
        return request;
    }
}