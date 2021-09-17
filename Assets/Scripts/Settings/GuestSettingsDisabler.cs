using UnityEngine;

public class GuestSettingsDisabler : MonoBehaviour
{

    public GameObject accountSettingsPanel;
    void Start()
    {
        if(AccessSetup.IsGuest == "true"){
            accountSettingsPanel.SetActive(false);
        }
    }
}
