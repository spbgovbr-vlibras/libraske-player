using UnityEngine;
using System.IO;
using UnityEngine.Video;

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
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
        videoPlayer.Play();
    }
}
