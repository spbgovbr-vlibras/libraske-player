using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnableEventCaller : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnableObject;
    [SerializeField] private UnityEvent _onDisableObject;

    private void OnEnable() => _onEnableObject?.Invoke();
    private void OnDisable() => _onDisableObject?.Invoke();
}
