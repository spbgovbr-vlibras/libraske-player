using Lavid.Libraske.DataStruct;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music List", menuName = "Libraske/Music/Music List")]
public class MusicListSO : ScriptableObject
{
    [SerializeField] private Wrapper<MusicController> _musics;
    public RuntimeAnimatorController GetControllerAtIndex(int index) => _musics[index].GetAnimatorController();

    private void OnValidate()
    {
        for (int i = 0; i < _musics.Length; i++)
            _musics[i].Id = i;
    }
}