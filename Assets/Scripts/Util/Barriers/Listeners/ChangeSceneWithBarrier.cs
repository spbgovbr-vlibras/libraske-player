using UnityEngine;
using Lavid.Libraske.Util;

public class ChangeSceneWithBarrier : MonoBehaviour
{
    [SerializeField] private GameObject _barrierObject;
    [SerializeField] private SceneNames _sceneToGo;
    [SerializeField] private LoadSceneManager _sceneManager;

    private IBarrier _barrier;

    private void Awake()
    {
        _barrier = _barrierObject.GetComponent<IBarrier>();
        _barrier.OnUnlockBarrier += OnBarrierUnlocked;
    }

    private void OnDestroy()
    {
        if (_barrier != null)
            _barrier.OnUnlockBarrier -= OnBarrierUnlocked;
    }

    private void OnBarrierUnlocked() => _sceneManager.LoadScene(_sceneToGo);
}