using UnityEngine;
using UnityEngine.UI;

public class ForceUpperCase : MonoBehaviour
{
    public Text textObject;
    void Start()
    {
        textObject.text = textObject.text.ToUpper();
    }
}
