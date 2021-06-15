public class Song
{
    private string _id;
    private string _singers;
    private string _name;
    private string _description;

    private string _subtitle;
    private string _thumbnail;

    public Song(string id, string singers, string name, string description, string subtitle, string thumbnail)
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
