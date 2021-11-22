using UnityEngine;
using Lavid.Libraske.UI;

[RequireComponent(typeof(TextUI))]
public class CreditsToText : MonoBehaviour
{
    [SerializeField] private TextUI _text;
    public GameObject creditObject;


    private void Start() => SetCreditsText();

    public void SetCreditsText() => _text.SetText(GetCredits());

    private string GetCredits()
    {
        return creditObject.GetComponent<RequestUserCredit>().ReturnCredit().ToString();
    }
}
