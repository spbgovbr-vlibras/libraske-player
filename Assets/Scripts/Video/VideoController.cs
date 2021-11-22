using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string startingFile;

    void Start()
    {
        PlayVideo(startingFile);
    }

    public void PlayVideo(string filename)
    {
        string url = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        StartCoroutine(PlayVideoCoroutine(url));
    }

    private IEnumerator PlayVideoCoroutine(string url)
    {
        if (videoPlayer == null)
            yield break;

        videoPlayer.source = UnityEngine.Video.VideoSource.Url;
        videoPlayer.url = url;
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
            yield return null;

        videoPlayer.Play();
    }
}
