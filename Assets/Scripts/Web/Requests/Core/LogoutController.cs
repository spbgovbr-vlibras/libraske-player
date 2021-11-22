using UnityEngine;
using System.Runtime.InteropServices;

public class LogoutController : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Logout();

    public void RequestLogout () {
#if (UNITY_WEBGL == true && UNITY_EDITOR == false)
    Logout();
#endif
  }
}
