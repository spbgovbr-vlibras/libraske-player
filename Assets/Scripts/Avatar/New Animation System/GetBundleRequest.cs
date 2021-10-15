using Lavid.Libraske.DataStruct;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class GetBundleRequest : MonoBehaviour
{
    //string url = "https://drive.google.com/u/3/uc?id=1yfkF6fijiu6nkGyZvmstqIJJNvSOaGQ2&export=download";
    string url = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + UnityWebRequest.EscapeURL("1S_ACONSELHAR_2P");

    public AvatarAnimationBundle _avatarBundle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAnimation());
    }

    IEnumerator GetAnimation()
    {
        var request = new UnityWebRequest(url, RequestKeys.Get);
        request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.result);
            TryGetBundle(request);
        }
        else
        {
            Debug.Log(request.error);
            Debug.Log(request.downloadHandler.error);
        }
    }

    void TryGetBundle(UnityWebRequest request)
    {
        try
        {
            Debug.Log(request.downloadHandler);

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);

            Debug.Log("Passou daqui");
            string bundleName = bundle.GetAllAssetNames()[0];

            AnimationClip clip = (AnimationClip)bundle.LoadAsset(bundleName);

            _avatarBundle.AddClip(clip);

            Debug.LogWarning("serializado");
        }
        catch {
            Debug.LogWarning("Erro ao serializar");
        }
    }
}
