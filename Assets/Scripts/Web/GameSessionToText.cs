using Lavid.Libraske.UI;
using UnityEngine;

[RequireComponent(typeof(TextUI))]
public class GameSessionToText : MonoBehaviour
{
    [SerializeField] CurrentGameSession.Fields _field;
    [SerializeField] private TextUI _text;

    private void Start() => UpdateText();
    public void UpdateText() => _text.SetText(GetInField());

    private string GetInField()
    {
        return _field switch
        {
            CurrentGameSession.Fields.ID => CurrentGameSession.ID,
            CurrentGameSession.Fields.Name => CurrentGameSession.MusicName,
            CurrentGameSession.Fields.Pontuation => CurrentGameSession.GetPontuation().ToString(),
            _ => ""
        };
    }
}