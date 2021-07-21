using UnityEngine;

[System.Serializable]
public class Music
{
    [SerializeField] private string _id;
    [SerializeField] private string _singers;
    [SerializeField] private string _name;
    [SerializeField, TextArea(5, 10)] private string _description;
    [SerializeField] private string _subtitle;
    [SerializeField] private string _thumbnail;

    public Music(string id, string singers, string name, string description, string subtitle, string thumbnail)
    {
        _id = id;
        _singers = singers;
        _name = name;
        _description = description;
        _subtitle = subtitle;
        _thumbnail = thumbnail;
    }

    public string Id { get => _id;}
    public string Singers { get => _singers;}
    public string Name { get => _name;}
    public string Description { get => _description;}
    public string Subtitle { get => _subtitle;}
    public string Thumbnail { get => _thumbnail;}
}
