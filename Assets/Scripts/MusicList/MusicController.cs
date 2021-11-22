using UnityEngine;

[System.Serializable]
public class MusicController
{
    [SerializeField] private RuntimeAnimatorController _musicController;

    public RuntimeAnimatorController GetAnimatorController() => _musicController;
    private int _id;
    public int Id { get => _id; set => _id = value; }
}
