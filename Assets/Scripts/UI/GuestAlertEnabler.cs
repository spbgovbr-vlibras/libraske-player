using Lavid.Libraske.Web;
using UnityEngine;

public class GuestAlertEnabler : MonoBehaviour
{
    public GameObject guestAlert;

    void Start()
    {
        if (AccessData.IsGuest != null && AccessData.IsGuest)
        {
            guestAlert.SetActive(true);
        }
    }
}
