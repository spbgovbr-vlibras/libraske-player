using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class SongUnlockManager : MonoBehaviour
{
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private GameObject _blockedButton;
    [SerializeField] private MusicDataHolderSO _dataHolder;
    [SerializeField] private RequestUserCredit _creditHolder;
    [SerializeField] private UnityEvent _onSuccess;

    public void SetTransactionUI()
    {
        if(HasSufficientCredit()){
            _unlockButton.SetActive(true);
            _blockedButton.SetActive(false);
        }else{
            _unlockButton.SetActive(false);
            _blockedButton.SetActive(true);
        }
    }

    public void UnlockSong(){
        Music music = _dataHolder.GetMusicData();
        string songId = music.Id;

        if(HasSufficientCredit()){
            StartCoroutine(RequestSongUnlockCoroutine(WebConstants.URL.SongStoreURL, songId));
        }else{
            FindObjectOfType<ErrorSystem>().ThrowError(new InGameError("Erro na transação. Por favor, recarregue o jogo!"));
        }
    }

    IEnumerator RequestSongUnlockCoroutine(WebConstants.URL url, string songId)
    {
        var webRequest = WebRequestFormater.EmptyPost(url, songId);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            _onSuccess?.Invoke();
        }
        else
        {
            FindObjectOfType<ErrorSystem>().ThrowError(new InGameError(webRequest.error));
        }
    }

    private bool HasSufficientCredit(){
        Music music = _dataHolder.GetMusicData();
        int price = int.Parse(music.Price);
        int credit = _creditHolder.ReturnCredit();

        return credit >= price;
    }
}
