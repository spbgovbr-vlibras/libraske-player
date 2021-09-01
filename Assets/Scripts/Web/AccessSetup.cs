using UnityEngine;
using UnityEngine.Events;

public class AccessSetup : MonoBehaviour
{
    public static string RefreshToken { get; private set; }
    public static string AccessToken { get; private set; }
    public static string UserName { get; private set; }
    public static string Email { get; private set; }

    [SerializeField] private UnityEvent _onRecieveData;

    /// <returns> Returns true case data is valid, false otherwise. </returns>
    private bool AllDataIsValid()
    {
        return !(
                    RefreshToken == null ||
                    RefreshToken == "" ||

                    AccessToken == null ||
                    AccessToken == "" ||

                    UserName == null ||
                    UserName == "" ||

                    Email == null ||
                    Email == ""
               );
    }

    private void RecievedNewData()
    {
        if (AllDataIsValid())
        {
              Debug.Log(
                "Refresh Token: " + RefreshToken +
                " Access Token: " + AccessToken +
                " Name: " + UserName +
                " Email " + Email
             );

            _onRecieveData?.Invoke();
        }
    }

    public void SetRefreshToken(string data)
    {
        Debug.Log("Recebeu: " + data);
        RefreshToken = data;
        RecievedNewData();
    }

    public void SetAccessToken(string data)
    {
        Debug.Log("Recebeu: " + data);
        AccessToken = data;
        RecievedNewData();
    }

    public void SetName(string data)
    {
        Debug.Log("Recebeu: " + data);
        UserName = data;
        RecievedNewData();
    }

    public void SetEmail(string data)
    {
        Debug.Log("Recebeu: " + data);
        Email = data;
        RecievedNewData();
    }

    public void ReceiveData(
                                string refreshToken,
                                string accessToken,
                                string name,
                                string email
                            )
    {
        RefreshToken = refreshToken;
        AccessToken = accessToken;
        UserName = name;
        Email = email;

        //Debug.Log(
        //            "Refresh Token: " + refreshToken +
        //            " Access Token: " + AccessToken +
        //            " Name: " + name + 
        //            " Email " + email
        //         );

        _onRecieveData?.Invoke();
    }
}