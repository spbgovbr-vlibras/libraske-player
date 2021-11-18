using UnityEngine;

[System.Serializable]
public class Music
{
    [Header("Data")]
    [SerializeField] private string id;
    [SerializeField] private string singers;
    [SerializeField] private string name;
    [SerializeField, TextArea(5, 10)] private string description;
    [SerializeField] private string price;
    [SerializeField] private bool isUnlocked;

    [Header("Media")]
    [SerializeField] private string thumbnail;
    [SerializeField] private string subtitle;
    [SerializeField] private string song; // mp3 file url

    [Header("Animations")]
    [SerializeField] private string animation; // full music
    [SerializeField] private string trainingAnimation1;
    [SerializeField] private string trainingAnimation2;
    [SerializeField] private string trainingAnimation3;
    [SerializeField] private string trainingAnimation4;

    [Header("Training Descriptions")]
    [SerializeField] private string trainingPhrase1;
    [SerializeField] private string trainingPhrase2;
    [SerializeField] private string trainingPhrase3;
    [SerializeField] private string trainingPhrase4;

    public Music 
    (
        string id, 
        string singers,
        string thumbnail,
        string animation,
        string song,
        string trainingAnimation1,
        string trainingAnimation2,
        string trainingAnimation3,
        string trainingAnimation4,
		string trainingPhrase1,
		string trainingPhrase2,
		string trainingPhrase3,
		string trainingPhrase4,
        string name, 
        string description, 
        string subtitle, 
        string price,
        bool isUnlocked
    )
    {
        this.id = id;
        this.singers = singers;
        this.thumbnail = thumbnail;
        this.name = name;
        this.description = description;
        this.subtitle = subtitle;
        this.price = price;// int.Parse(price);
        this.isUnlocked = isUnlocked;

        this.animation = animation;
        this.song = song;
		
        this.trainingAnimation1 = trainingAnimation1;
        this.trainingAnimation2 = trainingAnimation2;
        this.trainingAnimation3 = trainingAnimation3;
        this.trainingAnimation4 = trainingAnimation4;
		
		this.trainingPhrase1 = trainingPhrase1;
		this.trainingPhrase2 = trainingPhrase2;
		this.trainingPhrase3 = trainingPhrase3;
		this.trainingPhrase4 = trainingPhrase4;
    }

    public string ShowAllData()
    {
        return (Id + " " + Singers + " " + ThumbnailURL + " " + Name + " " + Description + " " + SubtitleURL + " " + Price); 
    }

    public string Price { get => price;  }
    public string Id { get => id;}
    public string Singers { get => singers;}
    public string Name { get => name;}
    public string Description { get => description;}
    public bool IsUnlocked { get => isUnlocked;}

    public string GetTrainingDescription(int index)
    {
        return index switch
        {
            0 => trainingPhrase1,
            1 => trainingPhrase2,
            2 => trainingPhrase3,
            3 => trainingPhrase4,
            _ => null
        };
    }

    #region URLs
    public string MusicMediaURL { get => song;  }
    public string SubtitleURL { get => subtitle;}
    public string ThumbnailURL { get => thumbnail;}
    public string FullAnimationURL { get => animation; }
    public string GetTrainingAnimationURL(int index)
    {
        return index switch
        {
            0 => trainingAnimation1,
            1 => trainingAnimation2,
            2 => trainingAnimation3,
            3 => trainingAnimation4,
            _ => null
        };
    }
    #endregion
}
