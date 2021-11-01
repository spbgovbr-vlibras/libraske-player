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
    [SerializeField] private string trainingAnimation5;

    [Header("Training Descriptions")]
    [SerializeField] private string trainingDescription1;
    [SerializeField] private string trainingDescription2;
    [SerializeField] private string trainingDescription3;
    [SerializeField] private string trainingDescription4;
    [SerializeField] private string trainingDescription5;

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
        string trainingAnimation5,
        string name, 
        string description, 
        string subtitle, 
        string price
    )
    {
        this.id = id;
        this.singers = singers;
        this.thumbnail = thumbnail;
        this.name = name;
        this.description = description;
        this.subtitle = subtitle;
        this.price = price;// int.Parse(price);

        this.animation = animation;
        this.song = song;
        this.trainingAnimation1 = trainingAnimation1;
        this.trainingAnimation2 = trainingAnimation2;
        this.trainingAnimation3 = trainingAnimation3;
        this.trainingAnimation4 = trainingAnimation4;
        this.trainingAnimation5 = trainingAnimation5;
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

    // TODO: MAKE RETURN STRUCT VALUE WHEN SYNC WITH API
    public string GetTrainingDescription(int index)
    {
        return index switch
        {
            0 => "trainingDescription1",
            1 => "trainingDescription2",
            2 => "trainingDescription3",
            3 => "trainingDescription4",
            4 => "trainingDescription5",
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
            4 => trainingAnimation5,
            _ => null
        };
    }
    #endregion
}
