using UnityEngine;
using UnityEngine.Events;

public class GenericPauseListener : MonoBehaviour, IPauseObserver
{
    [SerializeField, Tooltip("Called when game is paused.")] private UnityEvent _onPause;
    [SerializeField, Tooltip("Called when game is unpaused.")] private UnityEvent _onResume;

    private void Awake()
    {
        if (FindObjectOfType<PauseSystem>() is PauseSystem pauseSystem)
            pauseSystem.AddObserver(this);
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        if (isPaused)
            _onPause?.Invoke();
        else
            _onResume?.Invoke();
    }
}