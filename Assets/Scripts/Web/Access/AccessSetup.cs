using Lavid.Libraske.Util;
using UnityEngine;
using UnityEngine.Events;

namespace Lavid.Libraske.Web
{
    /// <summary>  Class used to connect with React framework's </summary>
    [RequireComponent(typeof(AccessDataDebugger))]
    public class AccessSetup : MonoBehaviour
    {
        private AccessDataStruct _receivedData;

        [SerializeField] private UnityEvent _onRecieveData;

        public AccessDataStruct GetReceivedData() => _receivedData;

        private void OnReceiveNewData()
        {
            if (AllDataIsValid())
            {
                Debug.Log("All data was validated.\n");
                ApplyData();
                Debug.Log(AccessData.ToString());
                _onRecieveData?.Invoke();
            }
        }
        private void ApplyData()
        {
            AccessData.SetAccessToken(_receivedData.accessToken);
            AccessData.SetEmail(_receivedData.email);
            AccessData.SetIsGuest(_receivedData.isGuest);
            AccessData.SetRefreshToken(_receivedData.refreshToken);
            AccessData.SetUserName(_receivedData.userName);
        }

        public void SetRefreshToken(string data)
        {
            LogReceivedData(data, "refresh token");

            if (IsDataValid(data))
            {
                _receivedData.refreshToken = data;
                OnReceiveNewData();
            }
        }
        public void SetAccessToken(string data)
        {
            LogReceivedData(data, "access token");

            if (IsDataValid(data))
            {
                _receivedData.accessToken = data;
                OnReceiveNewData();
            }
        }
        public void SetName(string data)
        {
            LogReceivedData(data, "name");

            if (IsDataValid(data))
            {
                _receivedData.userName = data;
                OnReceiveNewData();
            }
        }
        public void SetEmail(string data)
        {
            LogReceivedData(data, "email");

            if (IsDataValid(data))
            {
                _receivedData.email = data;
                OnReceiveNewData();
            }
        }
        public void SetIsGuest(string data)
        {
            LogReceivedData(data, "is guest");

            if (IsDataValid(data))
            {
                _receivedData.isGuest = new Boolean(data);
                OnReceiveNewData();
            }
        }

        private bool IsDataValid(string data) => data != null && data != "";
        private void LogReceivedData(string data, string fieldName)
        {
            Debug.Log($"Received: {data} in \"{fieldName}\". Is Valid: {IsDataValid(data)}");
        }
        private bool AllDataIsValid()
        {
            return (
                       IsDataValid(_receivedData.refreshToken) &&
                       IsDataValid(_receivedData.accessToken) &&
                       IsDataValid(_receivedData.userName) &&
                       IsDataValid(_receivedData.email) &&
                       _receivedData.isGuest != null
                     );
        }
    }
}