using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditDisplayScaler : MonoBehaviour
{
    public Sprite[] SizeSprites;
    public Image CreditContainer;
    public GameObject creditObject;

    void Start()
    {
        ScaleDisplay();
    }

    public void ScaleDisplay()
    {
        int credit = creditObject.GetComponent<RequestUserCredit>().ReturnCredit();

        if (credit < 10)
        {
            SetScale(0);
        }
        else if (credit >= 10 && credit < 100)
        {
            SetScale(1);
        }
        else if (credit >= 100 && credit < 1000)
        {
            SetScale(2);
        }
        else if (credit >= 1000 && credit < 10000)
        {
            SetScale(3);
        }
        else if (credit >= 10000)
        {
            SetScale(4);
        }
    }

    public void SetScale(int index)
    {
        CreditContainer.sprite = SizeSprites[index];
        CreditContainer.SetNativeSize();
    }
}
