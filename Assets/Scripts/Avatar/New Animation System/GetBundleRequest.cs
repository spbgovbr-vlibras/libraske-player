using Lavid.Libraske.DataStruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GetBundleRequest : MonoBehaviour
{
    //string url = "https://drive.google.com/u/3/uc?id=1yfkF6fijiu6nkGyZvmstqIJJNvSOaGQ2&export=download";
    //public string m_url = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + UnityWebRequest.EscapeURL("1S_ACONSELHAR_2P");
    private UnityWebRequest _lastRequest;

    private AssetBundle _bundle;
    private AnimationClip _clip;

    public UnityWebRequest GetLastRequest() => _lastRequest;

    public IEnumerator SendRequest(string url)
    {
        var request = WebRequest.GetBundle(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            //Debug.Log(request.result);
            _lastRequest = request;
        }
        else
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.error);
        }
    }

    public AnimationClip TryGetFirstClip(UnityWebRequest request)
    {
        try
        {
            _bundle = DownloadHandlerAssetBundle.GetContent(request);

            //Debug.Log("Passou daqui " + _bundle.name);
            string bundleName = _bundle.GetAllAssetNames()[0];
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
 