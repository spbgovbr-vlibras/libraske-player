using UnityEngine;
using System.Runtime.InteropServices;

public class RedirectController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void GovAuthRedirect();

    public void RequestGovRedirect()
    {
#if (UNITY_WEBGL == true && UNITY_EDITOR == false)
    GovAuthRedirect();
#endif
    }
}
