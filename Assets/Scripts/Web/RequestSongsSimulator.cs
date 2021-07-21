using Lavid.Libraske.DataStruct;
using UnityEngine;

public class RequestSongsSimulator : MonoBehaviour
{
    public Wrapper<Music> _songs;
    public MusicMenu _musicMenu;

    // Start is called before the first frame update
    void Start()
    {

        _musicMenu.SetMusics(_songs);
    }
}
