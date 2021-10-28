using Lavid.Libraske.Web;
using UnityEngine;

public class GuestSettingsDisabler : MonoBehaviour
{
    public GameObject accountSettingsPanel;

    void Start()
    {
        if(AccessData.IsGuest != null && AccessData.IsGuest){
            accountSettingsPanel.SetActive(false);
        }
    }
}
