using UnityEngine;

[CreateAssetMenu(fileName = "Music", menuName = "Libraske/Object/Music")]
public class MusicSO : ScriptableObject
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private string _author;
    [SerializeField] private int _id;

    [SerializeField, Tooltip("The minutes part of the total duration"), Range(0, 59)] private  int _minutesDuration;
    [SerializeField, Tooltip("The seconds part of the total duration"), Range(0, 59)] private int _secondsDuration;

    public void CopyDataTo(MusicSO destine)
    {
        _sprite = destine._sprite;
        _name = destine._name;
        _author = destine._author;
        _id = destine._id;
        _minutesDuration = destine._minutesDuration;
        _secondsDuration = destine._secondsDuration;
    }

    public Sprite GetSprite() => _sprite;
    public string GetName() => _name;
    public string GetAuthor() => _author;
    public int GetId() => _id;

    /// <returns>returns the minutes part of the total duration.</returns>
    public int GetMinutesOfDuration() => _minutesDuration;

    /// <returns>returns the seconds part of the total duration.</returns>
    public int GetSecondsOfDuration() => _secondsDuration;
}