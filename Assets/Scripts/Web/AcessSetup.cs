using UnityEngine;
using UnityEngine.Events;

public class AcessSetup : MonoBehaviour
{
    public static string RefreshToken { get; private set; }
    public static string AcessToken { get; private set; }
    public static string Name { get; private set; }
    public static string Email { get; private set; }

    [SerializeField] private UnityEvent _onRecieveData;

    public void ReceiveData(
                                string refreshToken,
                                string accessToken,
                                string name,
                                string email
                            )
    {
        RefreshToken = refreshToken;
        AcessToken = accessToken;
        Name = name;
        Email = email;

        _onRecieveData?.Invoke();
    }
}