using UnityEngine;

namespace Lavid.Libraske.Web
{
    public class AccessDataDebugger : MonoBehaviour
    {
        [SerializeField] private AccessDataStruct _currentData;

        [Space(8), Header("Data To Apply")]
        [SerializeField] private AccessDataStruct _toApply;
        [SerializeField] private bool _applyInspectorData;

        private void OnEnable() => enabled = IsInEditor();

        private bool IsInEditor()
        {
            bool isInEditor = Application.platform == RuntimePlatform.OSXEditor;
            isInEditor |= Application.platform == RuntimePlatform.WindowsEditor;
            isInEditor |= Application.platform == RuntimePlatform.LinuxEditor;
            return isInEditor;
        }

        private void LateUpdate()
        {
            if (!IsInEditor())
                enabled = false;

            if (_applyInspectorData)
            {
                ApplyInspectorData();
                _applyInspectorData = false;
            }

            UpdateCurrentData();
        }

        private void ApplyInspectorData()
        {
            AccessData.SetRefreshToken(_toApply.refreshToken);
            AccessData.SetAccessToken(_toApply.accessToken);
            AccessData.SetUserName(_toApply.userName);
            AccessData.SetEmail(_toApply.email);
            AccessData.SetIsGuest(_toApply.isGuest);
        }

        private void UpdateCurrentData()
        {
            _currentData.refreshToken = AccessData.RefreshToken;
            _currentData.accessToken = AccessData.AccessToken;
            _currentData.userName = AccessData.UserName;
            _currentData.email = AccessData.Email;
            _currentData.isGuest = AccessData.IsGuest;
        }
    }
}