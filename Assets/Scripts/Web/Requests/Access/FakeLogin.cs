using Lavid.Libraske.Web;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public struct FakeLoginData
{
    public int id;
    public string name;
    public string email;
    public string profilePhoto;
    public string refreshToken;
    public string cpf;
    public int credit;
    public bool isGuest;
    public string created_at;
    public string updated_at;
    public string accessToken;
}

public class FakeLogin : MonoBehaviour
{
    [SerializeField] AccessSetup _accessSetup;
    [SerializeField] RuntimePlatform[] _debugPlatforms;

    FakeLoginData _data;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _debugPlatforms.Length; i++)
        {
            if(Application.platform == _debugPlatforms[i])
            {
                StartCoroutine(LoginCoroutine());
                break;
            }
        }
    }

    private IEnumerator LoginCoroutine()
    {
        var request = WebRequestFormater.EmptyPost(WebConstants.URL.FakeLogin);
        yield return request.SendWebRequest();

        if (request.isDone && request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
            _data = JsonUtility.FromJson<FakeLoginData>(request.downloadHandler.text);
            _accessSetup.SetData(_data);
        }
        else
            Debug.Log(request.error);
    }
}
