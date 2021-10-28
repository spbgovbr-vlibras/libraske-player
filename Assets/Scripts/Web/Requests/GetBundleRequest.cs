using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class GetBundleRequest : MonoBehaviour
{
    private UnityWebRequest _lastRequest;

    private AssetBundle _bundle;
    private AnimationClip _clip;

    public AssetBundle GetLastBundle() => _bundle;
    public UnityWebRequest GetLastRequest() => _lastRequest;

    public IEnumerator SendRequest(string url)
    {
        var request = WebRequestFormater.GetBundle(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            _lastRequest = request;
        }
        else
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.error);
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.CastError);
        }
    }

    public AnimationClip GetClipOnBundle(UnityWebRequest request)
    {
        try
        {
            _bundle = DownloadHandlerAssetBundle.GetContent(request);

            int desiredIndex = 0;
            string bundleName = _bundle.GetAllAssetNames()[desiredIndex];
            Debug.Log(_bundle.LoadAsset(bundleName));
            _clip = (AnimationClip)_bundle.LoadAsset(bundleName);
            Debug.LogWarning("serializado");

            return _clip;
        }
        catch {
            Debug.LogWarning("Erro ao serializar");
            return null;
        }
    }
}
 