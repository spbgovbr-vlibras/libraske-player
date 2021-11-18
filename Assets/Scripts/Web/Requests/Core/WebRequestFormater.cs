using Lavid.Libraske.Web;
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
    public static string Patch => "PATCH";

    public static string ContentType => "Content-Type";
    public static string JsonType => "application/json";
    public static string PngType = "image/png";
    public static string MultiFormData => "multipart/form-data";
}

public static class WebRequestFormater
{
    private static void AuthorizeRequest(UnityWebRequest request)
    {
        request.SetRequestHeader(RequestKeys.Authorization, $"{RequestKeys.Bearer} {AccessData.AccessToken}");
    }

    public static UnityWebRequest GetTexture(string url)
    {
        var request = UnityWebRequestTexture.GetTexture(url);
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest GetColors(CustomizationGroups.Groups group)
    {
        string url = WebConstants.FormatPersonalizationColorUrl(group);
        var request = new UnityWebRequest(url, RequestKeys.Get);
        request.downloadHandler = new DownloadHandlerBuffer();

        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest GetPontuation(string gameSessionId)
    {
        string urlValue = WebConstants.FormatPontuationUrl(gameSessionId);

        var request = new UnityWebRequest(urlValue, RequestKeys.Get);
        request.downloadHandler = new DownloadHandlerBuffer();

        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Get(string url)
    {
        var request = new UnityWebRequest(url, RequestKeys.Get);
        request.downloadHandler = new DownloadHandlerBuffer();

        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Get(WebConstants.URL url, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetURLFrom(url) + addicionalURL;

        var request = new UnityWebRequest( urlValue, RequestKeys.Get);
        request.downloadHandler = new DownloadHandlerBuffer();

        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest GetAudioClip(string url, AudioType type=AudioType.MPEG)
    {
        var request = UnityWebRequestMultimedia.GetAudioClip(url, type);
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Patch(WebConstants.URL url, string addicionalURL = "")
    {
        byte[] formData = null;
        string m_url = WebConstants.GetURLFrom(url) + addicionalURL;
        var request = UnityWebRequest.Put(m_url, formData);
        request.method = RequestKeys.Patch;
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest GetBundle(string url)
    {
        var request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest SendFrame(
                                                int frameId,
                                                byte[] image,
                                                string sessionId
                                            )
    {
        WWWForm form = new WWWForm();

        form.AddField(WebConstants.FrameIdField, frameId);

        if (image != null)
            form.AddBinaryData(WebConstants.FrameField, image, $"{sessionId}-{frameId}.png", RequestKeys.PngType);

        string url = WebConstants.GetURLFrom(WebConstants.URL.SendFrame) + $"/{sessionId}";
        Debug.Log(url);
        UnityWebRequest request = UnityWebRequest.Post(url, form);

        AuthorizeRequest(request);

        return request;
    }

    public static UnityWebRequest EmptyPost(WebConstants.URL url, string addicionalURL = "", bool jsonType=true)
    {
        string urlValue = WebConstants.GetURLFrom(url) + addicionalURL;
        var request = new UnityWebRequest(urlValue, RequestKeys.Post);
        request.downloadHandler = new DownloadHandlerBuffer();

        if(jsonType)
            request.SetRequestHeader(RequestKeys.ContentType, RequestKeys.JsonType);

        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Post(WebConstants.URL url, string data, string addicionalURL = "")
    {
        string urlValue = WebConstants.GetURLFrom(url) + addicionalURL;
        var request = new UnityWebRequest(urlValue, RequestKeys.Post);
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        request.uploadHandler = new UploadHandlerRaw(bytes);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader(RequestKeys.ContentType, RequestKeys.JsonType);
        AuthorizeRequest(request);
        return request;
    }

    public static UnityWebRequest Delete(WebConstants.URL url)
    {
        string urlValue = WebConstants.GetURLFrom(url);
        var request = new UnityWebRequest(urlValue, RequestKeys.Delete);
        request.SetRequestHeader(RequestKeys.ContentType, RequestKeys.JsonType);
        AuthorizeRequest(request);
        return request;
    }
}