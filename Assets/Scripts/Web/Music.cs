﻿using UnityEngine;

[System.Serializable]
public class Music
{
    [SerializeField] private string id;
    [SerializeField] private string singers;
    [SerializeField] private string thumbnail;
    [SerializeField] private string name;
    [SerializeField, TextArea(5, 10)] private string description;
    [SerializeField] private string subtitle;
    [SerializeField] private string price;

    public Music(string id, string singers, string thumbnail, string name, string description, string subtitle, string price)
    {
        this.id = id;
        this.singers = singers;
        this.thumbnail = thumbnail;
        this.name = name;
        this.description = description;
        this.subtitle = subtitle;
        this.price = price;// int.Parse(price);
    }

    public string ShowAllData()
    {
        return (Id + " " + Singers + " " + ThumbnailURL + " " + Name + " " + Description + " " + Subtitle + " " + Price); 
    }

    public string Price { get => price;  }
    public string Id { get => id;}
    public string Singers { get => singers;}
    public string Name { get => name;}
    public string Description { get => description;}
    public string Subtitle { get => subtitle;}
    public string ThumbnailURL { get => thumbnail;}

    public string GetTrainingURL(int index)
    {
        return index switch
        {
            0 => URLTreino0,
            1 => URLTreino1,
            2 => URLTreino3,
            3 => URLTreino4,
            4 => URLTreino5,
            _ => null
        };
    }
    private string URLTreino0 { get; }
    private string URLTreino1 { get; }
    private string URLTreino3 { get; }
    private string URLTreino4 { get; }
    private string URLTreino5 { get; }
    public string URLFullMusic { get; }
}
